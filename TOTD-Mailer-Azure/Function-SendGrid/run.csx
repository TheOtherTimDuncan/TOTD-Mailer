#r "../Shared/TOTD.Mailer.Core.dll"

using System;
using System.Net.Mime;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;

public static void Run(string queueMessage, TraceWriter log, out Mail message)
{
    log.Info($"Processing {queueMessage}");

    EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(queueMessage);

    Personalization personalization = new Personalization();
    emailMessage.ToForEach(x => personalization.AddTo(new Email(x)));
    emailMessage.BccForEach(x => personalization.AddBcc(new Email(x)));
    emailMessage.CcForEach(x => personalization.AddCc(new Email(x)));

    message = new Mail();
    message.From = new Email(emailMessage.From);
    message.Subject = emailMessage.Subject;
    message.AddPersonalization(personalization);

    Content textContent = new Content(MediaTypeNames.Text.Plain, emailMessage.TextBody);
    message.AddContent(textContent);

    Content htmlContent = new Content(MediaTypeNames.Text.Html, emailMessage.HtmlBody);
    message.AddContent(htmlContent);

    log.Info($"Sending {message.Get()}");
}
