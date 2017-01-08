using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class TableCell
    {
        private List<BaseContentElement> _children = new List<BaseContentElement>();

        public TableCell AddText(string text)
        {
            _children.Add(new TextElement(text));
            return this;
        }

        public TableCell AddElement(BaseContentElement element)
        {
            _children.Add(element);
            return this;
        }

        public string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("    ");
            builder.Append("<td>");

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
