using System.Collections.Generic;
using Documentation.Core.Types;
using Documentation.Markdown.Container;
using Documentation.Markdown.Container.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Documentation.Markdown.UnitTest
{
    [TestClass]
    public class MarkdownDocumentUnitTest
    {

        [TestMethod]
        public void Title_SetWithTestValue_ShouldSetValue()
        {
            MarkdownDocument document = new MarkdownDocument {Title = "Title"};
            
            Assert.AreEqual("Title", document.Title);
        }
        
        [TestMethod]
        public void Author_SetWithTestValue_ShouldSetValue()
        {
            MarkdownDocument document = new MarkdownDocument {Author = "Author"};
            
            Assert.AreEqual("Author", document.Author);
        }
        
        [TestMethod]
        public void Chapters_InitializeObject_ShouldInitializeEmptyList()
        {
            MarkdownDocument document = new MarkdownDocument();
            
            Assert.AreEqual(0, document.Chapters.Count);
        }
        
        [TestMethod]
        public void Print_WithTitleAndChapter_ShouldPrintExpectedMarkdownFormat()
        {
            Mock<IPrintable> printableMock = new Mock<IPrintable>();
            printableMock.Setup(x => x.Print()).Returns("Content");
            
            Mock<IPrintableDocumentChapter> chapterMock = new Mock<IPrintableDocumentChapter>();
            chapterMock.Setup(x => x.Title).Returns("SubTitle");
            chapterMock.Setup(x => x.Content).Returns(new List<IPrintable>(){ printableMock.Object });
            chapterMock.Setup(x => x.Print()).Returns("## SubTitle\nContent");
            
            MarkdownDocument document = new MarkdownDocument {Title = "Title"};
            document.AddChapter(chapterMock.Object);

            Assert.AreEqual("# Title\n## SubTitle\nContent", document.Print());
        }
        
        [TestMethod]
        public void Print_WithTitle_ShouldPrintExpectedMarkdownFormat()
        {
            MarkdownDocument document = new MarkdownDocument {Title = "Title"};

            Assert.AreEqual("# Title", document.Print());
        }
        
        [TestMethod]
        public void SetHeaderBuilder_WithMockedObject_ShouldCallMockOnPrintExactlyOnce()
        {
            Mock<IMarkdownHeaderBuilder> headerBuilderMock = new Mock<IMarkdownHeaderBuilder>();
            
            MarkdownDocument document = new MarkdownDocument {Title = "Title"};
            document.SetHeaderBuilder(headerBuilderMock.Object);

            document.Print();
            
            headerBuilderMock.Verify(x => x.CreateHeader(
                It.Is<string>(s => s.Equals("Title"))), Times.Exactly(1)
                );
        }
        
        [TestMethod]
        public void AddNewChapter_WithTitleAndImplementedType_ShouldCallFactoryForExpectedType()
        {
            Mock<IMarkdownSite> markdownSiteMock = new Mock<IMarkdownSite>();

            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            elementFactoryMock
                .Setup(x => x.CreateMarkdownContainer<IMarkdownSite>(It.Is<string>(s => s.Equals("Chapter"))))
                .Returns(markdownSiteMock.Object);
            
            MarkdownDocument document = new MarkdownDocument("Title", elementFactoryMock.Object);

            document.AddNewChapter("Chapter");
            
            elementFactoryMock
                .Verify(x => x.CreateMarkdownContainer<IMarkdownSite>(
                    It.Is<string>(s => s.Equals("Chapter"))
                    ), Times.Exactly(1));
        }
        
    }
}