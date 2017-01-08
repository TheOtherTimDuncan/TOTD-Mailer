using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Test
{
    [TestClass]
    public class TableRowTests
    {
        [TestMethod]
        public void GeneratesCorrectHtml()
        {
            string cell1 = "cell1";
            string cell2 = "cell2";

            TableRowElement row = new TableRowElement(null)
                .AddCell(cell1)
                .AddCell(cell2);

            row.ToHtml().Should().Be($@"    <tr>
        <td>{cell1}</td>
        <td>{cell2}</td>
    </tr>
");
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            string cell1 = "123";
            string cell2 = "1234";

            TableRowElement row = new TableRowElement(null)
                .AddCell(cell1)
                .AddCell(cell2);

            row.ToText(new[] { 5, 5 }).Should().Be($"{cell1}   {cell2}  {Environment.NewLine}");
        }
    }
}
