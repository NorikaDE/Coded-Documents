using System;
using Norika.Documentation.Core.Types;

namespace Norika.Documentation.Markdown.Elements
{
    /// <summary>
    /// Implementation of a markdown hyperlink
    /// </summary>
    public class MarkdownHyperlink : IPrintableDocumentParagraphHyperlink
    {
        /// <summary>
        /// Creates a new markdown hyperlink
        /// </summary>
        /// <param name="target">The target the link should point at</param>
        /// <param name="displayString">The display string that should be shown for the link</param>
        public MarkdownHyperlink(string target, string displayString)
        {
            DisplayString = displayString;
            Hyperlink = target;
        }

        /// <summary>
        /// Creates a new markdown hyperlink
        /// </summary>
        /// <param name="linkTarget">The target the link should point at</param>
        public MarkdownHyperlink(string linkTarget) : this(linkTarget, linkTarget) {}

        /// <summary>
        /// Creates a new markdown hyperlink
        /// </summary>
        public MarkdownHyperlink(){}
        
        
        /// <summary>
        /// <inheritdoc cref="IPrintable.Print"/>
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws if DisplayString or Hyperlink are null or empty</exception>
        public string Print()
        {
            if(string.IsNullOrEmpty(DisplayString) || string.IsNullOrEmpty(Hyperlink))
                throw new ArgumentNullException($"{nameof(DisplayString)} and {nameof(Hyperlink)} must not be null!");

            if (string.IsNullOrWhiteSpace(ToolTip))
            {
                return string.Format("[{0}]({1})", DisplayString, Hyperlink);
            }
            else
            {
                return string.Format("[{0}]({1} '{2}')", DisplayString, Hyperlink, ToolTip);    
            }
        }
        
        public string DisplayString { get; set; }
        
        public string Hyperlink { get; set; }
        
        public string ToolTip { get; set; }
    }
}