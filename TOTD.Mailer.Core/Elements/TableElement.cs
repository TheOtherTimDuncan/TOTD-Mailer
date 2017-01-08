using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class TableElement : BaseElement
    {
        private List<TableRow> _rows = new List<TableRow>();

        public TableElement AddRow(TableRow row)
        {
            _rows.Add(row);
            return this;
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
