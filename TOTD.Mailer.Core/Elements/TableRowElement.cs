using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOTD.Mailer.Core.Elements
{
    public class TableRowElement
    {
        private const string _indent = "    ";

        private List<BaseTableCellElement> _cells;

        public TableRowElement()
        {
            this._cells = new List<BaseTableCellElement>();
        }

        public IEnumerable<int> GetCellTextLengths()
        {
            return _cells.Select(x => x.ToText()).Select(x => x.Length).ToList();
        }

        public TableRowElement AddCell(BaseTableCellElement cell)
        {
            _cells.Add(cell);
            return this;
        }

        public TableRowElement AddCell(string content)
        {
            TableCellElement cell = new TableCellElement();
            cell.AddText(content);
            return AddCell(cell);
        }

        public TableRowElement AddHeader(string content)
        {
            TableHeaderElement cell = new TableHeaderElement();
            cell.AddText(content);
            return AddCell(cell);
        }

        public string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(_indent);
            builder.AppendLine("<tr>");

            foreach (BaseTableCellElement cell in _cells)
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
            foreach (BaseTableCellElement cell in _cells)
            {
                builder.Append(cell.ToText().PadRight(cellLengths[c]));
                builder.Append(' ');
                c++;
            }


            return builder.ToString();
        }
    }
}
