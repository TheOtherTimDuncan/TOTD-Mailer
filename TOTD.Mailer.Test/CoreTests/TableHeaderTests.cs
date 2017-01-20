using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Test.CoreTests
{
    [TestClass]
    public class TableHeaderTests
    {
        [TestMethod]
        public void GeneratesCorrectHtml()
        {
            string content = "content";

            TableHeaderElement element = new TableHeaderElement();
            element.AddText(content);

            element.ToHtml().Should().Be($@"    <th class="""">{content}</th>" + Environment.NewLine);
        }

        [TestMethod]
        public void GeneratesCorrectHtmlWithCssClas()
        {
            string content = "content";
            string css = "css";

            TableHeaderElement element = new TableHeaderElement();
            element.AddText(content);
            element.AddClass(css);

            element.ToHtml().Should().Be($@"    <th class=""{css}"">{content}</th>" + Environment.NewLine);
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            string content = "content";

            TableHeaderElement element = new TableHeaderElement();
            element.AddText(content);

            element.ToText().Should().Be(content);
        }
    }
}
