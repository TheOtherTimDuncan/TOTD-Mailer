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
        private List<string> _classes;

        public TableElement()
        {
            this._rows = new List<TableRowElement>();
            this._classes = new List<string>();
        }

        private string GetClasses()
        {
            return String.Join(" ", _classes);
        }

        public TableElement AddClass(string className)
        {
            _classes.Add(className);
            return this;
        }

        public TableElement AddRow(TableRowElement row)
        {
            _rows.Add(row);
            return this;
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();

            builder.AppendLine($@"<table class=""{GetClasses()}"">");

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
            builder.AppendLine();

            _rows.NullSafeForEach(x => builder.Append(x.ToText(lengths)));

            builder.AppendLine();

            return builder.ToString();
        }
    }
}
