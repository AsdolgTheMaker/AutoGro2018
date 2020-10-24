using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoGro;
using System.Collections.Generic;

namespace ParserTests
{
    [TestClass]
    public class StructReaders
    {
        [TestMethod]
        public void ReadRFIL()
        {
            string projectDirectory = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            FileStream fileStream = new FileStream(projectDirectory + "/files/RFIL.bin", FileMode.Open, FileAccess.Read);

            // skid RFIL id
            fileStream.Seek(4, SeekOrigin.Current);

            // read the file
            List<string> RFIL = BinaryParser.SeriousUniversalContainer.ReadStruct(fileStream, BinaryParser.SeriousUniversalContainer.StructType.RFIL);

            fileStream.Dispose();

            Assert.IsTrue(RFIL.Count > 0, "RFIL collection was read as empty.");

            File.WriteAllLines(projectDirectory + "/files/RFIL_output.txt", RFIL);
        }

        [TestMethod]
        public void ReadMSGS()
        {
            string projectDirectory = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            FileStream fileStream = new FileStream(projectDirectory + "/files/MSGS.bin", FileMode.Open, FileAccess.Read);

            // skid MSGS id
            fileStream.Seek(4, SeekOrigin.Current);

            // read the file
            BinaryParser.SeriousUniversalContainer.ReadStruct(fileStream, BinaryParser.SeriousUniversalContainer.StructType.MSGS);

            fileStream.Dispose();
        }

        [TestMethod]
        public void ReadSignature() // SIGSTRM1 + WRKSTRM1
        {
            string projectDirectory = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            FileStream fileStream = new FileStream(projectDirectory + "/files/SIGNATURE.bin", FileMode.Open, FileAccess.Read);

            // skid MSGS id
            fileStream.Seek(4, SeekOrigin.Current);

            // read the file
            BinaryParser.SeriousUniversalContainer.ReadStruct(fileStream, BinaryParser.SeriousUniversalContainer.StructType.SIGSTRM1);
            BinaryParser.SeriousUniversalContainer.ReadStruct(fileStream, BinaryParser.SeriousUniversalContainer.StructType.WRKSTRM1);

            fileStream.Dispose();
        }

        [TestMethod]
        public void ConvertIdentifiersToNumbers()
        {
            string projectDirectory = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            FileStream fileStream = new FileStream(projectDirectory + "/files/Identifiers.txt", FileMode.Open, FileAccess.Read);

            // File contents:
            //  SIGSTRM1
            //  WRKSTRM1
            //  CTSEMETA
            //  INFO
            //  RFIL
            //  MSGS

            // read the file
            uint SIGS = BinaryParser.SeriousUniversalContainer.ReadUint32(fileStream);
            uint TRM1 = BinaryParser.SeriousUniversalContainer.ReadUint32(fileStream);
            uint WRKS = BinaryParser.SeriousUniversalContainer.ReadUint32(fileStream);
            BinaryParser.SeriousUniversalContainer.SkipUint32(fileStream);
            uint CTSE = BinaryParser.SeriousUniversalContainer.ReadUint32(fileStream);
            uint META = BinaryParser.SeriousUniversalContainer.ReadUint32(fileStream);
            uint INFO = BinaryParser.SeriousUniversalContainer.ReadUint32(fileStream);
            uint RFIL = BinaryParser.SeriousUniversalContainer.ReadUint32(fileStream);
            uint MSGS = BinaryParser.SeriousUniversalContainer.ReadUint32(fileStream);

            fileStream.Dispose();

            File.WriteAllLines(projectDirectory + "/files/Identifiers_uint.txt",
                new List<string>()
                {
                    "SIGS = " + SIGS.ToString() + " = " + SIGS.ToString("X") + "\n" +
                    "TRM1 = " + TRM1.ToString() + " = " + TRM1.ToString("X") + "\n" +
                    "WRKS = " + WRKS.ToString() + " = " + WRKS.ToString("X") + "\n" +
                    "CTSE = " + CTSE.ToString() + " = " + CTSE.ToString("X") + "\n" +
                    "META = " + META.ToString() + " = " + META.ToString("X") + "\n" +
                    "INFO = " + INFO.ToString() + " = " + INFO.ToString("X") + "\n" +
                    "RFIL = " + RFIL.ToString() + " = " + RFIL.ToString("X") + "\n" +
                    "MSGS = " + MSGS.ToString() + " = " + MSGS.ToString("X")
                }
            );
        }
    }
}