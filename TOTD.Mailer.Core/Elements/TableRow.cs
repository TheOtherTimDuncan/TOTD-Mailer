using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class TableRow
    {
        private const string _indent = "    ";

        private List<TableCell> _cells = new List<TableCell>();

        public TableRow AddCell(TableCell cell)
        {
            _cells.Add(cell);
            return this;
        }

        public IEnumerable<int> GetCellTextLengths()
        {
            return _cells.Select(x => x.ToText()).Select(x => x.Length);
        }

        public string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(_indent);
            builder.AppendLine("<tr>");

            foreach (TableCell cell in _cells)
            {
                builder.Append(_indent);
                builder.Append(cell.ToHtml());
            }

            builder.Append(_indent);
            builder.AppendLine("</tr>");

            return builder.ToString();
        }

        public string ToText(int[] cellLengths)
        {
            StringBuilder builder = new StringBuilder();

            int c = 0;
            foreach (TableCell cell in _cells)
            {
                builder.Append(cell.ToText().PadRight(cellLengths[c]));
                builder.Append(' ');
                c++;
            }

            builder.AppendLine();

            return builder.ToString();
        }
    }
}
