using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class TableCellElement : BaseContainerElement
    {
        private List<BaseElement> _children;
        private List<string> _classes;

        public TableCellElement()
        {
            this._children = new List<BaseElement>();
            this._classes = new List<string>();
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

        public override void AddElement(BaseElement element)
        {
            _children.Add(element);
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("    ");
            builder.Append($@"<td class=""{GetClasses()}"">");

            _children.NullSafeForEach(x => builder.Append(x.ToHtml()));

            builder.Append("</td>");
            builder.AppendLine();

            return builder.ToString();
        }

        public override string ToText()
        {
            StringBuilder builder = new StringBuilder();

            _children.NullSafeForEach(x => builder.Append(x.ToText()));

            return builder.ToString();
        }
    }
}
