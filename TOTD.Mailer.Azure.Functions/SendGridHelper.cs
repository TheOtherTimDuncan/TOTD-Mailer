using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Microsoft.Azure.WebJobs.Host;
using PreMailer.Net;
using SendGrid.Helpers.Mail;
using TOTD.Mailer.Core;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Azure.Functions
{
    public class SendGridHelper
    {
        public static SendGridMessage SendWithSendGrid(EmailMessage emailMessage, TraceWriter log)
        {
            Personalization personalization = new Personalization();
            personalization.Tos = emailMessage.To.NullSafeSelect(x => new EmailAddress(x)).ToList();

            if (!emailMessage.Bcc.IsNullOrEmpty())
            {
                personalization.Bccs = emailMessage.Bcc.Select(x => new EmailAddress(x)).ToList();
            }

            if (!emailMessage.Cc.IsNullOrEmpty())
            {
                personalization.Ccs = emailMessage.Cc.Select(x => new EmailAddress(x)).ToList();
            }

            SendGridMessage message = new SendGridMessage
            {
                From = new EmailAddress(emailMessage.From),
                Subject = emailMessage.Subject
            };

            message.Personalizations = new List<Personalization>
            {
                personalization
            };

            message.AddContent(MediaTypeNames.Text.Plain, emailMessage.TextBody);

            InlineResult result = PreMailer.Net.PreMailer.MoveCssInline(emailMessage.HtmlBody, removeStyleElements: true, ignoreElements: "#ignore");
            message.AddContent(MediaTypeNames.Text.Html, result.Html);

            log.Info($"Sending {message.Serialize()}");

            return message;
        }
    }
}
