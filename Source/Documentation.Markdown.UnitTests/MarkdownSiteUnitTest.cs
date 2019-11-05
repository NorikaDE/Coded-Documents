using Documentation.Core.Types;
using Documentation.Markdown.Container;
using Documentation.Markdown.Container.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownSiteUnitTest
    {
        [TestMethod]
        public void AddNewContent_WithParagraphHyperlink_ShouldCallFactoryForCreateAParagraphHyperlink()
        {
            Mock<IPrintableMarkdownElementFactory> elementFactoryMock = new Mock<IPrintableMarkdownElementFactory>();
            
            MarkdownSite site = new MarkdownSite("Test", elementFactoryMock.Object);

            site.AddNewContent<IPrintableDocumentParagraphHyperlink>();
            
            elementFactoryMock.Verify(f => f.CreateElement<IPrintableDocumentParagraphHyperlink>(), Times.Exactly(1));
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