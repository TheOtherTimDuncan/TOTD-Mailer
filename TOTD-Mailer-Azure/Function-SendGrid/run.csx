#load "../shared/sendgrid.csx"

using System;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;

public static void Run(string queueMessage, TraceWriter log, out Mail message)
{
    log.Info($"Processing {queueMessage}");

    EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(queueMessage);

    message = SendWithSendGrid(emailMessage, log);
}
