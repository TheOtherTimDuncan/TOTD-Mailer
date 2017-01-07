﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class ParagraphElement : BaseElement
    {
        private List<BaseContentElement> Children;

        public ParagraphElement()
        {
            this.Children = new List<BaseContentElement>();
        }

        public ParagraphElement AddText(string text)
        {
            Children.Add(new TextElement(text));
            return this;
        }

        public ParagraphElement AddElement(BaseContentElement element)
        {
            Children.Add(element);
            return this;
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(@"<p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;"">");

            Children.NullSafeForEach(x => builder.Append(x.ToHtml()));

            builder.Append("</p>");

            return builder.ToString();
        }

        public override string ToText()
        {
            StringBuilder builder = new StringBuilder();

            Children.NullSafeForEach(x => builder.Append(x.ToText()));

            builder.AppendLine();

            return builder.ToString();
        }
    }
}
