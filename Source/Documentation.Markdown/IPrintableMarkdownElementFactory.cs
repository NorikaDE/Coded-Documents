using Documentation.Core.Types;
using Documentation.Markdown.Container.Interfaces;

namespace Documentation.Markdown
{
    /// <summary>
    /// Factory model for creating new markdown elements
    /// </summary>
    public interface IPrintableMarkdownElementFactory
    {
        /// <summary>
        /// Creates a new markdown element from the generic type
        /// </summary>
        /// <typeparam name="T">Target markdown element type</typeparam>
        /// <returns>A new created markdown element from the generic type</returns>
        T CreateElement<T>() where T : class, IPrintable;

        /// <summary>
        /// Creates a new markdown container from the generic type
        /// </summary>
        /// <param name="title">The title for the markdown container</param>
        /// <typeparam name="T">The target markdown container type</typeparam>
        /// <returns>A new created markdown container from the generic type</returns>
        T CreateMarkdownContainer<T>(string title) where T : class, IPrintable, IHeaderContainer;

    }
}