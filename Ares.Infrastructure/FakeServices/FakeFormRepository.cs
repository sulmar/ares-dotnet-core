using Ares.Domain.Models;
using Ares.Domain.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ares.Infrastructure.FakeServices
{
    public class FakeFormRepository : IFormRepository
    {
        private readonly ICollection<Form> forms = new Collection<Form>();

        public FakeFormRepository()
        {
            Form form1 = new Form
            {
                Name = "/forms/customers",
                Title = "First ASP.Net Core dynamic object.",

                Body = new Section
                {

                    Controls = new Collection<Control>
                    {
                        new TextControl { Caption = "Caption TXT", Name = "txtName", Value = "txt value"},
                        new CheckboxControl { Caption = "Caption CHK", Name = "chkName", Value = true },
                        new ButtonControl { Caption = "Caption BTN", Name = "btnName" },
                    }
                }
            };

            forms.Add(form1);

        }

        public Form Get(string name)
        {
            return forms.SingleOrDefault(f=>f.Name == name);
        }
    
}

   
}
