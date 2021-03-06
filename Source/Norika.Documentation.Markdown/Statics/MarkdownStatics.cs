﻿using System;
using System.Text;

namespace Norika.Documentation.Markdown.Statics
{
    /// <summary>
    /// Contains all required static markdown information
    /// </summary>
    public static class MarkdownStatics
    {
        /// <summary>
        /// Default markdown file extension
        /// </summary>
        public static string MarkdownFileExtension => "md";

        /// <summary>
        /// Default markdown landing page name
        /// </summary>
        public static string MarkdownLandingPageName => "readme";
        
        /// <summary>
        /// Default markdown landing page file name
        /// </summary>
        public static string MarkdownLandingPageFileName => $"{MarkdownLandingPageName}.{MarkdownFileExtension}";

        /// <summary>
        /// Default markdown header identifier prefix
        /// </summary>
        public static string MarkdownHeaderIdentifier => "#";

        /// <summary>
        /// Default markdown table row cell separator
        /// </summary>
        public static string MarkdownTableColumnSeparator => "|";
        
        /// <summary>
        /// Creates a markdown header prefix dependent on the given
        /// depth.
        /// </summary>
        /// <param name="depth">The amount of header prefixes that should be returned</param>
        /// <returns>The correct amount of header prefixes</returns>
        /// <exception cref="ArgumentOutOfRangeException">10 is the maximum depth</exception>
        public static string GetMarkdownHeader(int depth)
        {
            if (depth < 0 || depth > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(depth));
            }
            StringBuilder headerBuilder = new StringBuilder(MarkdownHeaderIdentifier);
            for (int i = 0; i < depth; i++)
            {
                headerBuilder.Append(MarkdownHeaderIdentifier);
            }
            return headerBuilder.ToString();
        }
    }
}