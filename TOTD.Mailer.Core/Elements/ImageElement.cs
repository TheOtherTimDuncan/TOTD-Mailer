using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Core.Elements
{
    public class ImageElement : BaseElement
    {
        public string Source
        {
            get;
            set;
        }

        public string Alt
        {
            get;
            set;
        }

        public override string ToHtml()
        {
            return $@"<img src=""{Source}"" alt=""{Alt}"" width="""" height="""" border=""0"" style=""border: 0; outline: none; text-decoration: none; display:block;"">";
        }

        public override string ToText()
        {
            return string.Empty;
        }
    }
}
