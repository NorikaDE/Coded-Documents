using System.Collections.Generic;
using System.Text;
using Norika.Documentation.Core.Types;
using Norika.Documentation.Markdown.Container.Interfaces;

namespace Norika.Documentation.Markdown.Container
{
    /// <summary>
    /// Implementation of a markdown paragraph. Containing title and content.
    /// </summary>
    public class MarkdownParagraph : IMarkdownParagraph
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
        /// Creates a new markdown paragraph
        /// </summary>
        /// <param name="title">Title of the paragraph</param>
        /// <param name="elementFactory">The factory for creating further markdown elements</param>
        public MarkdownParagraph(string title, IPrintableMarkdownElementFactory elementFactory)
        {
            _elementFactory = elementFactory;
            Title = title;
        }
        
        /// <summary>
        /// <inheritdoc cref="IPrintable.Print"/>
        /// </summary>
        public string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(_headerBuilder.CreateHeader(Title));

            foreach (IPrintable printable in Content)
            {
                stringBuilder.AppendLine(printable.Print());
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentParagraph.Title"/>
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentParagraph.Content"/>
        /// </summary>
        public IList<IPrintable> Content => _content;
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentParagraph.AddNewContent{T}"/>
        /// </summary>
        public T AddNewContent<T>() where T : class, IPrintable
        {
            T newContentObject = _elementFactory.CreateElement<T>();
            _content.Add(newContentObject);

            return newContentObject;
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