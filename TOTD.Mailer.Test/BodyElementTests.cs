using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreMailer.Net;
using TOTD.Mailer.Core.Elements;
using TOTD.Mailer.Templates;
using TOTD.Utility.UnitTestHelpers;

namespace TOTD.Mailer.Test
{
    [TestClass]
    public class BodyElementTests
    {
        [TestMethod]
        public void CanGenerateBodyHtmlAndText()
        {
            DefaultStyles defaultStyles = new DefaultStyles();

            BodyElement body = new BodyElement(null, defaultStyles.TransformText())
                .AddStyles(".test-table {border-collapse: collapse;} .test-table td, .test-table th { border: darkgray 1px solid;}")
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
                .AddImage("http://lorempixel.com/400/200/cats", "Sample Image")
                .BeginTable(className: "test-table")
                    .BeginRow()
                        .AddCell("Row 1 Cell 1")
                        .AddCell("Row 1 Cell 2")
                    .EndRow()
                    .BeginRow()
                        .AddCell("Row 2 Cell 1")
                        .AddCell("Row 2 Cell 2")
                    .EndRow()
                .EndTable();

            InlineResult result = PreMailer.Net.PreMailer.MoveCssInline(body.ToHtml(), removeStyleElements: true, ignoreElements: "#ignore");
            File.WriteAllText(Path.Combine(UnitTestHelper.GetSolutionRoot(), "TestResults", "test-inlined.html"), result.Html);

            File.WriteAllText(Path.Combine(UnitTestHelper.GetSolutionRoot(), "TestResults", "test.html"), body.ToHtml());
            File.WriteAllText(Path.Combine(UnitTestHelper.GetSolutionRoot(), "TestResults", "test.txt"), body.ToText());
        }
    }
}
