using System;
using Norika.Documentation.Markdown.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Norika.Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownHyperlinkUnitTest
    {
        // Todo: Check for illegal character in Link, DisplayText and ToolTip
        
        [TestMethod]
        public void Print_WithTargetAndDisplayString_ShouldPrintExpectedAndCorrectMarkdownFormat()
        {
            MarkdownHyperlink hyperlink = new MarkdownHyperlink("a", "b");
            
            Assert.AreEqual("[b](a)", hyperlink.Print());
        }
        
        [TestMethod]
        public void Print_WithTarget_ShouldPrintTargetLinkAsDisplayString()
        {
            MarkdownHyperlink hyperlink = new MarkdownHyperlink("a");
            
            Assert.AreEqual("[a](a)", hyperlink.Print());
        }
        
        [TestMethod]
        public void Print_WithToolTip_ShouldPrintTargetHyperlinkAndToolTipCorrectly()
        {
            MarkdownHyperlink hyperlink = new MarkdownHyperlink {Hyperlink = "b", DisplayString = "a", ToolTip = "c"};


            Assert.AreEqual("[a](b 'c')", hyperlink.Print());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Print_WithoutTarget_ShouldThrowArgumentNullException()
        {
            MarkdownHyperlink hyperlink = new MarkdownHyperlink();
            
            hyperlink.Print();
        }
    }
}