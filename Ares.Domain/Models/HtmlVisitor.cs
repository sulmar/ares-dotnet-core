using System.Text;

namespace Ares.Domain.Models
{
    public class HtmlVisitor : IVisitor
    {
        private readonly StringBuilder builder = new StringBuilder();

        public HtmlVisitor()
        {
            AppendStartElement();
        }

        private void AppendStartElement()
        {
            builder.AppendLine("<html>");
        }

        private void AppendEndElement()
        {
            builder.AppendLine("</html>");
        }


        public string Output
        {
            get
            {
                AppendEndElement();
                return builder.ToString();
            }
        }


        public void Visit(TextControl control)
        {
            builder.AppendLine($"<span>{control.Caption}</span><input type='text' value='{control.Value}'></input>");
        }

        public void Visit(CheckboxControl control)
        {
            builder.AppendLine($"<span>{control.Caption}</span><input type='checkbox' value='{control.Value}'></input>");
        }

        public void Visit(ButtonControl control)
        {
            builder.AppendLine( $"<button><img src='/images/image.png'/>{control.Caption}</button>");
        }

        public void Visit(Section control)
        {
            builder.AppendLine( $"<div>{control.Caption}</div>");
        }
    }

}
