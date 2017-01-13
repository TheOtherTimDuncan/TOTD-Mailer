using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Core.Elements
{
    public class ImageElement : BaseElement
    {
        public ImageElement(string source, string alt)
        {
            this.Source = source;
            this.Alt = alt;
        }

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
            return $@"<img src=""{Source}"" alt=""{Alt}"" width="""" height="""" border=""0"">";
        }

        public override string ToText()
        {
            return string.Empty;
        }
    }
}
