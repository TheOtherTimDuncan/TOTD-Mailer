using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Html
{
    public partial class Body
    {
        public Body(string content)
        {
            this.Content = content;
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
