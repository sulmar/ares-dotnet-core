using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ares.Domain.Models
{
    public class Form
	{
        public string Name { get; set; }
        public string Title { get; set; }
		public Section Body { get; set; }

		public Form()
		{
			
		}

		public void Accept(IVisitor visitor)
        {
			Body.Accept(visitor);
        }
	}

	public class Section : Control
	{
		ICollection<Section> sections = new Collection<Section>();

		public ICollection<Control> Controls { get; set; }


        public override void Accept(IVisitor visitor)
        {
			visitor.Visit(this);

            foreach (var control in Controls)
            {
                control.Accept(visitor);
            }


           
        }
	}

	public abstract class Control
	{
		public string Name { get; set; }
		public string Caption { get; set; }
		public Location Location { get; set; }

		public abstract void Accept(IVisitor visitor);

	}

	public abstract class Control<T> : Control
	{
		public T Value { get; set; }

	}

	public interface IVisitor
	{
		void Visit(TextControl control);
		void Visit(CheckboxControl control);
		void Visit(ButtonControl control);

		void Visit(Section control);

		string Output { get; }
	}

	public class HtmlVisitor : IVisitor
	{
		private string output;

		public string Output
		{
			get
			{
				return output;
			}
		}

		public void Visit(TextControl control)
		{
			this.output += $"<span>{control.Caption}</span><input type='text' value='{control.Value}'></input>";
		}

		public void Visit(CheckboxControl control)
		{
			this.output += $"<span>{control.Caption}</span><input type='checkbox' value='{control.Value}'></input>";
		}

		public void Visit(ButtonControl control)
		{
			this.output += $"<button><img src='/images/image.png'/>{control.Caption}</button>";
		}

        public void Visit(Section control)
        {
			this.output += $"<div>{control.Caption}</div>";
		}
    }


    public class TextControl : Control<string>
    {
        public override void Accept(IVisitor visitor)
        {
			visitor.Visit(this);
        }
    }


    public class CheckboxControl : Control<bool>
	{
		public override void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
	}

	public class ButtonControl : Control
	{
		public override void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
	}

	public struct Location
	{
		public int Column { get; set; }
		public int ColSpan { get; set; }
		public int Row { get; set; }
	}

}
