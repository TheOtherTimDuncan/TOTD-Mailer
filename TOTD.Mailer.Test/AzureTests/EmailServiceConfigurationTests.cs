using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Azure;

namespace TOTD.Mailer.Test.AzureTests
{
    [TestClass]
    public class EmailServiceConfigurationTests
    {
        [TestMethod]
        public void CanReadAzureConnectionStringFromAppConfig()
        {
            new EmailServiceAppSettingsConfiguration().AzureConnectionString.Should().Be("UseDevelopmentStorage=true");
        }

        [TestMethod]
        public void CanReadEmailSendGridQueueNameFromAppConfig()
        {
            new EmailServiceAppSettingsConfiguration().EmailSendGridQueueName.Should().Be("sendgrid");
        }

        [TestMethod]
        public void CanReadEmailMailtrapQueueNameFromAppConfig()
        {
            new EmailServiceAppSettingsConfiguration().EmailMailtrapQueueName.Should().Be("mailtrap");
        }

        [TestMethod]
        public void CanReadEmailBlobContainerNameFromAppConfig()
        {
            new EmailServiceAppSettingsConfiguration().EmailBlobContainerName.Should().Be("blobcontainer");
        }

        [TestMethod]
        public void CanReadIsDebugFromAppConfig()
        {
            new EmailServiceAppSettingsConfiguration().IsDebug.Should().BeTrue();
        }
    }
}
