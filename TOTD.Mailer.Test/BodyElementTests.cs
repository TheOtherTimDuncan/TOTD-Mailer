using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mailer.Core;
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
            BodyElement body = new BodyElement(null)
                .AddParagraph("This is a paragaraph.")
                .BeginParagraph()
                    .AddText("This is line 1.")
                    .AddElement(new LineBreakElement())
                    .AddText("This is line 2.")
                .EndParagraph()
                .AddLink("https://google.com", "Go to Google")
                .AddLineBreak()
                .AddLineBreak()
                .AddButton("https://google.com", "Go to Google")
                .AddImage("http://lorempixel.com/400/200/cats", "Sample Image");


            File.WriteAllText(Path.Combine(UnitTestHelper.GetSolutionRoot(), "TestResults", "test.html"), body.ToHtml());
            File.WriteAllText(Path.Combine(UnitTestHelper.GetSolutionRoot(), "TestResults", "test.txt"), body.ToText());
        }
    }
}
