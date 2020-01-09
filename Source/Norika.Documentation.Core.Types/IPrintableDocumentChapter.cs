using System.Collections.Generic;

namespace Norika.Documentation.Core.Types
{
    /// <summary>
    /// Model of a printable document chapter
    /// </summary>
    public interface IPrintableDocumentChapter : IPrintable
    {
        /// <summary>
        /// Title of the document chapter
        /// </summary>
        string Title { get; set; }
        
        /// <summary>
        /// Contents of the document chapter
        /// </summary>
        IList<IPrintable> Content { get; }

        /// <summary>
        /// Creates and adds a content to the document chapter
        /// </summary>
        /// <typeparam name="T">Type of the content that should be created and added</typeparam>
        /// <returns>The new added content object</returns>
        T AddNewContent<T>() where T : class, IPrintable;

        /// <summary>
        /// Adds a new paragraph to the document chapter
        /// </summary>
        /// <param name="title">Title of the paragraph</param>
        /// <returns>The new created paragraph</returns>
        IPrintableDocumentParagraph AddNewParagraph(string title);
    }
}
