using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoGro
{
    public static partial class BinaryParser
    {
        public static class SeriousUniversalContainer
        {
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

            public static StructType CheckID(FileStream stream)
            {
                uint id = ReadUint32(stream);
                switch (id)
                {
                    case 0x53474953: if (ReadUint32(stream) == 0x314D5254) return StructType.SIGSTRM1; else return StructType.Unknown;
                    case 0x534B5257: if (ReadUint32(stream) == 0x314D5254) return StructType.WRKSTRM1; else return StructType.Unknown;
                    case 0x45535443: if (ReadUint32(stream) == 0x4154454D) return StructType.CTSEMETA; else return StructType.Unknown;
                    case 0x4F464E49: return StructType.INFO;
                    case 0x4C494652: return StructType.RFIL;
                    case 0x5347534D: return StructType.MSGS;
                    default: return StructType.Unknown;
                }
            }

            /// <summary>
            /// Efficiently reads struct in file stream
            /// </summary>
            /// <param name="stream">Stream to read</param>
            /// <param name="structType">StructType to use</param>
            /// <returns>List of file references (only for RFIL struct)</returns>
            public static List<string> ReadStruct(FileStream stream, StructType structType)
            {
                switch (structType)
                {
                    case StructType.SIGSTRM1:
                        {
                            SkipBytes(stream, 4 * 8); // 2GIS marker, version, type, unknown data 1, unknown data 2, unknown data 3, unknown data 4
                            SkipString(stream); // unknown string

                            uint credentialsSize = ReadUint32(stream);
                            uint credentialsCommentSize = ReadUint32(stream);

                            SkipBytes(stream, (int)(credentialsSize + credentialsCommentSize));

                            return null;
                        }

                    case StructType.WRKSTRM1:
                        {
                            SkipUint32(stream, 3); // 12 bytes of unknown data
                            return null;
                        }

                    case StructType.CTSEMETA:
                        {
                            SkipUint32(stream, 2); // file's endianness and metadata format
                            SkipString(stream); // version string
                            return null;
                        }

                    case StructType.MSGS:
                        {
                            SkipString(stream);
                            return null;
                        }

                    case StructType.INFO:
                        {
                            SkipUint32(stream, 5);
                            return null;
                        }

                    case StructType.RFIL:
                        {
                            uint entriesAmount = ReadUint32(stream); // check how many entires RFIL has
                            List<string> fileReferences = new List<string>((int)entriesAmount);

                            // read each RFIL entry
                            for (int i = 0; i < entriesAmount; i++)
                            {
                                SkipUint32(stream, 2); // skip two unknown uint32 data
                                fileReferences.Add(ReadString(stream)); // read and save entry
                            }
                            return fileReferences;
                        }

                    default: throw new ArgumentException("Unsupported struct type " + structType.ToString());
                }
            }

            public static uint ReadUint32(FileStream stream)
            {
                byte[] uintBuffer = new byte[4];
                stream.Read(uintBuffer, 0, 4);
                return BitConverter.ToUInt32(uintBuffer, 0);
            }

            public static void SkipUint32(FileStream stream) => SkipUint32(stream, 1);
            public static void SkipUint32(FileStream stream, int times) => stream.Seek(4 * times, SeekOrigin.Current);

            public static string ReadString(FileStream stream)
            {
                uint strLength = ReadUint32(stream);
                return ReadString(stream, strLength);
            }

            public static string ReadString(FileStream stream, uint length)
            {
                byte[] strBuffer = new byte[length];
                stream.Read(strBuffer, 0, (int)length);
                return Encoding.UTF8.GetString(strBuffer);
            }

            public static void SkipString(FileStream stream) => SkipString(stream, 1);
            public static void SkipString(FileStream stream, int times)
            {
                for (int i = 0; i < times; i++)
                {
                    uint strLength = ReadUint32(stream);
                    stream.Seek(strLength, SeekOrigin.Current);
                }
            }

            public static void SkipBytes(FileStream stream, int bytesAmount) => stream.Seek(bytesAmount, SeekOrigin.Current);
        }
    }
}