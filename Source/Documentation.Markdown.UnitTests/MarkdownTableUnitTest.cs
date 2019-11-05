using System;
using System.Linq;
using Documentation.Core.Types;
using Documentation.Markdown.Elements;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Documentation.Markdown.UnitTests
{
    [TestClass]
    public class MarkdownTableUnitTest
    {
        [TestMethod]
        public void Print_WithOneHeaderAndOneDataRow_ShouldPrintExpectedTable()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a").WithRow("b");
            
            Assert.AreEqual("|a|\n|:-----|\n|b|", table.Print());
        }
        
        [TestMethod]
        public void Print_WithOneHeaderAndTwoDataRows_ShouldPrintExpectedTable()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a")
                .WithRow("b")
                .WithRow("c");
            
            Assert.AreEqual("|a|\n|:-----|\n|b|\n|c|", table.Print());
        }
        
        [TestMethod]
        public void Print_WithOneHeaderAlignmentRight_ShouldPrintExpectedTableWithAlignmentRight()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a", PrintableDataRowAlignment.Right).WithRow("b");
            
            Assert.AreEqual("|a|\n|-----:|\n|b|", table.Print());
        }
        
        [TestMethod]
        public void Print_WithOneHeaderAlignmentCenter_ShouldPrintExpectedTableWithAlignmentCenter()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a", PrintableDataRowAlignment.Center).WithRow("b");
            
            Assert.AreEqual("|a|\n|:----:|\n|b|", table.Print());
        }
        
        [TestMethod]
        public void Print_WithOneHeaderAlignmentLeft_ShouldPrintExpectedTableWithAlignmentLeft()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a", PrintableDataRowAlignment.Left).WithRow("b");
            
            Assert.AreEqual("|a|\n|:-----|\n|b|", table.Print());
        }

        [TestMethod]
        public void AddHeader_WithOneHeader_ShouldAddHeaderToList()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a");
            
            Assert.AreEqual("a", table.Headers.First().Title);
        }
        
        [TestMethod]
        public void AddHeader_WithoutAlignmentValue_ShouldUseAlignmentLeftAsDefaultValue()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a");
            
            Assert.AreEqual(PrintableDataRowAlignment.Left, table.Headers.First().Alignment);
        }
        
        [TestMethod]
        public void AddRow_WithOneHeaderAndOneRow_ShouldAddRowToList()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a").WithRow("b");
            
            Assert.AreEqual("b", table.Rows.First().Columns.First());
        }
        
        
        [TestMethod]
        public void AddHeaderRange_WithThreeHeaders_ShouldAddAllThreeHeaders()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.AddHeaderRange("a", "b", "c");
            
            Assert.AreEqual("a", table.Headers[0].Title);
            Assert.AreEqual("b", table.Headers[1].Title);
            Assert.AreEqual("c", table.Headers[2].Title);
        }
        
        [TestMethod]
        public void WithHeaders_WithOneHeader_ShouldAddHeader()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a");
            
            Assert.AreEqual("a", table.Headers[0].Title);
        }
        
        [TestMethod]
        public void WithHeader_AsFluentInterfaceWithTwoHeadersOnCreation_ShouldAddHeadersAndReturnInstance()
        {
            IPrintableParagraphTable table = new MarkdownTable()
                .WithHeader("a")
                .WithHeader("b");

            Assert.IsInstanceOfType(table, typeof(IPrintableParagraphTable));
            Assert.AreEqual("a", table.Headers[0].Title);
            Assert.AreEqual("b", table.Headers[1].Title);
        }
        
        [TestMethod]
        public void WithHeaders_AsFluentInterfaceWithTwoHeadersOnCreation_ShouldAddHeadersAndReturnInstance()
        {
            IPrintableParagraphTable table = new MarkdownTable()
                .WithHeaders("a", "b");

            Assert.IsInstanceOfType(table, typeof(IPrintableParagraphTable));
            Assert.AreEqual("a", table.Headers[0].Title);
            Assert.AreEqual("b", table.Headers[1].Title);
        }
        
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddRow_WithOneHeaderAndOneDataRowWithTwoHeaders_ShouldThrowIndexOutOfRangeException()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithHeader("a").WithRow("b", "c");
            
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void AddHeader_AfterRowsHaveBeenAdded_ShouldThrowNotSupportedException()
        {
            IPrintableParagraphTable table = new MarkdownTable();

            table.WithRow("b", "c").WithHeader("a");

        }
        
        [TestMethod]
        public void ConvertToAlignmentString_WithAlignmentLeft_ShouldReturnFormatStringAlignmentLeft()
        {
            Assert.IsTrue(MarkdownTable.ConvertToAlignmentString(PrintableDataRowAlignment.Left)
                .StartsWith(":"));
            Assert.IsTrue(MarkdownTable.ConvertToAlignmentString(PrintableDataRowAlignment.Left)
                .EndsWith("-"));
        }
        
        [TestMethod]
        public void ConvertToAlignmentString_WithAlignmentCenter_ShouldReturnFormatStringAlignmentCenter()
        {
            Assert.IsTrue(MarkdownTable.ConvertToAlignmentString(PrintableDataRowAlignment.Center)
                .StartsWith(":"));
            Assert.IsTrue(MarkdownTable.ConvertToAlignmentString(PrintableDataRowAlignment.Center)
                .EndsWith(":"));
        }
        
        [TestMethod]
        public void ConvertToAlignmentString_WithAlignmentRight_ShouldReturnFormatStringAlignmentRight()
        {
            Assert.IsTrue(MarkdownTable.ConvertToAlignmentString(PrintableDataRowAlignment.Right)
                .StartsWith("-"));
            Assert.IsTrue(MarkdownTable.ConvertToAlignmentString(PrintableDataRowAlignment.Right)
                .EndsWith(":"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConvertToAlignmentString_IllegalAlignmentValue_ThrowArgumentOutOfRangeException()
        {
            MarkdownTable.ConvertToAlignmentString((PrintableDataRowAlignment) 99);
        }
    }
}