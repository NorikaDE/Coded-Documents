using System.Collections.Generic;
using System.Text;
using Norika.Documentation.Core.Types;
using Norika.Documentation.Markdown.Container.Interfaces;
using Norika.Documentation.Markdown.Statics;

namespace Norika.Documentation.Markdown.Container
{
    /// <summary>
    /// Implementation of a markdown document
    /// </summary>
    public class MarkdownDocument : IMarkdownDocument
    {
        /// <summary>
        /// The builder that is used to create all headers in the document
        /// </summary>
        private IMarkdownHeaderBuilder _headerBuilder;
        
        /// <summary>
        /// Contains all chapters in the markdown document
        /// </summary>
        private readonly List<IPrintableDocumentChapter> _chapters = new List<IPrintableDocumentChapter>();
        
        /// <summary>
        /// Factory for creating new markdown elements
        /// </summary>
        private readonly IPrintableMarkdownElementFactory _factory;
        
        /// <summary>
        /// Creates a new markdown document
        /// </summary>
        /// <param name="title">Title of the document</param>
        public MarkdownDocument(string title)
        {
            Title = title;
            
            if(_factory == null)
                _factory = new MarkdownElementFactory();

            if(_headerBuilder == null)
                _headerBuilder = new MarkdownHeaderBuilder();
        }
        
        /// <summary>
        /// Creates a new markdown document
        /// </summary>
        /// <param name="title">The title of the document</param>
        /// <param name="factory">Markdown element factory for creating further document contents</param>
        public MarkdownDocument(string title, IPrintableMarkdownElementFactory factory) : this(title)
        {
            _factory = factory;
        }
        
        /// <summary>
        /// Creates a new markdown document
        /// </summary>
        public MarkdownDocument() : this(string.Empty) { }
        
        /// <summary>
        /// <inheritdoc cref="IPrintable.Print"/>
        /// </summary>
        public string Print()
        {
            StringBuilder markdownStringBuilder = new StringBuilder();
            markdownStringBuilder.Append($"{_headerBuilder.CreateHeader(Title)}\n");

            foreach (IPrintableDocumentChapter chapter in Chapters)
            {
                markdownStringBuilder.Append($"{chapter.Print()}\n");
            }

            return markdownStringBuilder.ToString().TrimEnd();
        }

        /// <summary>
        /// <inheritdoc cref="IPrintableDocument.Author"/>
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// <inheritdoc cref="IPrintableDocument.Title"/>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// <inheritdoc cref="IPrintableDocument.DefaultFileExtension"/>
        /// </summary>
        public string DefaultFileExtension => MarkdownStatics.MarkdownFileExtension;
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocument.Chapters"/>
        /// </summary>
        public IList<IPrintableDocumentChapter> Chapters => _chapters.AsReadOnly();
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocument.AddNewChapter(string)"/>
        /// </summary>
        public IPrintableDocumentChapter AddNewChapter(string title)
        {
            IHeaderContainer chapter = _factory.CreateMarkdownContainer<IMarkdownSite>(title);
            chapter.SetHeaderBuilder(_headerBuilder.Clone());
            
            _chapters.Add((IPrintableDocumentChapter)chapter);

            return (IPrintableDocumentChapter)chapter;
        }

        /// <summary>
        /// <inheritdoc cref="IPrintableDocument.CreateElement{T}"/>
        /// </summary>
        public T CreateElement<T>() where T : class, IPrintable
        {
            return _factory.CreateElement<T>();
        }

        /// <summary>
        /// <inheritdoc cref="IPrintableDocument.AddChapter"/>
        /// </summary>
        public void AddChapter(IPrintableDocumentChapter chapter)
        {
            _chapters.Add(chapter);
        }

        /// <summary>
        /// <inheritdoc cref="IHeaderContainer.SetHeaderBuilder"/>
        /// </summary>
        public void SetHeaderBuilder(IMarkdownHeaderBuilder headerBuilder)
        {
            _headerBuilder = headerBuilder;
        }

        /// <summary>
        /// <inheritdoc cref="IHeaderContainer.HeaderContent"/>
        /// </summary>
        public string HeaderContent => Title;
    }
}