using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Test
{
    [TestClass]
    public class ParagraphElementTests
    {
        [TestMethod]
        public void GeneratesCorrectHtml()
        {
            string content = "content";

            ParagraphElement element = new ParagraphElement().AddText(content);

            element.ToHtml().Should().Be($"<p>{content}</p>");
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            string content = "content";

            ParagraphElement element = new ParagraphElement().AddText(content);

            element.ToText().Should().Be(content + Environment.NewLine);
        }
    }
}
