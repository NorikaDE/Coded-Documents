using Norika.Documentation.Core.Types;

namespace Norika.Documentation.Markdown.Elements
{
    /// <summary>
    /// Implementation of a simple markdown chapter string content
    /// </summary>
    public class MarkdownChapterStringContent : IPrintableDocumentChapterStringContent
    {
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentChapterStringContent.Content"/>
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// <inheritdoc cref="IPrintable.Print()"/>
        /// </summary>
        public string Print()
        {
            return Content;
        }
    }
}