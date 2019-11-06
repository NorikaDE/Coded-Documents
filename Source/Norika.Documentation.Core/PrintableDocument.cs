using Norika.Documentation.Core.Types;
using Norika.Documentation.Core.FileSystem;
using Norika.Documentation.Core.FileSystem.Interfaces;

namespace Norika.Documentation.Core
{
    /// <summary>
    /// Factory for creating a printable document
    /// </summary>
    /// <typeparam name="T">Type of the output document</typeparam>
    public sealed class PrintableDocument<T> where T : IPrintableDocument
    {
        
        /// <summary>
        /// Writer used for file system write access
        /// </summary>
        private readonly IFileWriter _defaultFileWriter;
        /// <summary>
        /// Builder for creating the output document
        /// </summary>
        private readonly IFormattableDocumentBuilder _defaultDocumentBuilder;
        
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileWriter">File writer to use for file system write access</param>
        public PrintableDocument(IFileWriter fileWriter) 
            : this(new FormattableDocumentDefaultBuilder(), fileWriter) { }

        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="formattableDocumentBuilder">Builder for creating the output document</param>
        public PrintableDocument(IFormattableDocumentBuilder formattableDocumentBuilder) 
            : this(formattableDocumentBuilder, new FileWriter()) { }

        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="formattableDocumentBuilder">Builder for creating the output document</param>
        /// <param name="fileWriter">File writer to use for file system write access</param>
        public PrintableDocument(IFormattableDocumentBuilder formattableDocumentBuilder, IFileWriter fileWriter)
        {
            _defaultDocumentBuilder = formattableDocumentBuilder;
            _defaultFileWriter = fileWriter;
        }
        
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PrintableDocument() 
            : this(new FormattableDocumentDefaultBuilder(), new FileWriter()) {}
        
        
        
        public T Create(string title)
        {
            IPrintableDocument document = _defaultDocumentBuilder.Build<T>();
            document.Title = title;
            return (T) document;
        }

        public bool Save(string path, T document)
        {
            return _defaultFileWriter.WriteAllText(path, document.Print());
        }
        
        public bool Save(string path, IPrintableDocument document)
        {
            return _defaultFileWriter.WriteAllText(path, document.Print());
        }
    }
}