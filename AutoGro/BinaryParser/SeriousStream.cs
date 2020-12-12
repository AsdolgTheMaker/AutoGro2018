using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGro
{
    public class SeriousStream : FileStream
    {
        // This data is should be retrieved from SIGSTRM1 struct.
        public uint datablockSize = 0;
        public uint credentialsSize = 0;
        public long currentRightCredential = 0;

        /* Struct types specification
           * 
           *  SIGSTRM1
           *    uint additionalSignature
           *    uint versionNumber
           *    uint blockSize
           *    uint type
           *    uint data1
           *    uint data2
           *    uint data3
           *    uint data4
           *    uint data5
           *    uint checksumSize
           *    uint commentLength
           * 
           *  WRKSTRM1
           *    uint unknownData1
           *    uint unknownData2
           *    uint unknownData3
           * 
           *  CTSEMETA
           *    uint endianess
           *    uint formatVersion
           *    uint versionStringLength
           * 
           *  INFO
           *    uint finalised
           *    uint referenceCount
           *    uint identsCount
           *    uint typesCount
           *    uint objectsCount
           * 
           *  RFIL
           *    uint entriesAmount
           *    Array<uint, string> entries
           * 
           *  MSGS
           *    uint messagesLength
           *    string messages
           *    
           *  Unknown - was not able to determine struct type. Meant to signal that we have to stop reading the file as binary.
       */
        public enum StructType
        {
            SIGSTRM1,
            WRKSTRM1,
            CTSEMETA,
            INFO,
            RFIL,
            MSGS,
            Unknown
        }

        /// <summary>
        /// Tries to read ID following from current cursor position. If the returned type is Unknown - cursor moves back to position from before method call.
        /// </summary>
        public StructType CheckID()
        {
            uint id = ReadUint32();
            switch (id)
            { // compare found ID to predefined hexadecimal equivalents (not strings - for efficiency reasons) and return corresponding struct type
                case 0x53474953: if (ReadUint32() == 0x314D5254) return StructType.SIGSTRM1; else Seek(-8, SeekOrigin.Current); return StructType.Unknown;
                case 0x534B5257: if (ReadUint32() == 0x314D5254) return StructType.WRKSTRM1; else Seek(-8, SeekOrigin.Current); return StructType.Unknown;
                case 0x45535443: if (ReadUint32() == 0x4154454D) return StructType.CTSEMETA; else Seek(-8, SeekOrigin.Current); return StructType.Unknown;
                case 0x4F464E49: return StructType.INFO;
                case 0x4C494652: return StructType.RFIL;
                case 0x5347534D: return StructType.MSGS;
                default: Seek(-4, SeekOrigin.Current); return StructType.Unknown;
            }
        }

        /// <summary>
        /// Efficiently reads struct in file stream
        /// </summary>
        /// <param name="stream">Stream to read</param>
        /// <param name="structType">StructType to use</param>
        /// <returns>List of file references for (RFIL struct).</returns>
        public List<string> ReadStruct(StructType structType)
        {
            switch (structType)
            {
                case StructType.SIGSTRM1:
                    {
                        SkipBytes(4 * 2); // 2GIS marker, version

                        datablockSize = ReadUint32(); // datablock size (200 000 by default)

                        SkipBytes(4 * 5); // type, unknown data 1, unknown data 2, unknown data 3, unknown data 4
                        SkipString(); // unknown string

                        credentialsSize = ReadUint32();
                        uint credentialsCommentSize = ReadUint32();

                        SkipBytes(credentialsSize + credentialsCommentSize);

                        // Store where next credential will be met to be able to skip it.
                        currentRightCredential = Position + datablockSize;

                        return null;
                    }

                case StructType.WRKSTRM1:
                    {
                        SkipUint32(3); // 12 bytes of unknown data
                        return null;
                    }

                case StructType.CTSEMETA:
                    {
                        SkipUint32(2); // file's endianness and metadata format
                        SkipString(); // version string
                        return null;
                    }

                case StructType.MSGS:
                    {
                        SkipString();
                        return null;
                    }

                case StructType.INFO:
                    {
                        SkipUint32(5);
                        return null;
                    }

                case StructType.RFIL:
                    {
                        uint entriesAmount = ReadUint32(); // check how many entires RFIL has
                        List<string> fileReferences = new List<string>((int)entriesAmount);

                        // read each RFIL entry
                        for (int i = 0; i < entriesAmount; i++)
                        {
                            SkipUint32(2); // skip two unknown uint32 data

                            fileReferences.Add(ReadString()); // read and save entry
                        }
                        return fileReferences;
                    }

                default: throw new ArgumentException("Unsupported struct type " + structType.ToString());
            }
        }

        #region Readers

        public override int Read(byte[] array, int offset, int count)
        {
            for (int i = offset; i < count; i++)
            {
                if (Position == currentRightCredential) // if we are at the next credential - skip it, then calculate its next position
                {
                    SkipBytesNoSignatureCheck(credentialsSize);
                    currentRightCredential += credentialsSize + datablockSize;
                }
                int oneByte = ReadByte();
                if (oneByte == -1) count--;
                else array[i] = (byte)oneByte;
            }
            return count;
        }

        public uint ReadUint32()
        {
            byte[] uintBuffer = new byte[4];
            Read(uintBuffer, 0, 4);
            return BitConverter.ToUInt32(uintBuffer, 0);
        }

        public string ReadString()
        {
            uint strLength = ReadUint32();
            return ReadString(strLength);
        }
        public string ReadString(uint length)
        {
            byte[] strBuffer = new byte[length];
            Read(strBuffer, 0, (int)length);
            return Encoding.UTF8.GetString(strBuffer);
        }

        #endregion

        #region Skippers

        public void SkipUint32() => SkipUint32(1);
        public void SkipUint32(int times) => SkipBytes(4 * times);

        public void SkipString() => SkipString(1);
        public void SkipString(int times)
        {
            for (uint i = 0; i < times; i++)
            {
                uint strLength = ReadUint32();
                SkipBytes(strLength);
            }
        }

        public void SkipBytes(int bytesAmount) => SkipBytes((uint)bytesAmount);
        public void SkipBytes(uint bytesAmount)
        {
            for (int i = 0; i < bytesAmount; i++)
            {
                if (Position == currentRightCredential) // if we are at the next credential - skip it, then calculate its next position
                {
                    SkipBytesNoSignatureCheck(credentialsSize);
                    currentRightCredential += credentialsSize + datablockSize;
                }
                SkipBytesNoSignatureCheck(1);
            }
        }

        public void SkipBytesNoSignatureCheck(uint bytesAmount) => Seek(bytesAmount, SeekOrigin.Current);
        public void SkipBytesNoSignatureCheck(int bytesAmount) => Seek(bytesAmount, SeekOrigin.Current);

        #endregion

        public SeriousStream(string path, FileMode mode, FileAccess access) : base(path, mode, access) { }
    }
}