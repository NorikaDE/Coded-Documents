using System.Collections.Generic;
using System.Text;
using Documentation.Core.Types;
using Documentation.Markdown.Container.Interfaces;

namespace Documentation.Markdown.Container
{
    /// <summary>
    /// Implementation of a markdown site
    /// </summary>
    public class MarkdownSite : IMarkdownSite
    {
        
        /// <summary>
        /// The builder that is used to create all headers in the document
        /// </summary>
        private IMarkdownHeaderBuilder _headerBuilder;
        
        
        /// <summary>
        /// List of body contents in the markdown paragraph
        /// </summary>
        private readonly List<IPrintable> _content = new List<IPrintable>();
        
        
        /// <summary>
        /// Factory for creating new markdown elements
        /// </summary>
        private readonly IPrintableMarkdownElementFactory _elementFactory;

        
        /// <summary>
        /// Creates a new markdown site
        /// </summary>
        /// <param name="title">Title of the markdown site</param>
        /// <param name="elementFactory">Factory for creating further markdown elements</param>
        public MarkdownSite(string title, IPrintableMarkdownElementFactory elementFactory)
        {
            _elementFactory = elementFactory;
            Title = title;
        }
    
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentChapter.Title"/>
        /// </summary>
        public string Title { get; set; }

        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentChapter.Content"/>
        /// </summary>
        public IList<IPrintable> Content => _content.AsReadOnly();
        
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentChapter.AddNewContent{T}"/>
        /// </summary>
        public T AddNewContent<T>() where T : class, IPrintable
        {
            T newContentObject = _elementFactory.CreateElement<T>();
            _content.Add(newContentObject);
            
            return newContentObject;
        }

        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentChapter.AddNewParagraph"/>
        /// </summary>
        public IPrintableDocumentParagraph AddNewParagraph(string title)
        {
            IHeaderContainer newParagraphObject = 
                _elementFactory.CreateMarkdownContainer<IMarkdownParagraph>(title);

            newParagraphObject.SetHeaderBuilder(_headerBuilder.Clone());
            
            _content.Add((IPrintable)newParagraphObject);
            
            return (IPrintableDocumentParagraph) newParagraphObject;
        }

        
        /// <summary>
        /// <inheritdoc cref="IPrintable.Print"/>
        /// </summary>
        public string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"{_headerBuilder.CreateHeader(Title)}\n");

            foreach (IPrintable printable in Content)
            {
                stringBuilder.Append($"{printable.Print()}\n");
            }

            return stringBuilder.ToString();
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
