using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOTD.Utility.EnumerableHelpers;

namespace TOTD.Mailer.Core.Elements
{
    public class BaseTableCellElement : BaseContainerElement
    {
        private List<BaseElement> _children;
        private List<string> _classes;
        private string _tag;

        protected  BaseTableCellElement(string tag)
        {
            this._children = new List<BaseElement>();
            this._classes = new List<string>();
            this._tag = tag;
        }

        private string GetClasses()
        {
            return String.Join(" ", _classes);
        }

        public void AddText(string text)
        {
            _children.Add(new TextElement(text));
        }

        public void AddClass(string className)
        {
            _classes.Add(className);
        }

        public override void AddElement(BaseElement element)
        {
            _children.Add(element);
        }

        public override string ToHtml()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("    ");
            builder.Append($@"<{_tag} class=""{GetClasses()}"">");

            _children.NullSafeForEach(x => builder.Append(x.ToHtml()));

            builder.Append($"</{_tag}>");
            builder.AppendLine();

            return builder.ToString();
        }

        public override string ToText()
        {
            StringBuilder builder = new StringBuilder();

            _children.NullSafeForEach(x => builder.Append(x.ToText()));

            return builder.ToString();
        }
    }
}
