using Microsoft.VisualStudio.TestTools.UnitTesting;
using Norika.Documentation.Markdown.Statics;

namespace Norika.Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownStaticsUnitTest
    {
        [TestMethod]
        public void MarkdownLandingPageFileName_WithGivenLandingPageNameAndExtension_ShouldSetupFileNameCorrectly()
        {
            Assert.AreEqual($"{MarkdownStatics.MarkdownLandingPageName}.{MarkdownStatics.MarkdownFileExtension}", 
                MarkdownStatics.MarkdownLandingPageFileName);
        }
    }
}