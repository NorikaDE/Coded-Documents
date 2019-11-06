namespace Norika.Documentation.Core.Types
{
    /// <summary>
    /// Model for a paragraph hyperlink
    /// </summary>
    public interface IPrintableDocumentParagraphHyperlink : IPrintable
    {
        /// <summary>
        /// The display string of the hyperlink
        /// </summary>
        string DisplayString { get; set; }
        
        /// <summary>
        /// The target for the hyperlink 
        /// </summary>
        string Hyperlink { get; set; }
        
        /// <summary>
        /// The tool tip that should be shown for the hyperlink
        /// </summary>
        string ToolTip { get; set; }
    }
}