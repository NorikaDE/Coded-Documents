using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Norika.Documentation.Core.Types;
using Norika.Documentation.Markdown.Statics;

namespace Norika.Documentation.Markdown.Elements
{
    public class MarkdownTable : IPrintableParagraphTable
    {
        private readonly List<PrintableParagraphTableRowSpecification> _headers = new List<PrintableParagraphTableRowSpecification>();
        
        private readonly List<IPrintableParagraphTableDataRow> _rows = new List<IPrintableParagraphTableDataRow>();
        
        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            if (_headers.Count != 0)
            {
                builder.Append(MarkdownStatics.MarkdownTableColumnSeparator);

                foreach (PrintableParagraphTableRowSpecification headerSpecification in _headers)
                {
                    builder.Append(headerSpecification.Title);
                    builder.Append(MarkdownStatics.MarkdownTableColumnSeparator);
                }

                builder.Append('\n');
                builder.Append(MarkdownStatics.MarkdownTableColumnSeparator);
                
                foreach (PrintableParagraphTableRowSpecification headerSpecification in _headers)
                {
                    builder.Append(ConvertToAlignmentString(headerSpecification.Alignment));
                    builder.Append(MarkdownStatics.MarkdownTableColumnSeparator);
                }

                builder.Append('\n');
            }

            foreach (IPrintableParagraphTableDataRow dataRow in _rows)
            {
                builder.Append($"{dataRow.Print()}\n");
            }

            return builder.ToString().TrimEnd();
        }

        public ReadOnlyCollection<PrintableParagraphTableRowSpecification> Headers => _headers.AsReadOnly();

        public IList<IPrintableParagraphTableDataRow> Rows => _rows.AsReadOnly();
        
        public IPrintableParagraphTableDataRow AddNewRow(params string[] contents)
        {
            MarkdownTableRow newTableRow =
                (_headers.Count == 0 ? new MarkdownTableRow() : new MarkdownTableRow(_headers.Count));

            newTableRow.AddRange(contents);
            
            _rows.Add(newTableRow);

            return newTableRow;
        }

        public void AddHeader(string headerTitle)
        {
            AddHeader(headerTitle, PrintableDataRowAlignment.Left);
        }

        public void AddHeader(string headerTitle, PrintableDataRowAlignment alignment)
        {
            if(_rows.Count > 0)
                throw new NotSupportedException("Please specify headers before content!");
            
            _headers.Add(new PrintableParagraphTableRowSpecification()
            {
                Title = headerTitle,
                Alignment = alignment
            });
        }

        public void AddHeaderRange(params string[] headerTitles)
        {
            foreach (string header in headerTitles)
            {
                AddHeader(header);
            }
        }

        public IPrintableParagraphTable WithHeader(string headerTitle)
        {
            AddHeader(headerTitle);
            return this;
        }

        public IPrintableParagraphTable WithHeader(string headerTitle, PrintableDataRowAlignment alignment)
        {
            AddHeader(headerTitle, alignment);
            return this;
        }

        public IPrintableParagraphTable WithHeaders(params string[] headerTitles)
        {
            AddHeaderRange(headerTitles);
            return this;
        }

        public IPrintableParagraphTable WithRow(params string[] columns)
        {
            AddNewRow(columns);
            return this;
        }

        public static string ConvertToAlignmentString(PrintableDataRowAlignment alignment)
        {
            switch (alignment)
            {
                case PrintableDataRowAlignment.Left:
                    return ":-----";
                case PrintableDataRowAlignment.Center:
                    return ":----:";
                case PrintableDataRowAlignment.Right:
                    return "-----:";
                default:
                    throw new ArgumentOutOfRangeException(nameof(alignment), alignment, null);
            }
        }
    }
}