using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Mailer.Html;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class BodyElement : BaseElement
    {
        private List<BaseElement> _children;
        private EmailBuilder _builder;

        public BodyElement(EmailBuilder builder)
        {
            this._children = new List<BaseElement>();
            this._builder = builder;
        }

        public BodyElement AddButton(string link, string content)
        {
            ButtonElement element = new ButtonElement()
            {
                Link = link,
                Content = content
            };

            _children.Add(element);

            return this;
        }

        public BodyElement AddLink(string link, string content)
        {
            LinkElement element = new LinkElement()
            {
                Link = link,
                Content = content
            };

            _children.Add(element);

            return this;
        }

        public BodyElement AddImage(string source, string alt)
        {
            ImageElement element = new ImageElement()
            {
                Source = source,
                Alt = alt
            };

            _children.Add(element);

            return this;
        }

        public BodyElement AddText(string text)
        {
            TextElement element = new TextElement(text);
            _children.Add(element);
            return this;
        }

        public BodyElement AddLineBreak()
        {
            LineBreakElement element = new LineBreakElement();
            _children.Add(element);
            return this;
        }

        public BodyElement AddParagraph(string text)
        {
            ParagraphElement element = new ParagraphElement(this).AddText(text);
            _children.Add(element);
            return this;
        }

        public ParagraphElement BeginParagraph()
        {
            ParagraphElement element = new ParagraphElement(this);
            _children.Add(element);
            return element;
        }

        public TableElement BeginTable()
        {
            TableElement element = new TableElement(this);
            _children.Add(element);
            return element;
        }

        public EmailBuilder EndBody()
        {
            return _builder;
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();
            _children.NullSafeForEach(x => builder.Append(x.ToHtml()));

            Body body = new Body(builder.ToString());
            return body.TransformText();
        }

        public override string ToText()
        {
            StringBuilder builder = new StringBuilder();
            _children.NullSafeForEach(x => builder.Append(x.ToText()));
            return builder.ToString();
        }
    }
}
