using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Core.Elements
{
    public abstract class BaseContainerElement : BaseElement
    {
        public abstract void AddElement(BaseElement element);
    }
}
