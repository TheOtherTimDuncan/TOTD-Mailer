using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core.Elements;
using TOTD.Utility.UnitTestHelpers;

namespace TOTD.Mailer.Test
{
    [TestClass]
    public class BodyElementTests
    {
        [TestMethod]
        public void CanGenerateBodyHtmlAndText()
        {
            ParagraphElement paragraph1 = new ParagraphElement().AddText("This is a paragaraph.");

            ParagraphElement paragraph2 = new ParagraphElement()
                .AddText("This is line 1.")
                .AddElement(new LineBreakElement())
                .AddText("This is line 2.");

            LinkElement link = new LinkElement()
            {
                Link = "https://google.com",
                Content = "Go to Google"
            };

            ButtonElement button = new ButtonElement()
            {
                Link = "https://google.com",
                Content = "Go to Google"
            };

            ImageElement image = new ImageElement()
            {
                Source = "http://lorempixel.com/400/200/cats",
                Alt = "Sample Image"
            };

            LineBreakElement lineBreak = new LineBreakElement();

            BodyElement bodyElement = new BodyElement();
            bodyElement.Elements = new BaseElement[] { paragraph1, paragraph2, link, lineBreak, lineBreak, image, button };

            File.WriteAllText(Path.Combine(UnitTestHelper.GetSolutionRoot(), "TestResults", "test.html"), bodyElement.ToHtml());
            File.WriteAllText(Path.Combine(UnitTestHelper.GetSolutionRoot(), "TestResults", "test.txt"), bodyElement.ToText());
        }
    }
}
