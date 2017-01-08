using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Templates
{
    public partial class Button
    {
        public Button(string link, string content)
        {
            this.Content = content;
            this.Link = link;
        }

        public string Link
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }
    }
}
