using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Mailer.Azure
{
    public class EmailServiceConfiguration : EmailServiceAppSettingsConfiguration
    {
        public override string EmailBlobContainerName
        {
            get
            {
                return "emails";
            }
        }

        public override string EmailSendGridQueueName
        {
            get
            {
                return "email-sendgrid";
            }
        }

        public override string EmailMailtrapQueueName
        {
            get
            {
                return "email-mailtrap";
            }
        }
    }
}
