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
        private BodyElement _parent;

        public TableElement(BodyElement parent)
        {
            this._rows = new List<TableRowElement>();
            this._classes = new List<string>();
            this._parent = parent;
        }

        private string GetClasses()
        {
            return String.Join(" ", _classes);
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

        public TableElement AddClass(string className)
        {
            _classes.Add(className);
            return this;
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"<table class={GetClasses()}>");

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
