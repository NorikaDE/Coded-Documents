using Documentation.Markdown.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Documentation.Markdown.UnitTest
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