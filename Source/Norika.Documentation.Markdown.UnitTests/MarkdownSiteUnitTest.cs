using Norika.Documentation.Markdown;
using Norika.Documentation.Core.Types;
using Norika.Documentation.Markdown.Container;
using Norika.Documentation.Markdown.Container.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Norika.Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownSiteUnitTest
    {
        [TestMethod]
        public void Create_WithTitle_ShouldSetTitle()
        {
            
            MarkdownSite site = new MarkdownSite("Test");
            
            Assert.AreEqual("Test", site.Title);
        }   
        
        [TestMethod]
        public void AddNewContent_WithParagraphHyperlink_ShouldCallFactoryForCreateAParagraphHyperlink()
        {
            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            
            MarkdownSite site = new MarkdownSite("Test", elementFactoryMock.Object);

            site.AddNewContent<IPrintableDocumentParagraphHyperlink>();
            
            elementFactoryMock.Verify(f => f.CreateElement<IPrintableDocumentParagraphHyperlink>(), Times.Exactly(1));
        }   
        
        [TestMethod]
        public void AddNewParagraph_WithParagraphTitle_ShouldCallFactoryForCreateANewParagraphWithTheGivenTitle()
        {
            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            Mock<IMarkdownParagraph> markdownParagraphMock = new Mock<IMarkdownParagraph>();
            elementFactoryMock.Setup(f => f.CreateMarkdownContainer<IMarkdownParagraph>(It.IsAny<string>()))
                .Returns(markdownParagraphMock.Object);
            Mock<IMarkdownHeaderBuilder> headerBuilderMock = new Mock<IMarkdownHeaderBuilder>();
            
            MarkdownSite site = new MarkdownSite("Test", elementFactoryMock.Object, headerBuilderMock.Object);

            site.AddNewParagraph("Paragraph");
            
            elementFactoryMock.Verify(f => f.CreateMarkdownContainer<IMarkdownParagraph>(
                It.Is((string s) => s.Equals("Paragraph"))), Times.Exactly(1));
        }   
        
        [TestMethod]
        public void AddNewParagraph_WithParagraphTitle_ShouldSetHeaderBuilderToNewCreatedObject()
        {
            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            Mock<IMarkdownParagraph> markdownParagraphMock = new Mock<IMarkdownParagraph>();
            elementFactoryMock.Setup(f => f.CreateMarkdownContainer<IMarkdownParagraph>(It.IsAny<string>()))
                .Returns(markdownParagraphMock.Object);
            Mock<IMarkdownHeaderBuilder> headerBuilderMock = new Mock<IMarkdownHeaderBuilder>();
            
            MarkdownSite site = new MarkdownSite("Test", elementFactoryMock.Object, headerBuilderMock.Object);

            site.AddNewParagraph("Paragraph");
            
            markdownParagraphMock.Verify(p => p.SetHeaderBuilder(It.IsAny<IMarkdownHeaderBuilder>()));
        }   
        
        [TestMethod]
        public void AddNewParagraph_WithParagraphTitle_ShouldCloneTheHeaderBuilderOfTheCurrentObject()
        {
            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            Mock<IMarkdownParagraph> markdownParagraphMock = new Mock<IMarkdownParagraph>();
            elementFactoryMock.Setup(f => f.CreateMarkdownContainer<IMarkdownParagraph>(It.IsAny<string>()))
                .Returns(markdownParagraphMock.Object);
            Mock<IMarkdownHeaderBuilder> headerBuilderMock = new Mock<IMarkdownHeaderBuilder>();
            
            MarkdownSite site = new MarkdownSite("Test", elementFactoryMock.Object, headerBuilderMock.Object);

            site.AddNewParagraph("Paragraph");
            
            headerBuilderMock.Verify(hb => hb.Clone(), Times.Exactly(1));
        }   
        
        [TestMethod]
        public void Print_WithHeaderBuilderAndSetTitle_ShouldPrintTheHeaderSpecifiedByHeaderBuilder()
        {
            string expectedHeaderValue = "This is the header \"Test\"";
            string inputHeaderValue = "Test";
            
            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            Mock<IMarkdownHeaderBuilder> headerBuilderMock = new Mock<IMarkdownHeaderBuilder>();
            headerBuilderMock.Setup(
                x => x.CreateHeader(It.Is<string>(s => s.Equals(inputHeaderValue)))
                ).Returns(expectedHeaderValue);
            
            
            MarkdownSite site = new MarkdownSite(inputHeaderValue, elementFactoryMock.Object);
            
            site.SetHeaderBuilder(headerBuilderMock.Object);
            
            
            Assert.AreEqual($"{expectedHeaderValue}\n", site.Print());
            
            //elementFactoryMock.Verify(f => f.CreateElement<IDocumentParagraphHyperlink>(), Times.Exactly(1));
        }   
        
        [TestMethod]
        public void Print_WithHeaderBuilderAndSetTitle_ShouldCallHeaderBuilderWithGivenTitleExactlyOnce()
        {
            // region 1) Arrange
            string inputHeaderValue = "Test";

            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            Mock<IMarkdownHeaderBuilder> headerBuilderMock = new Mock<IMarkdownHeaderBuilder>();

            MarkdownSite site = new MarkdownSite(inputHeaderValue, elementFactoryMock.Object);
            
            // region 2) Act
            site.SetHeaderBuilder(headerBuilderMock.Object);
            site.Print();

            // region 3) Assert
            headerBuilderMock.Verify(
                hb => hb.CreateHeader(It.Is<string>(s => s.Equals(inputHeaderValue))
                ), Times.Exactly(1));
        }
        
        [TestMethod]
        public void Print_WithThreeCodeBlockChildItems_ShouldCallPrintOnEveryChildItem()
        {
            // region 1) Arrange
            string inputHeaderValue = "Test";

            Mock<IPrintableDocumentCodeBlock> codeBlockMock = new Mock<IPrintableDocumentCodeBlock>();
            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            elementFactoryMock.Setup(f => f.CreateElement<IPrintableDocumentCodeBlock>()).Returns(codeBlockMock.Object);
            Mock<IMarkdownHeaderBuilder> headerBuilderMock = new Mock<IMarkdownHeaderBuilder>();

            MarkdownSite site = new MarkdownSite(inputHeaderValue, elementFactoryMock.Object);
            site.SetHeaderBuilder(headerBuilderMock.Object);
            
            site.AddNewContent<IPrintableDocumentCodeBlock>();
            site.AddNewContent<IPrintableDocumentCodeBlock>();
            site.AddNewContent<IPrintableDocumentCodeBlock>();
            
            // region 2) Act
            site.Print();

            // region 3) Assert
            codeBlockMock.Verify(cb => cb.Print(), Times.Exactly(3));
        }
    }
}