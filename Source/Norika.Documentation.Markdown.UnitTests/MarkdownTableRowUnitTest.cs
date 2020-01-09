using System;
using Norika.Documentation.Core.Types;
using Norika.Documentation.Markdown.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Norika.Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownTableRowUnitTest
    {
        [TestMethod]
        public void Print_WithOneColumn_ShouldPrintCorrectMarkdownFormat()
        {
            MarkdownTableRow tableRow = new MarkdownTableRow();
            tableRow.Add("Test");
            
            Assert.AreEqual("|Test|", tableRow.Print());
        }
        
        [TestMethod]
        public void Print_WithTwoColumns_ShouldPrintCorrectMarkdownFormat()
        {
            MarkdownTableRow tableRow = new MarkdownTableRow();
            tableRow.Add("A");
            tableRow.Add("B");
            
            Assert.AreEqual("|A|B|", tableRow.Print());
        }
        
        [TestMethod]
        public void Print_WithThreeColumnsMiddleOneEmpty_ShouldPrintCorrectMarkdownFormat()
        {
            MarkdownTableRow tableRow = new MarkdownTableRow();
            tableRow.Add("A");
            tableRow.Add(string.Empty);
            tableRow.Add("C");
            
            Assert.AreEqual("|A||C|", tableRow.Print());
        }
        
        [TestMethod]
        public void Print_WithTwoColumnsAndCapacityTwo_ShouldPrintCorrectMarkdownFormat()
        {
            MarkdownTableRow tableRow = new MarkdownTableRow(2);
            tableRow.Add("A");
            tableRow.Add("B");
            
            Assert.AreEqual("|A|B|", tableRow.Print());
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Print_WithThreeColumnsAndCapacityTwo_ShouldThrowException()
        {
            MarkdownTableRow tableRow = new MarkdownTableRow(2);
            tableRow.Add("A");
            tableRow.Add("B");
            tableRow.Add("C");
            
            Assert.AreEqual("|A|B|", tableRow.Print());
        }
        
        [TestMethod]
        public void Add_WithStringContainingNewLine_ShouldReplaceNewLineWithWhiteSpace()
        {
            MarkdownTableRow tableRow = new MarkdownTableRow(2);
            tableRow.Add("A\nB");
            tableRow.Add("C");

            Assert.AreEqual("|A B|C|", tableRow.Print());
        }
        
        [TestMethod]
        public void AddRange_WithStringContainingNewLine_ShouldReplaceNewLineWithWhiteSpace()
        {
            MarkdownTableRow tableRow = new MarkdownTableRow(2);
            tableRow.AddRange(new []{ "A\nB", "C" });

            Assert.AreEqual("|A B|C|", tableRow.Print());
        }

        [TestMethod]
        public void Print_WithoutEntry_ShouldReturnEmptyString()
        {
            MarkdownTableRow tableRow = new MarkdownTableRow();
            
            Assert.AreEqual(string.Empty, tableRow.Print());
        }

       
    }
}