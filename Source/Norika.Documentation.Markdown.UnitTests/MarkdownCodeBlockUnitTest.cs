using System.Collections.Generic;
using System.Linq;
using Norika.Documentation.Markdown.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Norika.Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownCodeBlockUnitTest
    {
        [TestMethod]
        public void Print_LanguageXmlWithOneLine_ShouldPrintCorrectAndExpectedMarkdownFormat()
        {
            MarkdownCodeBlock codeBlock = new MarkdownCodeBlock();
            
            codeBlock.SetLanguage("xml");
            codeBlock.AppendContentLine("<xml>test</xml>");
            
            Assert.AreEqual("```xml\n<xml>test</xml>\n```", codeBlock.Print());
        }
        
        [TestMethod]
        public void Print_LanguageXmlWithOneLineCodeAndOneLineComment_ShouldPrintCorrectAndExpectedMarkdownFormat()
        {
            MarkdownCodeBlock codeBlock = new MarkdownCodeBlock();
            
            codeBlock.SetLanguage("xml");
            codeBlock.AppendContentLine("<xml>test</xml>");
            codeBlock.AppendContentLine("<!-- a simple test string -->");
            
            Assert.AreEqual("```xml\n<xml>test</xml>\n<!-- a simple test string -->\n```", codeBlock.Print());
        }
        
        [TestMethod]
        public void Print_LanguageXmlWithThreeLinesSeparatedByOneEmptyLine_ShouldPrintCorrectAndExpectedMarkdownFormat()
        {
            MarkdownCodeBlock codeBlock = new MarkdownCodeBlock();
            
            codeBlock.SetLanguage("xml");
            codeBlock.AppendContentLine("<xml>test</xml>");
            codeBlock.AppendContentLine();
            codeBlock.AppendContentLine("<!-- a simple test string -->");
            
            Assert.AreEqual("```xml\n<xml>test</xml>\n\n<!-- a simple test string -->\n```", codeBlock.Print());
        }
        
        [TestMethod]
        public void AppendContentLine_WithContentLine_ShouldAddLine()
        {
            MarkdownCodeBlock codeBlock = new MarkdownCodeBlock();
            
            codeBlock.AppendContentLine("<xml>test</xml>");

            Assert.AreEqual("<xml>test</xml>", codeBlock.Content[0]);
        }
        
        [TestMethod]
        public void AppendContentLine_WithContentLinesSeparatedByEmptyLine_ShouldAddLines()
        {
            MarkdownCodeBlock codeBlock = new MarkdownCodeBlock();
            
            codeBlock.AppendContentLine("<xml>test</xml>");
            codeBlock.AppendContentLine();
            codeBlock.AppendContentLine("<xml>test</xml>");

            Assert.AreEqual("<xml>test</xml>", codeBlock.Content[0]);
            Assert.AreEqual(string.Empty, codeBlock.Content[1]);
            Assert.AreEqual("<xml>test</xml>", codeBlock.Content[2]);
        }
        
        [TestMethod]
        public void AppendContent_WithTwoLines_ShouldAddBothLines()
        {
            MarkdownCodeBlock codeBlock = new MarkdownCodeBlock();
            
            codeBlock.AppendContent(new List<string>(){"a", "b"});

            Assert.AreEqual("a", codeBlock.Content[0]);
            Assert.AreEqual("b", codeBlock.Content[1]);
        }
        
    }
}