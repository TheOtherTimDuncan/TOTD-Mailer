using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PreMailer.Net;
using TOTD.Mailer.Core;
using TOTD.Utility.UnitTestHelpers;

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

            EmailMessage message = EmailBuilder.Begin()
                .AddText("text")
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

        [TestMethod]
        public void CanGenerateBodyHtmlAndText()
        {

            EmailMessage message = EmailBuilder.Begin()
                .AddStyles(".test-table {border-collapse: collapse;} .test-table td, .test-table th { border: darkgray 1px solid;}")
                .AddParagraph("This is a paragaraph.")
                .BeginParagraph()
                    .AddText("This is line 1.")
                    .AddLineBreak()
                    .AddText("This is line 2.")
                .EndParagraph()
                .AddLink("https://google.com", "Go to Google")
                .AddLineBreak()
                .AddLineBreak()
                .AddButton("https://google.com", "Go to Google")
                .AddImage("http://lorempixel.com/400/200/cats", "Sample Image")
                .BeginTable(className: "test-table")
                    .BeginTableRow()
                        .AddTableHeader("header1")
                        .AddTableHeader("header2")
                    .EndTableRow()
                    .BeginTableRow()
                        .AddTableCell("Row 1 Cell 1")
                        .AddTableCell("Row 1 Cell 2")
                    .EndTableRow()
                    .BeginTableRow()
                        .AddTableCell("Row 2 Cell 1")
                        .AddTableCell("Row 2 Cell 2")
                    .EndTableRow()
                .EndTable()
                .ToEmail();

            string folder = Path.Combine(UnitTestHelper.GetSolutionRoot(), "TestResults");

            InlineResult result = PreMailer.Net.PreMailer.MoveCssInline(message.HtmlBody, removeStyleElements: true, ignoreElements: "#ignore");
            File.WriteAllText(Path.Combine(folder, "test-inlined.html"), result.Html);

            File.WriteAllText(Path.Combine(folder, "test.html"), message.HtmlBody);
            File.WriteAllText(Path.Combine(folder, "test.txt"), message.TextBody);

            string json = JsonConvert.SerializeObject(message);
            File.WriteAllText(Path.Combine(folder, "email.json"), json);
        }
    }
}
