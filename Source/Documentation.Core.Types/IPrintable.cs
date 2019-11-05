namespace Documentation.Core.Types
{
    /// <summary>
    /// Model for printable objects 
    /// </summary>
    public interface IPrintable
    {
        /// <summary>
        /// Prints the content of the object as string and format
        /// the content to the output format. 
        /// </summary>
        /// <returns>Formatted content</returns>
        string Print();
    }
}