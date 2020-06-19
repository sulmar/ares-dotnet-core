namespace Ares.Domain.Models
{
    public interface IVisitor
	{
		void Visit(TextControl control);
		void Visit(CheckboxControl control);
		void Visit(ButtonControl control);

		void Visit(Section control);

		string Output { get; }
	}

}
