using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class TableCellElement
    {
        private List<BaseContentElement> _children;
        private List<string> _classes;
        private TableRowElement _parent;

        public TableCellElement(TableRowElement parent)
        {
            this._children = new List<Elements.BaseContentElement>();
            this._classes = new List<string>();
            this._parent = parent;
        }

        private string GetClasses()
        {
            return String.Join(" ", _classes);
        }

        public TableCellElement AddText(string text)
        {
            _children.Add(new TextElement(text));
            return this;
        }

        public TableCellElement AddClass(string className)
        {
            _classes.Add(className);
            return this;
        }

        public TableCellElement AddElement(BaseContentElement element)
        {
            _children.Add(element);
            return this;
        }

        public TableRowElement EndCell()
        {
            return _parent;
        }

        public string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("    ");
            builder.Append($"<td {GetClasses()}>");

            _children.NullSafeForEach(x => builder.Append(x.ToHtml()));

            builder.Append("</td>");
            builder.AppendLine();

            return builder.ToString();
        }

        public string ToText()
        {
            StringBuilder builder = new StringBuilder();

            _children.NullSafeForEach(x => builder.Append(x.ToText()));

            return builder.ToString();
        }
    }
}
