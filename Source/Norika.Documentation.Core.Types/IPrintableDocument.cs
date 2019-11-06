using System.Collections.Generic;

namespace Norika.Documentation.Core.Types
{
    /// <summary>
    /// Model of a printable document.
    /// </summary>
    public interface IPrintableDocument : IPrintable
    {
        
        /// <summary>
        /// Author of the document
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Title of the document
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Default extension of the target output file
        /// </summary>
        string DefaultFileExtension { get; }

        /// <summary>
        /// Chapters of the document
        /// </summary>
        IList<IPrintableDocumentChapter> Chapters { get; }

        /// <summary>
        /// Adds a new chapter to the document and return the created chapter.
        /// </summary>
        /// <param name="title">Title of the chapter</param>
        /// <returns>New chapter</returns>
        IPrintableDocumentChapter AddNewChapter(string title);
        
        /// <summary>
        /// Creates a new printable.
        /// </summary>
        /// <typeparam name="T">Type of the element that should be created</typeparam>
        /// <returns>Created element</returns>
        T CreateElement<T>() where T : class, IPrintable;
    }
}