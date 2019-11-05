using Documentation.Markdown.Container.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Documentation.Markdown.UnitTest
{
    [TestClass]
    public class MarkdownBuilderUnitTest
    {
        [TestMethod]
        public void CreateHeader_WithInitialDepth_ShouldCreateHeaderWithOneHashTag()
        {
            IMarkdownHeaderBuilder builder = new MarkdownHeaderBuilder();

            string header = builder.CreateHeader("Test");
            
            Assert.AreEqual("# Test", header);
        }
        
        [TestMethod]
        public void Clone_OfObject_ShouldIncreaseDepthByOne()
        {
            IMarkdownHeaderBuilder builder = new MarkdownHeaderBuilder();
            IMarkdownHeaderBuilder clonedBuilder = builder.Clone();
            
            
            Assert.AreEqual("# a", builder.CreateHeader("a"));
            Assert.AreEqual("## a", clonedBuilder.CreateHeader("a"));
        }
        
        [TestMethod]
        public void CreateHeader_FromClonedWithInitialDepth_ShouldCreateHeaderWithTwoHashTag()
        {
            IMarkdownHeaderBuilder builder = new MarkdownHeaderBuilder();

            string header = builder.Clone().CreateHeader("Test");
            
            Assert.AreEqual("## Test", header);
        }
        
    }
}