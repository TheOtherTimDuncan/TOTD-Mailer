﻿using System;
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

            TableCell element = new TableCell().AddText(content);

            element.ToHtml().Should().Be($"    <td>{content}</td>" + Environment.NewLine);
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            string content = "content";

            TableCell element = new TableCell().AddText(content);

            element.ToText().Should().Be(content);
        }
    }
}
