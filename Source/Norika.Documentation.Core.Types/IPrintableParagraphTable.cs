using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Norika.Documentation.Core.Types
{
    /// <summary>
    /// Model for a printable paragraph table
    /// </summary>
    public interface IPrintableParagraphTable : IPrintable
    {
        /// <summary>
        /// Headers for the table. Defines the maximum amount of cells in a row. 
        /// </summary>
        ReadOnlyCollection<PrintableParagraphTableRowSpecification> Headers { get; }
        
        /// <summary>
        /// Table rows
        /// </summary>
        IList<IPrintableParagraphTableDataRow> Rows { get; }
        
        /// <summary>
        /// Adds a new row to the paragraph table
        /// </summary>
        /// <param name="contents">Cell contents</param>
        /// <returns>Data row object</returns>
        IPrintableParagraphTableDataRow AddNewRow(params string[] contents);
        
        /// <summary>
        /// Adds a new header to the table
        /// </summary>
        /// <param name="headerTitle">Header title</param>
        void AddHeader(string headerTitle);

        /// <summary>
        /// Adds a new header to the table
        /// </summary>
        /// <param name="headerTitle">Header title</param>
        /// <param name="alignment">Alignment option for the columns under the header</param>
        void AddHeader(string headerTitle, PrintableDataRowAlignment alignment);
        
        /// <summary>
        /// Adds an range of headers to the table
        /// </summary>
        /// <param name="header">Header title range</param>
        void AddHeaderRange(params string[] header);

        /// <summary>
        /// Appends a new header to the table
        /// </summary>
        /// <param name="headerTitle">Header title</param>
        /// <returns>The table the header is appended to</returns>
        IPrintableParagraphTable WithHeader(string headerTitle);
        
        /// <summary>
        /// Appends a new header to the table
        /// </summary>
        /// <param name="headerTitle">Header title</param>
        /// <param name="alignment">Alignment option for the columns under the header</param>
        /// <returns>The table the header is appended to</returns>
        IPrintableParagraphTable WithHeader(string headerTitle, PrintableDataRowAlignment alignment);
        
        /// <summary>
        /// Appends a range of new headers to the table
        /// </summary>
        /// <param name="headerTitles">Range of header titles</param>
        /// <returns>The table the headers are appended to</returns>
        IPrintableParagraphTable WithHeaders(params string[] headerTitles);

        /// <summary>
        /// Appends a new row to the table
        /// </summary>
        /// <param name="columns">Range of cell contents in the row</param>
        /// <returns>The table the rows are appended to</returns>
        IPrintableParagraphTable WithRow(params string[] columns);
    }
}