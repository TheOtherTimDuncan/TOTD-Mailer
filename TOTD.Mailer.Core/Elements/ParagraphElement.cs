using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class ParagraphElement : BaseContainerElement
    {
        private List<BaseElement> _children;

        public ParagraphElement()
        {
            this._children = new List<BaseElement>();
        }

        public ParagraphElement AddText(string text)
        {
            _children.Add(new TextElement(text));
            return this;
        }

        public override void AddElement(BaseElement element)
        {
            _children.Add(element);
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"<p>");

            _children.NullSafeForEach(x => builder.Append(x.ToHtml()));

            builder.Append("</p>");

            return builder.ToString();
        }

        public override string ToText()
        {
            StringBuilder builder = new StringBuilder();

            _children.NullSafeForEach(x => builder.Append(x.ToText()));

            builder.AppendLine();

            return builder.ToString();
        }
    }
}
