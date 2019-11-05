namespace Documentation.Core.Types
{
    /// <summary>
    /// Model of a printable chapter string content.
    /// </summary>
    public interface IPrintableDocumentChapterStringContent : IPrintable
    {
        /// <summary>
        /// String content for the chapter
        /// </summary>
        string Content { get; set; }
    }
}