using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class ParagraphElement : BaseElement
    {
        private List<BaseContentElement> _children;
        private BodyElement _parent;

        public ParagraphElement(BodyElement parent)
        {
            this._children = new List<BaseContentElement>();
            this._parent = parent;
        }

        public ParagraphElement AddText(string text)
        {
            _children.Add(new TextElement(text));
            return this;
        }

        public ParagraphElement AddElement(BaseContentElement element)
        {
            _children.Add(element);
            return this;
        }

        public BodyElement EndParagraph()
        {
            return _parent;
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"<p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;"">");

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
