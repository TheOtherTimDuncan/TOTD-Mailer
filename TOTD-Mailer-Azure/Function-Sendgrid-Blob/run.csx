#load "../shared/sendgrid.csx"

using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;

public static async Task<Mail> Run(CloudBlockBlob blob, TraceWriter log)
{
    string json = await blob.DownloadTextAsync();
    EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(json);
    Mail message = SendWithSendGrid(emailMessage, log);
    await blob.DeleteAsync();
    return message;
}
