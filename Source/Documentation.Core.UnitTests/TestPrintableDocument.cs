using System.Collections.Generic;
using Documentation.Core.Types;

namespace Documentation.Core.UnitTests
{
    /// <summary>
    /// Test implementation for test purposes
    /// </summary>
    public sealed class TestPrintableDocument : ITestPrintableDocument
    {
        /// <summary>
        /// <inheritdoc cref="IPrintable.Print"/>
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return null;
        }
        
        public TestPrintableDocument()
        {
            Author = "NotRelevant";
            Chapters = new List<IPrintableDocumentChapter>();
        }


        public string Author { get; }
        public string Title { get; set; }
        
        public string DefaultFileExtension { get; } = "bla";
        
        public IList<IPrintableDocumentChapter> Chapters { get; }
        
        public IPrintableDocumentChapter AddNewChapter(string title)
        {
            throw new System.NotImplementedException();
        }

        public T CreateElement<T>() where T : class, IPrintable
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ITestPrintableDocument : IPrintableDocument { }
}