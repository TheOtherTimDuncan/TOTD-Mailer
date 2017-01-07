using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Core.Elements
{
    public abstract class BaseContentElement : BaseElement
    {
        public string Content
        {
            get;
            set;
        }
    }
}
