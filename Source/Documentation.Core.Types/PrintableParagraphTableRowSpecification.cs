namespace Documentation.Core.Types
{
    /// <summary>
    /// Specification object for printable table rows
    /// </summary>
    public struct PrintableParagraphTableRowSpecification
    {
        /// <summary>
        /// The header of the table row 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The default alignment for the columns under the header
        /// </summary>
        public PrintableDataRowAlignment Alignment { get; set; }
    }
}