using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using TOTD.Mailer.Azure;
using TOTD.Mailer.Core;

namespace TOTD.Mailer.Test.AzureTests
{
    [TestClass]
    public class EmailServiceTests
    {
        [TestMethod]
        public async Task CanSendDebugEmailUsingAzureQueue()
        {
            EmailMessage emailMessage = CreateTestEmailMessage();

            TestEmailServiceConfiguration configuration = new TestEmailServiceConfiguration(isDebug: true);

            EmailService emailService = new EmailService(configuration);
            await emailService.SendSmallEmailAsync(emailMessage);

            EmailMessage result = await DequeueEmailMessage(configuration.AzureConnectionString, configuration.EmailMailtrapQueueName);
            VerifyEmailMessage(emailMessage, result);
        }

        [TestMethod]
        public async Task CanSendNonDebugEmailUsingAzureQueue()
        {
            EmailMessage emailMessage = CreateTestEmailMessage();

            TestEmailServiceConfiguration configuration = new TestEmailServiceConfiguration(isDebug: false);

            EmailService emailService = new EmailService(configuration);
            await emailService.SendSmallEmailAsync(emailMessage);

            EmailMessage result = await DequeueEmailMessage(configuration.AzureConnectionString, configuration.EmailSendGridQueueName);
            VerifyEmailMessage(emailMessage, result);
        }

        [TestMethod]
        public async Task CanSendDebugEmailUsingAzureBlob()
        {
            EmailMessage emailMessage = CreateTestEmailMessage();

            TestEmailServiceConfiguration configuration = new TestEmailServiceConfiguration(isDebug: true);

            EmailService emailService = new EmailService(configuration);
            await emailService.SendLargeEmailAsync(emailMessage);

            EmailMessage result = await GetEmailMessageFromBlob(configuration.AzureConnectionString, configuration.EmailBlobContainerName, "mailtrap");
            VerifyEmailMessage(emailMessage, result);
        }

        [TestMethod]
        public async Task CanSendNonDebugEmailUsingAzureBlob()
        {
            EmailMessage emailMessage = CreateTestEmailMessage();

            TestEmailServiceConfiguration configuration = new TestEmailServiceConfiguration(isDebug: false);

            EmailService emailService = new EmailService(configuration);
            await emailService.SendLargeEmailAsync(emailMessage);

            EmailMessage result = await GetEmailMessageFromBlob(configuration.AzureConnectionString, configuration.EmailBlobContainerName, "sendgrid");
            VerifyEmailMessage(emailMessage, result);
        }

        private EmailMessage CreateTestEmailMessage()
        {
            return new EmailMessage()
            {
                Bcc = new[] { "bcc" },
                Cc = new[] { "cc" },
                From = "from",
                To = new[] { "to" },
                Subject = "subject",
                HtmlBody = "htmlbody",
                TextBody = "textbody"
            };
        }

        private void VerifyEmailMessage(EmailMessage source, EmailMessage result)
        {
            result.Bcc.Should().Equal(source.Bcc);
            result.Cc.Should().Equal(source.Cc);
            result.To.Should().Equal(source.To);
            result.From.Should().Equals(source.From);
            result.Subject.Should().Be(source.Subject);
            result.HtmlBody.Should().Be(source.HtmlBody);
            result.TextBody.Should().Be(source.TextBody);
        }

        private async Task<EmailMessage> DequeueEmailMessage(string connectionString, string queueName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudQueueClient client = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference(queueName);

            CloudQueueMessage queueMessage = await queue.GetMessageAsync();
            string json = queueMessage.AsString;

            await queue.DeleteAsync();

            EmailMessage result = JsonConvert.DeserializeObject<EmailMessage>(json);
            return result;
        }

        private async Task<EmailMessage> GetEmailMessageFromBlob(string connnectionString, string containerName, string namePrefix)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connnectionString);
            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference(containerName);

            IEnumerable<IListBlobItem> blobItems = container.ListBlobs(prefix: namePrefix);
            blobItems.Should().HaveCount(1);

            CloudBlockBlob blob = blobItems.First() as CloudBlockBlob;
            blob.Should().NotBeNull();
            string json = await blob.DownloadTextAsync();

            await container.DeleteAsync();

            EmailMessage result = JsonConvert.DeserializeObject<EmailMessage>(json);
            return result;
        }
    }
}
