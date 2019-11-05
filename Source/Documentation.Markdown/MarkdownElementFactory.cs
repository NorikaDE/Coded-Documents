using Documentation.Core.Types;
using Documentation.Markdown.Container;
using Documentation.Markdown.Container.Interfaces;
using Documentation.Markdown.Elements;

namespace Documentation.Markdown
{
    /// <summary>
    /// Factory for creating new markdown elements
    /// </summary>
    public class MarkdownElementFactory : IPrintableMarkdownElementFactory
    {
        /// <summary>
        /// <inheritdoc cref="IPrintableMarkdownElementFactory.CreateElement{T}"/>
        /// </summary>
        public T CreateElement<T>() where T : class, IPrintable
        {
            if (typeof(T) == typeof(IPrintableDocumentChapterStringContent))
            {
                return new MarkdownChapterStringContent() as T;
            }
            
            if (typeof(T) == typeof(IPrintableParagraphTable))
            {
                return new MarkdownTable() as T;
            }
            
            if (typeof(T) == typeof(IPrintableDocumentCodeBlock))
            {
                return new MarkdownCodeBlock() as T;
            }

            if (typeof(T) == typeof(IPrintableDocumentParagraphHyperlink))
            {
                return new MarkdownHyperlink() as T;
            }

            return default(T);
        }

        
        /// <summary>
        /// <inheritdoc cref="IPrintableMarkdownElementFactory.CreateMarkdownContainer{T}"/>
        /// </summary>
        public T CreateMarkdownContainer<T>(string title) where T : class, IPrintable, IHeaderContainer
        {
            if (typeof(T) == typeof(IMarkdownSite))
            {
                return (T) (IPrintable) new MarkdownSite(title, this);
            }

            if (typeof(T) == typeof(IMarkdownDocument))
            {
                return (T) (IPrintable) new MarkdownDocument(title, this);
            }

            if (typeof(T) == typeof(IMarkdownParagraph))
            {
                return (T) (IPrintable) new MarkdownParagraph(title, this);
            }

            return default(T);
        }
        
    }
}