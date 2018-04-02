using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;

namespace TOTD.Mailer.Azure.Functions
{
    public static class SendgridBlobFunction
    {
        [FunctionName("SendgridBlobFunction")]
        public static void Run([BlobTrigger("emails/sendgrid-{name}", Connection = "AzureWebJobsStorage")]CloudBlockBlob blob, TraceWriter log, [SendGrid(ApiKey = "AzureWebJobsSendGridApiKey")] out SendGridMessage message)
        {
            string json = blob.DownloadText();
            EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(json);
            message = SendGridHelper.SendWithSendGrid(emailMessage, log);
            blob.Delete();
        }
    }
}
