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
            IEnumerable<IEnumerable<int>> rowLengths = _rows.Select(x => x.GetCellTextLengths()).ToList();
            List<int> lengths = new List<int>();
            foreach (IEnumerable<int> cellLength in rowLengths)
            {
                int i = 0;
                foreach (int l in cellLength)
                {
                    if (i >= lengths.Count())
                    {
                        lengths.Add(l);
                    }
                    else
                    {
                        if (l > lengths[i])
                        {
                            lengths[i] = l;
                        }
                    }
                    i++;
                }
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine();

            _rows.NullSafeForEach(x => builder.Append(x.ToText(lengths.ToArray())));

            builder.AppendLine();

            return builder.ToString();
        }
    }
}
