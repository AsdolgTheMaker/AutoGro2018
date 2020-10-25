using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using AutoGro;

namespace ParserTests
{
    [TestClass]
    public class StructReaders
    {
        [TestMethod]
        public void ReadRFIL()
        {
            string projectDirectory = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            SeriousStream fileStream = new SeriousStream(projectDirectory + "/files/RFIL.bin", FileMode.Open, FileAccess.Read);

            // skid RFIL id
            fileStream.Seek(4, SeekOrigin.Current);

            // read the file
            List<string> RFIL = fileStream.ReadStruct(SeriousStream.StructType.RFIL);

            fileStream.Dispose();

            Assert.IsTrue(RFIL.Count > 0, "RFIL collection was read as empty.");

            File.WriteAllLines(projectDirectory + "/files/RFIL_output.txt", RFIL);
        }

        [TestMethod]
        public void ConvertIdentifiersToNumbers()
        {
            string projectDirectory = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
            SeriousStream fileStream = new SeriousStream(projectDirectory + "/files/Identifiers.txt", FileMode.Open, FileAccess.Read);

            // File contents:
            //  SIGSTRM1
            //  WRKSTRM1
            //  CTSEMETA
            //  INFO
            //  RFIL
            //  MSGS

            // read the file
            uint SIGS = fileStream.ReadUint32();
            uint TRM1 = fileStream.ReadUint32();
            uint WRKS = fileStream.ReadUint32();
            fileStream.SkipUint32();
            uint CTSE = fileStream.ReadUint32();
            uint META = fileStream.ReadUint32();
            uint INFO = fileStream.ReadUint32();
            uint RFIL = fileStream.ReadUint32();
            uint MSGS = fileStream.ReadUint32();

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

        [TestMethod]
        public void ParseFile()
        {
            Log log = new Log("LOG_ParseFile.log");
            string projectDirectory = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;

            // TestWLD_01
            List<string> RFIL = new List<string>();
            Asset testWld01 = new Asset(projectDirectory + "/files/TestWLD_01.wld", log);
            bool success = testWld01.TryParse(out RFIL, null);
            if (success)
            {
                RFIL.Insert(0, RFIL.Count.ToString());
                File.WriteAllLines(projectDirectory + "/files/TestWLD_01_RFIL.txt", RFIL);
            }
            else Assert.Fail("Unable to read binary file TestWLD_01.wld.");
            
            // TestWLD_02
            RFIL = new List<string>();
            Asset testWld02 = new Asset(projectDirectory + "/files/TestWLD_02.wld", log);
            success = testWld02.TryParse(out RFIL, null);
            if (success)
            {
                RFIL.Insert(0, RFIL.Count.ToString());
                File.WriteAllLines(projectDirectory + "/files/TestWLD_02_RFIL.txt", RFIL);
            }
            else Assert.Fail("Unable to read binary file TestWLD_02.wld.");
            
            // TestMDL_01
            RFIL = new List<string>();
            Asset testMdl01 = new Asset(projectDirectory + "/files/TestMDL_01.mdl", log);
            success = testMdl01.TryParse(out RFIL, log);
            if (success)
            {
                RFIL.Insert(0, RFIL.Count.ToString());
                File.WriteAllLines(projectDirectory + "/files/TestMDL_01_RFIL.txt", RFIL);
            }
            else Assert.Fail("Unable to read binary file TestMDL_01.md;.");
        }
    }
}