#load "../shared/mailtrap.csx"

using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using TOTD.Mailer.Core;

public static async Task Run(CloudBlockBlob blob, TraceWriter log)
{
    string json = await blob.DownloadTextAsync();
    EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(json);
    SendWithMailtrap(emailMessage, log);
    await blob.DeleteAsync();
}
