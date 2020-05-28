<Query Kind="Program">
  <NuGetReference>Bogus</NuGetReference>
  <Namespace>Bogus</Namespace>
</Query>

void Main()
{
	ProductFaker faker = new ProductFaker();
	IList<Product> products =  faker.Generate(10);

	// products.Dump();

	var query = products
		.GroupBy(p => new { p.IsDiscount, p.Color })
		.Select(g => new { Grupa = g.Key, Products = g, Quantity = g.Count()})
		.ToList();
		
	//products.Select(p => p.Color).Dump();
	
	var query2 = query.SelectMany(q => q.Products.Select(p=>p.Color)).Dump(); 
		
	//foreach (var grupa in query)
	//{
	//	foreach (var color in grupa.Products.Select(p=>p.Color))
	//	{
	//		color.Dump();
	//	};
	//}
		
		
	
	// query.Dump();
}

// Define other methods, classes and namespaces here
public class Product 
{
	public string Name { get; set; }
	public string Color { get; set; }
	public decimal UnitPrice { get; set; }
	public bool IsDiscount { get; set; }
}


public class ProductFaker : Faker<Product>
{
	public ProductFaker()
	{
		
		RuleFor(p => p.Name, f => f.Commerce.ProductName());
		RuleFor(p => p.Color, f => f.Commerce.Color());
		RuleFor(p=>p.UnitPrice, f=> Math.Round(f.Random.Decimal(0, 100), 0));
		RuleFor(p => p.IsDiscount, f=>f.Random.Bool());
	}
}