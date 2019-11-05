namespace Documentation.Markdown.Container.Interfaces
{
    /// <summary>
    /// Provides methods for passing and inheriting markdown headers to child
    /// contents that also contain headers. Ensures to get the correct depth for
    /// markdown headers.
    /// </summary>
    public interface IHeaderContainer
    {
        /// <summary>
        /// Sets the header builder for this object
        /// </summary>
        /// <param name="headerBuilder">Header builder to set for the object</param>
        void SetHeaderBuilder(IMarkdownHeaderBuilder headerBuilder);
        
        /// <summary>
        /// Content for the header that should be created
        /// </summary>
        string HeaderContent { get; }
    }
}