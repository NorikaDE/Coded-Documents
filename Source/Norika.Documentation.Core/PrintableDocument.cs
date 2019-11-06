using Norika.Documentation.Core.FileSystem;
using Norika.Documentation.Core.FileSystem.Interfaces;
using Norika.Documentation.Core.Types;

namespace Norika.Documentation.Core
{
    /// <summary>
    ///     Factory for creating a printable document
    /// </summary>
    /// <typeparam name="T">Type of the output document</typeparam>
    public sealed class PrintableDocument<T> where T : IPrintableDocument
    {
        /// <summary>
        ///     Writer used for file system write access
        /// </summary>
        private readonly IFileWriter _defaultFileWriter;

        /// <summary>
        ///     Builder for creating the output document
        /// </summary>
        private readonly IFormattableDocumentBuilder _defaultDocumentBuilder;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="fileWriter">File writer to use for file system write access</param>
        public PrintableDocument(IFileWriter fileWriter)
            : this(new FormattableDocumentDefaultBuilder(), fileWriter)
        {
        }
        
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="formattableDocumentBuilder">Builder for creating the output document</param>
        public PrintableDocument(IFormattableDocumentBuilder formattableDocumentBuilder)
            : this(formattableDocumentBuilder, new FileWriter())
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="formattableDocumentBuilder">Builder for creating the output document</param>
        /// <param name="fileWriter">File writer to use for file system write access</param>
        public PrintableDocument(IFormattableDocumentBuilder formattableDocumentBuilder, IFileWriter fileWriter)
        {
            _defaultDocumentBuilder = formattableDocumentBuilder;
            _defaultFileWriter = fileWriter;
        }
        
        /// <summary>
        ///     Constructor
        /// </summary>
        public PrintableDocument()
            : this(new FormattableDocumentDefaultBuilder(), new FileWriter()) { }
        
        /// <summary>
        /// Creates a new printable document
        /// </summary>
        /// <param name="title">The titel of the document</param>
        /// <returns>Created document</returns>
        public T Create(string title)
        {
            IPrintableDocument document = _defaultDocumentBuilder.Build<T>();
            document.Title = title;
            return (T) document;
        }

        /// <summary>
        /// Saves the given document to the file system
        /// </summary>
        /// <param name="path">Name of the output file</param>
        /// <param name="document">Document that should be saved</param>
        /// <returns>True if the document could be saved</returns>
        public bool Save(string path, T document)
        {
            return _defaultFileWriter.WriteAllText(path, document.Print());
        }

        /// <summary>
        /// Saves the given document to the file system
        /// </summary>
        /// <param name="path">Name of the output file</param>
        /// <param name="document">Document that should be saved</param>
        /// <returns>True if the document could be saved</returns>
        public bool Save(string path, IPrintableDocument document)
        {
            return _defaultFileWriter.WriteAllText(path, document.Print());
        }
    }
}