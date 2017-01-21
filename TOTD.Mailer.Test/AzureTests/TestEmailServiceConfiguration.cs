using System;
using System.Collections.Generic;
using System.Linq;
using TOTD.Mailer.Azure;

namespace TOTD.Mailer.Test.AzureTests
{
    public class TestEmailServiceConfiguration : EmailServiceConfiguration
    {
        private bool _isDebug;

        public TestEmailServiceConfiguration(bool isDebug)
        {
            this._isDebug = isDebug;
        }

        public override bool IsDebug
        {
            get
            {
                return _isDebug;
            }
        }
    }
}
