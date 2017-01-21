using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using TOTD.Mailer.Core;

namespace TOTD.Mailer.Azure
{
    public class EmailService
    {
        private EmailServiceConfigurationBase _configuration;

        public EmailService(bool fromAppSettings = false)
            : this(fromAppSettings ? new EmailServiceAppSettingsConfiguration() : new EmailServiceConfiguration())
        {
        }

        public EmailService(EmailServiceConfigurationBase configuration)
        {
            this._configuration = configuration;
        }

        public async Task SendSmallEmailAsync(EmailMessage emailMessage)
        {
            byte[] emailData = SerializeEmailMessage(emailMessage);
            await AddEmailToQueue(emailData);
        }

        public async Task SendLargeEmailAsync(EmailMessage emailMessage)
        {
            byte[] emailData = SerializeEmailMessage(emailMessage);
            await AddEmailToBlob(emailData);
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            byte[] emailData = SerializeEmailMessage(emailMessage);
            if (emailData.Length >= CloudQueueMessage.MaxMessageSize)
            {
                await AddEmailToBlob(emailData);
            }
            else
            {
                await AddEmailToQueue(emailData);
            }
        }

        private byte[] SerializeEmailMessage(EmailMessage emailMessage)
        {
            string json = JsonConvert.SerializeObject(emailMessage);
            return Encoding.UTF8.GetBytes(json);
        }

        private async Task AddEmailToQueue(byte[] emailData)
        {
            CloudQueueClient client = GetStorageAccount().CreateCloudQueueClient();
            CloudQueue cloudQueue = client.GetQueueReference(_configuration.IsDebug ? _configuration.EmailMailtrapQueueName : _configuration.EmailSendGridQueueName);
            await cloudQueue.CreateIfNotExistsAsync();
            CloudQueueMessage queueMessage = new CloudQueueMessage(emailData);
            await cloudQueue.AddMessageAsync(queueMessage);
        }

        private async Task AddEmailToBlob(byte[] emailData)
        {
            CloudBlobClient client = GetStorageAccount().CreateCloudBlobClient();

            CloudBlobContainer container = client.GetContainerReference(_configuration.EmailBlobContainerName);
            await container.CreateIfNotExistsAsync();

            await container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            string blobName = _configuration.IsDebug ? "mailtrap" : "sendgrid";
            CloudBlockBlob blob = container.GetBlockBlobReference($"{blobName}-{Guid.NewGuid()}.json");
            await blob.UploadFromByteArrayAsync(emailData, index: 0, count: emailData.Length);
        }

        private CloudStorageAccount GetStorageAccount()
        {
            return CloudStorageAccount.Parse(_configuration.AzureConnectionString);
        }
    }
}
