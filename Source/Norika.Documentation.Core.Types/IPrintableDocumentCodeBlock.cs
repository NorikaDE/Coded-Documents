using System.Collections.Generic;

namespace Norika.Documentation.Core.Types
{
    /// <summary>
    /// Model of a printable code block 
    /// </summary>
    public interface IPrintableDocumentCodeBlock : IPrintable
    {
        
        /// <summary>
        /// Language that is represented by the code block
        /// </summary>
        string Language { get; }
        
        
        /// <summary>
        /// Content of the code block
        /// </summary>
        IList<string> Content { get; }

        
        /// <summary>
        /// Append the content of the code block with the given lines
        /// </summary>
        /// <param name="content">Lines to append to the content</param>
        void AppendContent(IList<string> content);

        
        /// <summary>
        /// Append the content of the code block with new line
        /// </summary>
        void AppendContentLine();

        
        /// <summary>
        /// Append the content of the code block with the given text
        /// </summary>
        /// <param name="content">Text to append to the content</param>
        void AppendContentLine(string content);

        
        /// <summary>
        /// Sets the language that is represented by the code block
        /// </summary>
        /// <param name="language">String representation of the language.</param>
        void SetLanguage(string language);
    }
}