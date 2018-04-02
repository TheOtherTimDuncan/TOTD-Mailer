using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using TOTD.Mailer.Core;

namespace TOTD.Mailer.Azure.Functions
{
    public static class MailtrapQueueFunction
    {
        [FunctionName("MailtrapQueueFunction")]
        public static Task RunAsync([QueueTrigger("email-mailtrap", Connection = "AzureWebJobsStorage")]EmailMessage emailMessage, TraceWriter log)
        {
            return MailtrapHelper.SendWithMailtrapAsync(emailMessage, log);
        }
    }
}
