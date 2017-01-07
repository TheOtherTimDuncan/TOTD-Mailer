using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Core.Elements
{
    public class LinkElement : BaseContentElement
    {
        public string Link
        {
            get;
            set;
        }

        public override string ToHtml()
        {
            return $@"<a href=""{Link}"">{Content}</a>";
        }

        public override string ToText()
        {
            return ToHtml();
        }
    }
}
