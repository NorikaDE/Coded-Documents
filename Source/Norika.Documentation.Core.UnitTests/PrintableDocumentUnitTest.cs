using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Norika.Documentation.Core.FileSystem.Interfaces;

namespace Norika.Documentation.Core.UnitTests
{
    [TestClass]
    public class PrintableDocumentUnitTest
    {
        [TestMethod]
        public void NewDocument_WithExistentPrintableDocumentTypeAndTitle_ShouldCallSetTitleOnPrintableDocument()
        {
            Mock<ITestPrintableDocument> testPrintableDocument = new Mock<ITestPrintableDocument>();
            
            Mock<IFormattableDocumentBuilder> documentBuilderMock = new Mock<IFormattableDocumentBuilder>();
            documentBuilderMock.Setup(db => db.Build<ITestPrintableDocument>()).Returns(testPrintableDocument.Object);
            testPrintableDocument.SetupSet(tpd => tpd.Title = It.IsAny<string>()).Verifiable();
                
            PrintableDocument<ITestPrintableDocument> document = new PrintableDocument<ITestPrintableDocument>(documentBuilderMock.Object);
            
            document.Create("Title");
            
            testPrintableDocument.VerifySet(tpd => tpd.Title = It.Is<string>(s => s.Equals("Title")));
        }

        [TestMethod]
        public void NewDocument_WithDefaultEmptyConstructor_ShouldInitializeDocumentBuilderAndFileWriterAndNotThrowException()
        {
            PrintableDocument<ITestPrintableDocument> document = new PrintableDocument<ITestPrintableDocument>();

            ITestPrintableDocument printableDocument = document.Create("Test");
            
            Assert.AreEqual("Test", printableDocument.Title);
        }
        
        [TestMethod]
        public void NewDocument_WithExistentPrintableDocumentType_ShouldCallCreateMethodOnFactory()
        {
            Mock<ITestPrintableDocument> testPrintableDocument = new Mock<ITestPrintableDocument>();
            
            Mock<IFormattableDocumentBuilder> documentBuilderMock = new Mock<IFormattableDocumentBuilder>();
            documentBuilderMock.Setup(db => db.Build<ITestPrintableDocument>()).Returns(testPrintableDocument.Object);

            PrintableDocument<ITestPrintableDocument> document = new PrintableDocument<ITestPrintableDocument>(documentBuilderMock.Object);
            
            document.Create("Title");
            
           documentBuilderMock.Verify(db => db.Build<ITestPrintableDocument>(), Times.Exactly(1));
        }
        
        [TestMethod]
        public void Save_WithPath_CallFileWriterSaveWithCorrectPath()
        {
            string outPath = "/usr/desktop";

            Mock<IFileWriter> fileWriterMock = new Mock<IFileWriter>();
            
            PrintableDocument<ITestPrintableDocument> document = 
                new PrintableDocument<ITestPrintableDocument>(fileWriterMock.Object);
            
            ITestPrintableDocument formattableDocument = document.Create("Title");

            document.Save(outPath, formattableDocument);
            
            fileWriterMock.Verify(fw => fw.WriteAllText(It.Is<string>(s => s.Equals(outPath)), It.IsAny<string>()));
        }
        
        [TestMethod]
        public void Save_WithValueOnPrint_CallFileWriterSaveWithCorrectFileContent()
        {
            string outPath = "/usr/desktop";
            string testPrintValue = "value";
            
            Mock<ITestPrintableDocument> testPrintableDocument = new Mock<ITestPrintableDocument>();
            testPrintableDocument.Setup(x => x.Print()).Returns(testPrintValue);
            
            Mock<IFormattableDocumentBuilder> documentBuilderMock = new Mock<IFormattableDocumentBuilder>();
            documentBuilderMock.Setup(db => db.Build<ITestPrintableDocument>()).Returns(testPrintableDocument.Object);

            Mock<IFileWriter> fileWriterMock = new Mock<IFileWriter>();
            
            PrintableDocument<ITestPrintableDocument> document = 
                new PrintableDocument<ITestPrintableDocument>(documentBuilderMock.Object, fileWriterMock.Object);
            
            ITestPrintableDocument formattableDocument = document.Create("Title");

            document.Save(outPath, formattableDocument);
            
            fileWriterMock.Verify(fw => fw.WriteAllText(It.IsAny<string>(), It.Is<string>(s => s.Equals(testPrintValue))));
        }
        
       
    }
}