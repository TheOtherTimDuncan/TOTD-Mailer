using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Core.Elements
{
    public class LineBreakElement : BaseContentElement
    {
        public string TextAlternative
        {
            get;
            set;
        } = Environment.NewLine;

        public override string ToHtml()
        {
            return "<br>";
        }

        public override string ToText()
        {
            return TextAlternative;
        }
    }
}
