using System.Collections.Generic;

namespace Norika.Documentation.Core.Types
{
    /// <summary>
    /// Model of a printable paragraph table data row
    /// </summary>
    public interface IPrintableParagraphTableDataRow : IPrintable
    {
        /// <summary>
        /// Range of data cells in the data row
        /// </summary>
        IList<string> Columns { get; }

        /// <summary>
        /// Adds a new cell to the data row
        /// </summary>
        /// <param name="s"></param>
        void Add(string s);

       
    }
}