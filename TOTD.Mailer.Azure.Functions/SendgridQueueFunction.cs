using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;

namespace TOTD.Mailer.Azure.Functions
{
    public static class SendgridQueueFunction
    {
        [FunctionName("SendgridQueueFunction")]
        public static void Run([QueueTrigger("email-sendgrid", Connection = "AzureWebJobsStorage")]EmailMessage queueMessage, TraceWriter log, [SendGrid(ApiKey = "AzureWebJobsSendGridApiKey")] out SendGridMessage message)
        {
            message = SendGridHelper.SendWithSendGrid(queueMessage, log);
        }
    }
}
