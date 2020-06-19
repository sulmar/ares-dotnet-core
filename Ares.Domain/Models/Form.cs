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
