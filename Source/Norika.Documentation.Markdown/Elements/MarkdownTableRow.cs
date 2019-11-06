using System;
using System.Collections.Generic;
using System.Text;
using Norika.Documentation.Core.Types;
using Norika.Documentation.Markdown.Statics;

namespace Norika.Documentation.Markdown.Elements
{
    public class MarkdownTableRow : IPrintableParagraphTableDataRow
    {
        private readonly int _capacity = Int32.MaxValue;
        
        private readonly List<string> _columns;

        public void AddRange(string[] args)
        {
            foreach (string arg in args)
            {
                Add(arg);
            }
        }

        public MarkdownTableRow(int capacity) : this()
        {
            _capacity = capacity;
        }
        
        public MarkdownTableRow()
        {
            _columns = new List<string>();
        }
        
        public string Print()
        {
            if (_columns.Count <= 0)
                return string.Empty;
            
            StringBuilder builder = new StringBuilder();
            builder.Append(MarkdownStatics.MarkdownTableColumnSeparator);
            foreach (string column in _columns)
            {
                builder.Append(column);
                builder.Append(MarkdownStatics.MarkdownTableColumnSeparator);
            }

            return builder.ToString();
        }

        public IList<string> Columns => _columns.AsReadOnly();
        
        public void Add(string s)
        {
            if (_columns.Count >= _capacity)
            {
                throw new IndexOutOfRangeException();
            }
            _columns.Add(s);
        }
        
    }
}