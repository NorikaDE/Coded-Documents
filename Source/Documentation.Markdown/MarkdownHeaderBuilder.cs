using System;
using System.Globalization;
using Documentation.Markdown.Container.Interfaces;
using Documentation.Markdown.Statics;

namespace Documentation.Markdown
{
    /// <summary>
    /// Markdown header builder for dealing with header depths
    /// </summary>
    public class MarkdownHeaderBuilder : IMarkdownHeaderBuilder
    {
        /// <summary>
        /// Represents the current nest depth
        /// </summary>
        public int NestedDepth { get; set; }
        
        
        /// <summary>
        /// <inheritdoc cref="IMarkdownHeaderBuilder.CreateHeader"/>
        /// </summary>
        public string CreateHeader(string headerValue)
        {
            return String.Format(CultureInfo.InvariantCulture, 
                "{0} {1}", MarkdownStatics.GetMarkdownHeader(NestedDepth), headerValue);
        }

        /// <summary>
        /// <inheritdoc cref="IMarkdownHeaderBuilder.Clone"/>
        /// </summary>
        public IMarkdownHeaderBuilder Clone()
        {
            return new MarkdownHeaderBuilder()
            {
                NestedDepth = NestedDepth + 1
            };
        }
    }
}