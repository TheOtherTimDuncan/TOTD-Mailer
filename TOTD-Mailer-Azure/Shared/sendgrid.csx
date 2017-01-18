using System;
using System.Net.Mime;
using PreMailer.Net;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;

public static Mail SendWithSendGrid(EmailMessage emailMessage, TraceWriter log)
{
    Personalization personalization = new Personalization();
    emailMessage.ToForEach(x => personalization.AddTo(new Email(x)));
    emailMessage.BccForEach(x => personalization.AddBcc(new Email(x)));
    emailMessage.CcForEach(x => personalization.AddCc(new Email(x)));

    Mail message = new Mail();
    message.From = new Email(emailMessage.From);
    message.Subject = emailMessage.Subject;
    message.AddPersonalization(personalization);

    Content textContent = new Content(MediaTypeNames.Text.Plain, emailMessage.TextBody);
    message.AddContent(textContent);

    InlineResult result = PreMailer.Net.PreMailer.MoveCssInline(emailMessage.HtmlBody, removeStyleElements: true, ignoreElements: "#ignore");

    Content htmlContent = new Content(MediaTypeNames.Text.Html, result.Html);
    message.AddContent(htmlContent);

    log.Info($"Sending {message.Get()}");

    return message;
}
