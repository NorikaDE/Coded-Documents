using System;
using System.Collections.Generic;
using System.Linq;

namespace Norika.Documentation.Markdown.Utilities
{
    public static class StringUtilities
    {
        public static string DefaultLineSeparator => "\n";
        
        /// <summary>
        /// Splits the string by the default msbuild new line separator
        /// </summary>
        /// <param name="s">The string to separate</param>
        /// <returns>List of strings split by new line separator</returns>
        public static IList<string> SplitByNewLine(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return new List<string>();

            IList<string> lines = s.Split(DefaultLineSeparator, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (int i = 0; i < lines.Count; i++)
                lines[i] = lines[i].Trim();

            return lines;
        }
        
        /// <summary>
        /// Replaces new line terminator with white space. Removes unnecessary
        /// white space. 
        /// </summary>
        /// <param name="inputValue">String that contains the new line terminators that should be replaced</param>
        /// <returns>Altered string</returns>
        public static string ReplaceNewLineWithSpace(this string inputValue)
        {
            return string.Join(' ', SplitByNewLine(inputValue));
        }
    }
}