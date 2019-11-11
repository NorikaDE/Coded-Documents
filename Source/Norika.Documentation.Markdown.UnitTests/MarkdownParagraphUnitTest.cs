using System.Collections.Generic;
using Norika.Documentation.Markdown;
using Norika.Documentation.Core.Types;
using Norika.Documentation.Markdown.Container;
using Norika.Documentation.Markdown.Container.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Norika.Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownParagraphUnitTest
    {
        [TestMethod]
        public void Create_WithTitleTestValue_ShouldSetValue()
        {
            Mock<IPrintableMarkdownElementFactory> markdownElementFactory = 
                new Mock<IPrintableMarkdownElementFactory>();
            
            MarkdownParagraph document = new MarkdownParagraph("Title",
                markdownElementFactory.Object);
            
            Assert.AreEqual("Title", document.Title);
        }
        
        [TestMethod]
        public void Print_WithTitleTestValue_ShouldReturnExpectedMarkdownFormat()
        {
            Mock<IPrintableMarkdownElementFactory> markdownElementFactory = 
                new Mock<IPrintableMarkdownElementFactory>();
            
            MarkdownParagraph document = new MarkdownParagraph("Title",
                markdownElementFactory.Object);
            
            Assert.AreEqual("# Title", document.Print());
        }
        
        [TestMethod]
        public void HeaderContent_FromInitializedObject_ShouldValueFromObjectTitle()
        {
            Mock<IPrintableMarkdownElementFactory> markdownElementFactory = 
                new Mock<IPrintableMarkdownElementFactory>();
            
            MarkdownParagraph document = new MarkdownParagraph("Title",
                markdownElementFactory.Object);
            
            Assert.AreEqual("Title", document.HeaderContent);
        }
        
        [TestMethod]
        public void Print_WithThreePrintableContentItems_ShouldCallPrintForEachItem()
        {
            Mock<IPrintableMarkdownElementFactory> markdownElementFactory = 
                new Mock<IPrintableMarkdownElementFactory>();
            
            Mock<IPrintable> printableMock = new Mock<IPrintable>();
            
            MarkdownParagraph document = new MarkdownParagraph("Title",
                markdownElementFactory.Object);
            
            document.Content.Add(printableMock.Object);
            document.Content.Add(printableMock.Object);
            document.Content.Add(printableMock.Object);

            document.Print();
            
            printableMock.Verify(pm => pm.Print(), Times.Exactly(3));
        }
        
        [TestMethod]
        public void AddNewContent_FromInterfaceIPrintableParagraphTable_CallMatchingMethodOnElementFactory()
        {
            Mock<IPrintableMarkdownElementFactory> markdownElementFactory = 
                new Mock<IPrintableMarkdownElementFactory>();
            
            MarkdownParagraph document = new MarkdownParagraph("Title",
                markdownElementFactory.Object);

            document.AddNewContent<IPrintableParagraphTable>();
            
            markdownElementFactory.Verify(ef => ef.CreateElement<IPrintableParagraphTable>(), Times.Exactly(1));
        }
    }
}