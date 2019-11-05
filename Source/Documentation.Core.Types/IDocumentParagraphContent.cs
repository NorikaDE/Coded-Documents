using System;

namespace Documentation.Core.Types
{
    [Obsolete("This interface is going to be removed soon.", true)]
    public interface IDocumentParagraphContent : IPrintable
    {
        string Content { get; set; }
    }
}