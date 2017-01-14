using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Test
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        public void GeneratesCorrectHtml()
        {
            string header1 = "header1";
            string header2 = "header2";
            string r1c1 = "r1c1";
            string r1c2 = "r1c2";
            string r2c1 = "r2c1";
            string r2c2 = "r2c2";

            TableRowElement headerRow = new TableRowElement()
                .AddHeader(header1)
                .AddHeader(header2);

            TableRowElement row1 = new TableRowElement()
                .AddCell(r1c1)
                .AddCell(r1c2);

            TableRowElement row2 = new TableRowElement()
                .AddCell(r2c1)
                .AddCell(r2c2);

            TableElement element = new TableElement()
                .AddRow(headerRow)
                .AddRow(row1)
                .AddRow(row2);

            string html = element.ToHtml();
            Console.WriteLine(html);

            html.Should().Be($@"
<table class="""">
    <tr>
        <th class="""">{header1}</th>
        <th class="""">{header2}</th>
    </tr>
    <tr>
        <td class="""">{r1c1}</td>
        <td class="""">{r1c2}</td>
    </tr>
    <tr>
        <td class="""">{r2c1}</td>
        <td class="""">{r2c2}</td>
    </tr>
</table>
");
        }

        [TestMethod]
        public void GeneratesCorrectHtmlWithCssClass()
        {
            string r1c1 = "r1c1";
            string r1c2 = "r1c2";
            string css = "css";

            TableRowElement row1 = new TableRowElement()
                .AddCell(r1c1)
                .AddCell(r1c2);

            TableElement element = new TableElement()
                .AddClass(css)
                .AddRow(row1);

            string html = element.ToHtml();
            Console.WriteLine(html);

            html.Should().Be($@"
<table class=""{css}"">
    <tr>
        <td class="""">{r1c1}</td>
        <td class="""">{r1c2}</td>
    </tr>
</table>
");
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            string header1 = "header1";
            string header2 = "header2";
            string r1c1 = "r1c1";
            string r1c2 = "r1c2";

            TableRowElement headerRow = new TableRowElement()
                .AddHeader(header1)
                .AddHeader(header2);

            TableRowElement row1 = new TableRowElement()
                .AddCell(r1c1)
                .AddCell(r1c2);

            TableElement element = new TableElement()
                .AddRow(headerRow)
                .AddRow(row1);

            string text = element.ToText();
            Console.WriteLine(text);

            // Don't forget the trailing spaces for the last column
            text.Should().Be($@"
header1 header2 
r1c1    r1c2    

");
        }
    }
}
