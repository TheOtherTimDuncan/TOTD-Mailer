using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Templates
{
    public partial class Body
    {
        public Body(string content, string styles)
        {
            this.Content = content;
            this.Styles = styles;
        }

        public string Styles
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public string Footer
        {
            get;
            set;
        }
    }
}
