using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Core.Elements
{
    public class TextElement : BaseContentElement
    {
        public TextElement(string text)
        {
            this.Content = text;
        }

        public override string ToHtml()
        {
            return Content;
        }

        public override string ToText()
        {
            return Content;
        }
    }
}
