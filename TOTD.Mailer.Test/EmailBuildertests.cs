using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core;

namespace TOTD.Mailer.Test
{
    [TestClass]
    public class EmailBuilderTests
    {
        [TestMethod]
        public void CanGenerateEmailMessage()
        {
            string subject = "subject";
            string emailFrom = "from";
            string emailTo = "to";
            string emailBcc = "bcc";
            string emailCc = "cc";

            EmailMessage message = EmailBuilder
                .BeginBody()
                    .AddText("text")
                .EndBody()
                .WithSubject(subject)
                .To(emailTo)
                .From(emailFrom)
                .Cc(emailCc)
                .Bcc(emailBcc)
                .ToEmail();

            message.Should().NotBeNull();
            message.From.Should().Be(emailFrom);
            message.To.Should().Equal(new[] { emailTo, });
            message.Bcc.Should().Equal(new[] { emailBcc });
            message.Cc.Should().Equal(new[] { emailCc });
            message.Subject.Should().Be(subject);
            message.HtmlBody.Should().NotBeNullOrEmpty();
            message.TextBody.Should().NotBeNullOrEmpty();
        }
    }
}
