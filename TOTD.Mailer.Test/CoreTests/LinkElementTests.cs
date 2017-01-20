using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Test.CoreTests
{
    [TestClass]
    public class LinkElementTests
    {
        [TestMethod]
        public void GeneratesCorrectHtml()
        {
            LinkElement element = new LinkElement("link", "content");

            element.ToHtml().Should()
                .StartWith("<a ")
                .And
                .Contain($@" href=""{element.Link}""")
                .And
                .EndWith($">{element.Content}</a>");
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            LinkElement element = new LinkElement("link", "content");

            element.ToText().Should().Be(element.ToHtml() + Environment.NewLine);
        }
    }
}
