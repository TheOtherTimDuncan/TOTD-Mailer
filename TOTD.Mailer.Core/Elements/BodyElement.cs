using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Mailer.Templates;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class BodyElement : BaseElement
    {
        private List<BaseElement> _children;
        private string _styles;

        public BodyElement(string styles)
        {
            this._children = new List<BaseElement>();
            this._styles = styles;
        }

        public BodyElement AddElement(BaseElement element)
        {
            _children.Add(element);
            return this;
        }

        public BodyElement AddStyles(string styles)
        {
            _styles += styles;
            return this;
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();
            _children.NullSafeForEach(x => builder.Append(x.ToHtml()));

            Body body = new Body(builder.ToString(), _styles);
            return body.TransformText();
        }

        public override string ToText()
        {
            StringBuilder builder = new StringBuilder();
            _children.NullSafeForEach(x => builder.Append(x.ToText()));
            return builder.ToString();
        }
    }
}
