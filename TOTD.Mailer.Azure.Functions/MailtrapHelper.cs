using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using PreMailer.Net;
using TOTD.Mailer.Core;

namespace TOTD.Mailer.Azure.Functions
{
    public class MailtrapHelper
    {
        public static async Task SendWithMailtrapAsync(EmailMessage emailMessage, TraceWriter log)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Host = Environment.GetEnvironmentVariable("Smtp-Host");
                smtpClient.Port = Convert.ToInt32(Environment.GetEnvironmentVariable("Smtp-Port"));
                smtpClient.Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("Smtp-User"), Environment.GetEnvironmentVariable("Smtp-Password"));
                smtpClient.EnableSsl = true;

                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(emailMessage.From);

                    emailMessage.ToForEach(x => message.To.Add(x));
                    emailMessage.BccForEach(x => message.Bcc.Add(x));
                    emailMessage.CcForEach(x => message.CC.Add(x));

                    message.Subject = emailMessage.Subject;

                    InlineResult result = PreMailer.Net.PreMailer.MoveCssInline(emailMessage.HtmlBody, removeStyleElements: true, ignoreElements: "#ignore");

                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(result.Html, Encoding.UTF8, MediaTypeNames.Text.Html);
                    message.AlternateViews.Add(htmlView);

                    AlternateView textView = AlternateView.CreateAlternateViewFromString(emailMessage.TextBody, Encoding.UTF8, MediaTypeNames.Text.Plain);
                    message.AlternateViews.Add(textView);

                    await smtpClient.SendMailAsync(message);
                }

                log.Info("Email sent");
            }
        }
    }

}
