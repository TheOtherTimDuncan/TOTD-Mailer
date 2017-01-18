#load "../shared/mailtrap.csx"

using System;
using Newtonsoft.Json;
using TOTD.Mailer.Core;

public static void Run(string queueMessage, TraceWriter log)
{
    log.Info($"Processing {queueMessage}");

    EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(queueMessage);

    SendWithMailtrap(emailMessage, log);
}
