using System;
using System.Collections.Generic;
using System.Linq;
using TOTD.Mailer.Templates;

namespace TOTD.Mailer.Core.Elements
{
    public class ButtonElement : LinkElement
    {
        public override string ToHtml()
        {
            Button button = new Button(Link, Content);
            return button.TransformText();
        }

        public override string ToText()
        {
            return base.ToHtml();
        }
    }
}
