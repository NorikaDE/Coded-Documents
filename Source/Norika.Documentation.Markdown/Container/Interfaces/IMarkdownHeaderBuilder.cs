namespace Norika.Documentation.Markdown.Container.Interfaces
{
    /// <summary>
    /// Model for a markdown header builder. 
    /// </summary>
    public interface IMarkdownHeaderBuilder
    {
        /// <summary>
        /// Creates the header from the given value
        /// with the correct indent dependent for the
        /// depth value of the current header
        /// </summary>
        /// <param name="headerValue">Title for the header</param>
        /// <returns></returns>
        string CreateHeader(string headerValue);

        /// <summary>
        /// Clones the builder for passing it through
        /// to child elements. Increases its depth per
        /// call.
        /// </summary>
        /// <returns>A clone of the current builder with increased header depth.</returns>
        IMarkdownHeaderBuilder Clone();
    }
}