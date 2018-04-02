using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using TOTD.Mailer.Core;

namespace TOTD.Mailer.Azure.Functions
{
    public static class MailtrapBlobFunction
    {
        [FunctionName("MailtrapBlobFunction")]
        public static async Task RunAsync([BlobTrigger("emails/mailtrap-{name}", Connection = "AzureWebJobsStorage")]CloudBlockBlob blob, TraceWriter log)
        {
            string json = await blob.DownloadTextAsync();
            EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(json);
            await MailtrapHelper.SendWithMailtrapAsync(emailMessage, log);
            await blob.DeleteAsync();
        }
    }
}
