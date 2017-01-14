using System;
using System.Collections.Generic;
using System.Linq;
using TOTD.Mailer.Core.Elements;
using TOTD.Mailer.Templates;
using TOTD.Utility.StringHelpers;

namespace TOTD.Mailer.Core
{
    public class EmailBuilder
    {
        private EmailMessage _email;
        private BodyElement _body;
        private BaseContainerElement _container;
        private TableElement _table;
        private TableRowElement _tableRow;

        public static EmailBuilder Begin()
        {
            DefaultStyles defaultStyles = new DefaultStyles();
            return Begin(defaultStyles.TransformText());
        }

        public static EmailBuilder Begin(string styles)
        {
            return new EmailBuilder(styles);
        }

        private EmailBuilder(string styles)
        {
            this._body = new BodyElement(styles);
        }

        private EmailMessage Message
        {
            get
            {
                if (_email == null)
                {
                    _email = new EmailMessage();
                }
                return _email;
            }
        }

        public EmailBuilder AddElement(BaseElement element)
        {
            if (_container == null)
            {
                _body.AddElement(element);
            }
            else
            {
                _container.AddElement(element);
            }

            return this;
        }

        public EmailBuilder BeginParagraph()
        {
            _container = new ParagraphElement();
            _body.AddElement(_container);
            return this;
        }

        public EmailBuilder EndParagraph()
        {
            if (_container == null)
            {
                throw new InvalidOperationException("Paragraph ended without being started");
            }

            _container = null;

            return this;
        }

        public EmailBuilder BeginTable(string className = null)
        {
            _table = new TableElement();

            if (!className.IsNullOrEmpty())
            {
                _table.AddClass(className);
            }

            return AddElement(_table);
        }

        public EmailBuilder EndTable()
        {
            if (_table == null)
            {
                throw new InvalidOperationException("Table ended without being started");
            }

            _table = null;

            return this;
        }

        public EmailBuilder BeginTableRow()
        {
            if (_table == null)
            {
                throw new InvalidOperationException("Table row started without starting a table");
            }

            _tableRow = new TableRowElement();
            _table.AddRow(_tableRow);
            return this;
        }

        public EmailBuilder EndTableRow()
        {
            if (_tableRow == null)
            {
                throw new InvalidOperationException("Table row ended without being started");
            }

            _tableRow = null;

            return this;
        }

        public EmailBuilder AddTableCell(string text, string className = null)
        {
            if (_tableRow == null)
            {
                throw new InvalidOperationException("Table cell added without starting a row");
            }

            TableCellElement cell = new TableCellElement();
            cell.AddText(text);

            if (className != null)
            {
                cell.AddClass(className);
            }

            return AddElement(cell);
        }

        public EmailBuilder AddTableCell(string content)
        {
            if (_tableRow == null)
            {
                throw new InvalidOperationException("Table cell added without starting a row");
            }

            _tableRow.AddCell(content);

            return this;
        }

        public EmailBuilder BeginTableCell()
        {
            if (_tableRow == null)
            {
                throw new InvalidOperationException("Table cell added without starting a row");
            }

            TableCellElement cell = new TableCellElement();
            _container = cell;
            _tableRow.AddCell(cell);

            return this;
        }

        public EmailBuilder EndTableCell()
        {
            if (_container == null)
            {
                throw new InvalidOperationException("Table cell ended without being started");
            }

            _container = null;

            return this;
        }

        public EmailBuilder AddTableHeader(string content)
        {
            if (_tableRow == null)
            {
                throw new InvalidOperationException("Table header added without starting a row");
            }

            _tableRow.AddHeader(content);

            return this;
        }

        public EmailBuilder BeginTableHeader()
        {
            if (_tableRow == null)
            {
                throw new InvalidOperationException("Table cell added without starting a row");
            }

            TableHeaderElement cell = new TableHeaderElement();
            _container = cell;
            _tableRow.AddCell(cell);

            return this;
        }

        public EmailBuilder EndTableHeader()
        {
            if (_container == null)
            {
                throw new InvalidOperationException("Table header ended without being started");
            }

            _container = null;

            return this;
        }

        public EmailBuilder AddStyles(string styles)
        {
            _body.AddStyles(styles);
            return this;
        }

        public EmailBuilder AddText(string text)
        {
            TextElement element = new TextElement(text);
            return AddElement(element);
        }

        public EmailBuilder AddParagraph(string text)
        {
            ParagraphElement element = new ParagraphElement().AddText(text);
            return AddElement(element);
        }

        public EmailBuilder AddLineBreak()
        {
            LineBreakElement element = new LineBreakElement();
            return AddElement(element);
        }

        public EmailBuilder AddImage(string source, string alt)
        {
            ImageElement element = new ImageElement(source, alt);
            return AddElement(element);
        }

        public EmailBuilder AddLink(string link, string content)
        {
            LinkElement element = new LinkElement(link, content);
            return AddElement(element);
        }

        public EmailBuilder AddButton(string link, string content)
        {
            ButtonElement element = new ButtonElement(link, content);
            return AddElement(element);
        }

        public EmailBuilder WithSubject(string subject)
        {
            Message.Subject = subject;
            return this;
        }

        public EmailBuilder From(string fromEmail)
        {
            Message.From = fromEmail;
            return this;
        }

        public EmailBuilder To(string email)
        {
            return To(new[] { email });
        }

        public EmailBuilder To(params string[] emails)
        {
            Message.To = emails;
            return this;
        }

        public EmailBuilder To(IEnumerable<string> emails)
        {
            Message.To = emails;
            return this;
        }

        public EmailBuilder Bcc(string email)
        {
            Message.Bcc = new[] { email };
            return this;
        }

        public EmailBuilder Bcc(params string[] emails)
        {
            Message.Bcc = emails;
            return this;
        }

        public EmailBuilder Cc(string email)
        {
            Message.Cc = new[] { email };
            return this;
        }

        public EmailBuilder Cc(params string[] emails)
        {
            Message.Cc = emails;
            return this;
        }

        public string ToText()
        {
            return _body.ToText();
        }

        public string ToHtml()
        {
            return _body.ToHtml();
        }

        public EmailMessage ToEmail()
        {
            Message.HtmlBody = _body.ToHtml();
            Message.TextBody = _body.ToText();
            return Message;
        }
    }
}
