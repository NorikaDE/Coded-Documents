using System;
using Documentation.Markdown.Statics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Documentation.Markdown.UnitTests
{

    [TestClass]
    public class MarkdownStringStaticsUnitTest
    {
        [TestMethod]
        public void GetMarkdownHeader_WithDepthZero_ShouldReturnHeaderWithOneHashTag()
        {
            string headerPrefix = MarkdownStatics.GetMarkdownHeader(0);
            
            Assert.AreEqual("#", headerPrefix);
        }
        
        [TestMethod]
        public void GetMarkdownHeader_WithDepthFive_ShouldReturnHeaderWithSixHashTags()
        {
            string headerPrefix = MarkdownStatics.GetMarkdownHeader(5);
            
            Assert.AreEqual("######", headerPrefix);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetMarkdownHeader_WithDepthMinusOne_ShouldThrowIllegalArgumentException()
        {
            string headerPrefix = MarkdownStatics.GetMarkdownHeader(-1);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetMarkdownHeader_WithDepthNinetyNine_ShouldThrowIllegalArgumentException()
        {
            string headerPrefix = MarkdownStatics.GetMarkdownHeader(99);
        }
        
    }
}