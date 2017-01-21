using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace TOTD.Mailer.Azure
{
    /// <summary>
    /// Gets the configuration options from the <AppSettings/> section of the configuration file
    /// Keys should be prefixed with "totd-email-azure"
    /// </summary>
    public class EmailServiceAppSettingsConfiguration : EmailServiceConfigurationBase
    {
        public string GetSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[$"totd-email-azure-{settingName}"];
        }

        public override string AzureConnectionString
        {
            get
            {
                return GetSetting("connectionstring");
            }
        }

        public override string EmailSendGridQueueName
        {
            get
            {
                return GetSetting("sendgrid-queue-name");
            }
        }

        public override string EmailMailtrapQueueName
        {
            get
            {
                return GetSetting("mailtrap-queue-name");
            }
        }

        public override string EmailBlobContainerName
        {
            get
            {
                return GetSetting("blob-container-name").ToLower();
            }
        }

        public override bool IsDebug
        {
            get
            {
                return GetSetting("debug") == "True";
            }
        }
    }
}
