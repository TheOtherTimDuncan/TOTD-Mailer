using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Test
{
    [TestClass]
    public class ButtonElementTests
    {
        [TestMethod]
        public void GeneratesCorrectHtml()
        {
            ButtonElement element = new ButtonElement("link", "content");

            element.ToHtml().Should()
                .StartWith("<table ")
                .And
                .Contain("<a ")
                .And
                .Contain($">{element.Content}</a>")
                .And
                .Contain($@" href=""{element.Link}""")
                .And
                .EndWith("</table>" + Environment.NewLine);
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            ButtonElement element = new ButtonElement("link", "content");

            element.ToText().Should()
                .StartWith("<a ")
                .And
                .Contain($@" href=""{element.Link}""")
                .And
                .EndWith($">{element.Content}</a>");
        }
    }
}
