using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Core.Elements
{
    public abstract class BaseElement
    {
        public abstract string ToText();
        public abstract string ToHtml();
    }
}
