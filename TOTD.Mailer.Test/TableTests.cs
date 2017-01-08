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
            string r1c1 = "r1c1";
            string r1c2 = "r1c2";
            string r2c1 = "r2c1";
            string r2c2 = "r2c2";

            TableElement element = new TableElement(null)
                .BeginRow()
                    .AddCell(r1c1)
                    .AddCell(r1c2)
                .EndRow()
                .BeginRow()
                    .AddCell(r2c1)
                    .AddCell(r2c2)
                .EndRow();

            string html = element.ToHtml();
            Console.WriteLine(html);

            html.Should().Be($@"<table>
    <tr>
        <td>{r1c1}</td>
        <td>{r1c2}</td>
    </tr>
    <tr>
        <td>{r2c1}</td>
        <td>{r2c2}</td>
    </tr>
</table>
");
        }
    }
}
