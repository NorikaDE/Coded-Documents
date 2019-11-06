using Norika.Documentation.Markdown.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Norika.Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownChapterStringContentUnitTest
    {
        [TestMethod]
        public void Print_WithSetInputTestValue_ShouldAddTestValue()
        {
            MarkdownChapterStringContent content = new MarkdownChapterStringContent {Content = "test"};

            Assert.AreEqual("test", content.Content);
        }
        
        [TestMethod]
        public void Print_WithInputTestValue_ShouldPrintExactlyLikeInput()
        {
            MarkdownChapterStringContent content = new MarkdownChapterStringContent {Content = "test"};

            Assert.AreEqual("test", content.Print());
        }
        
    }
}