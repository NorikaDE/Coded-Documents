using System;
using System.Collections.Generic;
using System.Text;
using Norika.Documentation.Core.Types;

namespace Norika.Documentation.Markdown.Elements
{
    /// <summary>
    /// Implementation of a printable markdown code block.
    /// </summary>
    public class MarkdownCodeBlock : IPrintableDocumentCodeBlock
    {

        /// <summary>
        /// <inheritdoc cref="IPrintable.Print()"/>
        /// </summary>
        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("```");
            builder.Append(Language);
            builder.Append('\n');
            builder.AppendJoin('\n', Content);
            builder.Append('\n');
            builder.Append("```");

            return builder.ToString();
        }

        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentCodeBlock.Language"/>
        /// </summary>
        public string Language { get; private set; }
        
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentCodeBlock.Content"/>
        /// </summary>
        public IList<string> Content { get; } = new List<string>();
        
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentCodeBlock.AppendContent(IList{string})"/>
        /// </summary>
        public void AppendContent(IList<string> content)
        {
            (Content as List<string>)?.AddRange(content);
        }
        
        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentCodeBlock.AppendContentLine()"/>
        /// </summary>
        public void AppendContentLine()
        {
            Content.Add(string.Empty);
        }

        
        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentCodeBlock.AppendContentLine()"/>
        /// </summary>
        public void AppendContentLine(string content)
        {
            Content.Add(content);
        }


        /// <summary>
        /// <inheritdoc cref="IPrintableDocumentCodeBlock.SetLanguage(string)"/>
        /// </summary>
        public void SetLanguage(string language)
        {
            Language = language.ToLowerInvariant();
        }
    }
}