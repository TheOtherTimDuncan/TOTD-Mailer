#load "../shared/sendgrid.csx"

using System;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;

public static void Run(EmailMessage queueMessage, TraceWriter log, out Mail message)
{
    message = SendWithSendGrid(queueMessage, log);
}
