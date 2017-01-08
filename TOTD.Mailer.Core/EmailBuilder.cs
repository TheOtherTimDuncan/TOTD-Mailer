using System;
using System.Collections.Generic;
using System.Linq;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Core
{
    public class EmailBuilder
    {
        private EmailMessage _email;

        public static BodyElement BeginBody()
        {
            return new EmailBuilder().Body;
        }

        private EmailBuilder()
        {
            Body = new BodyElement(this);
        }

        private BodyElement Body
        {
            get;
        }

        private EmailMessage Message
        {
            get
            {
                if (_email == null)
                {
                    _email = new EmailMessage();
                }
                return _email;
            }
        }

        public EmailBuilder WithSubject(string subject)
        {
            Message.Subject = subject;
            return this;
        }

        public EmailBuilder From(string fromEmail)
        {
            Message.From = fromEmail;
            return this;
        }

        public EmailBuilder To(string email)
        {
            Message.To = new[] { email };
            return this;
        }

        public EmailBuilder To(params string[] emails)
        {
            Message.To = emails;
            return this;
        }

        public EmailBuilder Bcc(string email)
        {
            Message.Bcc = new[] { email };
            return this;
        }

        public EmailBuilder Bcc(params string[] emails)
        {
            Message.Bcc = emails;
            return this;
        }

        public EmailBuilder Cc(string email)
        {
            Message.Cc = new[] { email };
            return this;
        }

        public EmailBuilder Cc(params string[] emails)
        {
            Message.Cc = emails;
            return this;
        }

        public string ToText()
        {
            return Body.ToText();
        }

        public string ToHtml()
        {
            return Body.ToHtml();
        }

        public EmailMessage ToEmail()
        {
            Message.HtmlBody = Body.ToHtml();
            Message.TextBody = Body.ToText();
            return Message;
        }
    }
}
