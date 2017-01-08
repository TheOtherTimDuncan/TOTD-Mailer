using System;
using System.Collections.Generic;
using System.Linq;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core
{
    public class EmailMessage
    {
        public string From
        {
            get;
            set;
        }

        public IEnumerable<string> To
        {
            get;
            set;
        }

        public IEnumerable<string> Bcc
        {
            get;
            set;
        }

        public IEnumerable<string> Cc
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string TextBody
        {
            get;
            set;
        }

        public string HtmlBody
        {
            get;
            set;
        }

        public void ToForEach(Action<string> action)
        {
            To.NullSafeForEach(x => action(x));
        }

        public void BccForEach(Action<string> action)
        {
            Bcc.NullSafeForEach(x => action(x));
        }

        public void CcForEach(Action<string> action)
        {
            Cc.NullSafeForEach(x => action(x));
        }
    }
}
