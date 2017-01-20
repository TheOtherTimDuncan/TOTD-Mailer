using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;

namespace TOTD.Mailer.Test.CoreTests
{
    [TestClass]
    public class ImageElementTests
    {
        [TestMethod]
        public void GeneratesCorrectHtml()
        {
            ImageElement element = new ImageElement("source", "alt");

            element.ToHtml().Should()
                .StartWith("<img ")
                .And
                .Contain($@" alt=""{element.Alt}""")
                .And
                .Contain($@" src=""{element.Source}""")
                .And
                .EndWith(">");
        }

        [TestMethod]
        public void GeneratesCorrectText()
        {
            ImageElement element = new ImageElement("source", "alt");
            element.ToText().Should().BeEmpty();
        }
    }
}
