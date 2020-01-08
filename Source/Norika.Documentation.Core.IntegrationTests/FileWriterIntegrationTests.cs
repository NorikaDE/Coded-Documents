using System;
using System.Collections.Generic;
using System.IO;
using Norika.Documentation.Core.FileSystem;
using Norika.Documentation.Core.FileSystem.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Norika.Documentation.Core.IntegrationTests
{
    [TestClass]
    public class FileWriterIntegrationTests
    {
        private static TestContext _context;

        private static DirectoryInfo TestRunDirectory;

        private DirectoryInfo CurrentTestOutDirectory;
        
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _context = context;

            string testRunIdentifier = $"IntegrationTest_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}";
            string testRunDirectoryPath = Path.Combine(Path.GetTempPath(), testRunIdentifier);

            TestRunDirectory = Directory.CreateDirectory(testRunDirectoryPath);
        }
        
        [ClassCleanup]
        public static void ClassCleanUp()
        {

        }

        [TestInitialize]
        public void InitializeTest()
        {
            CurrentTestOutDirectory = TestRunDirectory.CreateSubdirectory(_context.TestName);
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            if (_context.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                CurrentTestOutDirectory.Delete(true);
            }
        }
        
        [TestMethod]
        public void WriteAllText_WithExistentFilePath_ShouldCreateFile()
        {
            IFileWriter fileWriter = new FileWriter();
            string outFileName = "TestFile.txt";
            string outFilePath = Path.Combine(CurrentTestOutDirectory.FullName, outFileName);

            fileWriter.WriteAllText(outFilePath, string.Empty);
            
            Assert.IsTrue(File.Exists(outFilePath));
        }
      
        [TestMethod]
        public void WriteAllText_WithExistentFilePathAndContent_ShouldCreateFileWithContent()
        {
            IFileWriter fileWriter = new FileWriter();
            string outFileName = "TestFile.txt";
            string outFileContent = "Test";
            string outFilePath = Path.Combine(CurrentTestOutDirectory.FullName, outFileName);

            fileWriter.WriteAllText(outFilePath, outFileContent);
            
            Assert.IsTrue(File.Exists(outFilePath));
            Assert.AreEqual(outFileContent, File.ReadAllText(outFilePath));
        }
        
        [TestMethod]
        public void WriteAllLines_WithExistentFilePathAndContent_ShouldCreateFileWithContent()
        {
            IFileWriter fileWriter = new FileWriter();
            string outFileName = "TestFile.txt";
            IList<string> outFileContent = new List<string>() { "TestLine1", "TestLine2"};
            string outFilePath = Path.Combine(CurrentTestOutDirectory.FullName, outFileName);

            fileWriter.WriteAllLines(outFilePath, outFileContent);
            
            Assert.IsTrue(File.Exists(outFilePath));
            Assert.AreEqual(outFileContent[0], File.ReadAllLines(outFilePath)[0]);
            Assert.AreEqual(outFileContent[1], File.ReadAllLines(outFilePath)[1]);
        }
    }
}