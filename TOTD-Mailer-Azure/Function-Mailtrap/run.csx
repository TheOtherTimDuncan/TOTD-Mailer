#load "../shared/mailtrap.csx"

using System;
using TOTD.Mailer.Core;

public static void Run(EmailMessage queueMessage, TraceWriter log)
{
    SendWithMailtrap(queueMessage, log);
}
