using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class TableElement : BaseElement
    {
        private List<TableRowElement> _rows;
        private BodyElement _parent;

        public TableElement(BodyElement parent)
        {
            this._rows = new List<TableRowElement>();
            this._parent = parent;
        }

        public TableRowElement BeginRow()
        {
            TableRowElement row = new TableRowElement(this);
            _rows.Add(row);
            return row;
        }

        public BodyElement EndTable()
        {
            return _parent;
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<table>");

            _rows.NullSafeForEach(x => builder.Append(x.ToHtml()));

            builder.AppendLine("</table>");

            return builder.ToString();
        }

        public override string ToText()
        {
            int[] lengths = _rows
                .Select(x => x.GetCellTextLengths())
                .Select(x => x.Max())
                .ToArray();

            StringBuilder builder = new StringBuilder();

            _rows.NullSafeForEach(x => builder.Append(x.ToText(lengths)));

            builder.AppendLine();

            return builder.ToString();
        }
    }
}
