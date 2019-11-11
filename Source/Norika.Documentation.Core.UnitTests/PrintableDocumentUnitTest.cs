using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Norika.Documentation.Core.FileSystem.Interfaces;
using Norika.Documentation.Core.Types;

namespace Norika.Documentation.Core.UnitTests
{
    [TestClass]
    public class PrintableDocumentUnitTest
    {
        [TestMethod]
        public void NewDocument_WithExistentPrintableDocumentTypeAndTitle_ShouldCallSetTitleOnPrintableDocument()
        {
            var testPrintableDocument = new Mock<ITestPrintableDocument>();

            var documentBuilderMock = new Mock<IFormattableDocumentBuilder>();
            documentBuilderMock.Setup(db => db.Build<ITestPrintableDocument>()).Returns(testPrintableDocument.Object);
            testPrintableDocument.SetupSet(tpd => tpd.Title = It.IsAny<string>()).Verifiable();

            var document = new PrintableDocument<ITestPrintableDocument>(documentBuilderMock.Object);

            document.Create("Title");

            testPrintableDocument.VerifySet(tpd => tpd.Title = It.Is<string>(s => s.Equals("Title")));
        }

        [TestMethod]
        public void
            NewDocument_WithDefaultEmptyConstructor_ShouldInitializeDocumentBuilderAndFileWriterAndNotThrowException()
        {
            var document = new PrintableDocument<ITestPrintableDocument>();

            var printableDocument = document.Create("Test");

            Assert.AreEqual("Test", printableDocument.Title);
        }

        [TestMethod]
        public void NewDocument_WithExistentPrintableDocumentType_ShouldCallCreateMethodOnFactory()
        {
            var testPrintableDocument = new Mock<ITestPrintableDocument>();

            var documentBuilderMock = new Mock<IFormattableDocumentBuilder>();
            documentBuilderMock.Setup(db => db.Build<ITestPrintableDocument>()).Returns(testPrintableDocument.Object);

            var document = new PrintableDocument<ITestPrintableDocument>(documentBuilderMock.Object);

            document.Create("Title");

            documentBuilderMock.Verify(db => db.Build<ITestPrintableDocument>(), Times.Exactly(1));
        }

        [TestMethod]
        public void Save_WithPath_CallFileWriterSaveWithCorrectPath()
        {
            var outPath = "/usr/desktop";

            var fileWriterMock = new Mock<IFileWriter>();

            var document =
                new PrintableDocument<ITestPrintableDocument>(fileWriterMock.Object);

            var formattableDocument = document.Create("Title");

            document.Save(outPath, formattableDocument);

            fileWriterMock.Verify(fw => fw.WriteAllText(It.Is<string>(s => s.Equals(outPath)), It.IsAny<string>()));
        }
        
        [TestMethod]
        public void Save_WithPathFromPrintableDocument_CallFileWriterSaveWithCorrectPath()
        {
            var outPath = "/usr/desktop";

            var fileWriterMock = new Mock<IFileWriter>();

            var document =
                new PrintableDocument<ITestPrintableDocument>(fileWriterMock.Object);

            IPrintableDocument formattableDocument = document.Create("Title");

            document.Save(outPath, formattableDocument);

            fileWriterMock.Verify(fw => fw.WriteAllText(It.Is<string>(s => s.Equals(outPath)), It.IsAny<string>()));
        }

        [TestMethod]
        public void Save_WithValueOnPrint_CallFileWriterSaveWithCorrectFileContent()
        {
            var outPath = "/usr/desktop";
            var testPrintValue = "value";

            var testPrintableDocument = new Mock<ITestPrintableDocument>();
            testPrintableDocument.Setup(x => x.Print()).Returns(testPrintValue);

            var documentBuilderMock = new Mock<IFormattableDocumentBuilder>();
            documentBuilderMock.Setup(db => db.Build<ITestPrintableDocument>()).Returns(testPrintableDocument.Object);

            var fileWriterMock = new Mock<IFileWriter>();

            var document =
                new PrintableDocument<ITestPrintableDocument>(documentBuilderMock.Object, fileWriterMock.Object);

            var formattableDocument = document.Create("Title");

            document.Save(outPath, formattableDocument);

            fileWriterMock.Verify(fw =>
                fw.WriteAllText(It.IsAny<string>(), It.Is<string>(s => s.Equals(testPrintValue))));
        }
    }
}