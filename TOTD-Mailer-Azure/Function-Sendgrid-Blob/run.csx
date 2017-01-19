#load "../shared/sendgrid.csx"

using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;

public static void Run(string emailMessage, TraceWriter log, out Mail message)
{
    string json = await blob.DownloadTextAsync();
    EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(json);
    message = SendWithSendGrid(queueMessage, log);
    await blob.DeleteAsync();
}
