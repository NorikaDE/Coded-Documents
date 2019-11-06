using Norika.Documentation.Markdown;
using Norika.Documentation.Core.Types;
using Norika.Documentation.Markdown.Container;
using Norika.Documentation.Markdown.Container.Interfaces;
using Norika.Documentation.Markdown.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Norika.Documentation.Markdown.UnitTests.TestTypes.Interfaces;

namespace Norika.Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownElementFactoryUnitTest
    {
        [TestMethod]
        public void CreateElement_FromIFormattableDocumentChapterStringContent_ShouldReturnInstanceOfMarkdownChapterString()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IPrintableDocumentChapterStringContent chapterStringContent =
                factory.CreateElement<IPrintableDocumentChapterStringContent>();
            
            Assert.IsInstanceOfType(chapterStringContent, typeof(MarkdownChapterStringContent));
        }
        
        [TestMethod]
        public void CreateElement_FromIFormattableParagraphTableContent_ShouldReturnInstanceOfMarkdownChapterString()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IPrintableParagraphTable chapterStringContent =
                factory.CreateElement<IPrintableParagraphTable>();
            
            Assert.IsInstanceOfType(chapterStringContent, typeof(MarkdownTable));
        }
        
        [TestMethod]
        public void CreateElement_FromContainerType_ShouldReturnDefaultValueNull()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IMarkdownParagraph element =
                factory.CreateElement<IMarkdownParagraph>();
            
            Assert.IsNull(element);
        }
        
        [TestMethod]
        public void CreateElement_FromBaseTypeIPrintable_ShouldReturnDefaultValueNull()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            ITestContainer element =
                factory.CreateMarkdownContainer<ITestContainer>("Test");
            
            Assert.IsNull(element);
        }
        
        [TestMethod]
        public void CreateMarkdownContainer_FromIMarkdownParagraph_ShouldReturnInstanceOfMarkdownParagraph()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IMarkdownParagraph paragraph =
                factory.CreateMarkdownContainer<IMarkdownParagraph>("Test");
            
            Assert.IsInstanceOfType(paragraph, typeof(MarkdownParagraph));
        }
        
        [TestMethod]
        public void CreateElement_FromIDocumentCodeBlockContent_ShouldReturnInstanceOfMarkdownChapterString()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IPrintableDocumentCodeBlock chapterStringContent =
                factory.CreateElement<IPrintableDocumentCodeBlock>();
            
            Assert.IsInstanceOfType(chapterStringContent, typeof(MarkdownCodeBlock));
        }
        
        [TestMethod]
        public void CreateMarkdownContainer_FromMarkdownSite_ShouldReturnInstanceOfMarkdownSite()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IHeaderContainer returnValue =
                factory.CreateMarkdownContainer<IMarkdownSite>("Test");
            
            Assert.IsInstanceOfType(returnValue, typeof(MarkdownSite));
        }
        
        [TestMethod]
        public void CreateMarkdownContainer_FromMarkdownDocument_ShouldReturnInstanceOfMarkdownDocument()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IHeaderContainer returnValue =
                factory.CreateMarkdownContainer<IMarkdownDocument>("Test");
            
            Assert.IsInstanceOfType(returnValue, typeof(MarkdownDocument));
        }
        
        [TestMethod]
        public void CreateMarkdownContainer_FromMarkdownDocumentWithHeader_ShouldReturnObjectWithHeader()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IHeaderContainer returnValue =
                factory.CreateMarkdownContainer<IMarkdownDocument>("Test");
            
            Assert.AreEqual("Test", returnValue.HeaderContent);
        }
        
        [TestMethod]
        public void CreateMarkdownContainer_FromMarkdownDocument_ShouldReturnObjectWithHeader()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IHeaderContainer returnValue =
                factory.CreateMarkdownContainer<IMarkdownSite>("Test");
            
            Assert.AreEqual("Test", returnValue.HeaderContent);
        }
        
        [TestMethod]
        public void CreateMarkdownContainer_FromNotImplementedContainerType_ShouldReturnDefaultValue()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IHeaderContainer returnValue =
                factory.CreateMarkdownContainer<INotExistentContainer>("Test");
            
            Assert.AreEqual(default(INotExistentContainer), returnValue);
        }
        
        [TestMethod]
        public void CreateMarkdownElement_FromNotImplementedElementType_ShouldReturnDefaultValue()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IPrintable returnValue =
                factory.CreateElement<INotExistentElement>();
            
            Assert.AreEqual(default(INotExistentElement), returnValue);
        }
        
        [TestMethod]
        public void CreateMarkdownElement_FromIPrintableDocumentParagraphHyperlink_ShouldReturnMarkdownHyperlinObject()
        {
            MarkdownElementFactory factory = new MarkdownElementFactory();

            IPrintable returnValue =
                factory.CreateElement<IPrintableDocumentParagraphHyperlink>();
            
            Assert.IsInstanceOfType(returnValue, typeof(MarkdownHyperlink));
        }
    }
}