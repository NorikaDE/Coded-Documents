using System.Collections.Generic;

namespace Norika.Documentation.Core.Types
{
    /// <summary>
    /// Model for a printable paragraph
    /// </summary>
    public interface IPrintableDocumentParagraph : IPrintable
    {
        /// <summary>
        /// Title of the paragraph
        /// </summary>
        string Title { get; set; }
        
        /// <summary>
        /// Contents of the paragraph
        /// </summary>
        IList<IPrintable> Content { get; }
        
        /// <summary>
        /// Creates and adds a new content to the paragraph
        /// </summary>
        /// <typeparam name="T">Type of the content that should be created</typeparam>
        /// <returns>The added and created paragraph content</returns>
        T AddNewContent<T>() where T : class, IPrintable;
    }
}