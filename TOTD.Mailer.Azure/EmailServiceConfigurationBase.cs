using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Azure
{
    public abstract class EmailServiceConfigurationBase
    {
        public abstract string AzureConnectionString
        {
            get;
        }

        public abstract string EmailSendGridQueueName
        {
            get;
        }

        public abstract string EmailMailtrapQueueName
        {
            get;
        }

        public abstract string EmailBlobContainerName
        {
            get;
        }

        public abstract bool IsDebug
        {
            get;
        }
    }
}
