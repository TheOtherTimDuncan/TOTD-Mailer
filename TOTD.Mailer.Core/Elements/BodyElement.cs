using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Mailer.Html;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class BodyElement : BaseElement
    {
        public IEnumerable<BaseElement> Elements
        {
            get;
            set;
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();
            Elements.NullSafeForEach(x => builder.Append(x.ToHtml()));

            Body body = new Body(builder.ToString());
            return body.TransformText();
        }

        public override string ToText()
        {
            StringBuilder builder = new StringBuilder();
            Elements.NullSafeForEach(x => builder.Append(x.ToText()));
            return builder.ToString();
        }
    }
}
