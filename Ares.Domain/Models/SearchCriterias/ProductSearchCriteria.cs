using System;
using System.Collections.Generic;
using System.Text;

namespace Ares.Domain.Models.SearchCriterias
{
    public class ProductSearchCriteria
    {
        public string Color { get; set; }
        public decimal? FromUnitPrice { get; set; }
        public decimal? ToUnitPrice { get; set; }
    }
}
