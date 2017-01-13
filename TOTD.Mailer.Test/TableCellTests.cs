using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Test
{
    [TestClass]
    public class TableCellTests
    {
        [TestMethod]
        public void GeneratesCorrectHtml()
        {
            string content = "content";

            TableCellElement element = new TableCellElement().AddText(content);

            element.ToHtml().Should().Be($@"    <td class="""">{content}</td>" + Environment.NewLine);
        }

        [TestMethod]
        public void GeneratesCorrectHtmlWithCssClas()
        {
            string content = "content";
            string css = "css";

            TableCellElement element = new TableCellElement()
                .AddText(content)
                .AddClass(css);

            element.ToHtml().Should().Be($@"    <td class=""{css}"">{content}</td>" + Environment.NewLine);
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            string content = "content";

            TableCellElement element = new TableCellElement().AddText(content);

            element.ToText().Should().Be(content);
        }
    }
}
