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
        public void Title_SetWithTestValue_ShouldSetValue()
        {
            Mock<IPrintableMarkdownElementFactory> markdownElementFactory = 
                new Mock<IPrintableMarkdownElementFactory>();
            
            MarkdownParagraph document = new MarkdownParagraph("Title",
                markdownElementFactory.Object);
            
            Assert.AreEqual("Title", document.Title);
        }
    }
}