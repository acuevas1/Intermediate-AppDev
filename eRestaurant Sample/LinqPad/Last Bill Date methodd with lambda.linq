<Query Kind="Program">
  <Connection>
    <ID>fc618045-c805-4cee-a07a-a91c7cce7297</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Bills.Max(x => x.BillDate); // lambda syntax C# Expression

void Main()
{
	//use lambda expression to get the maximum
	//  A lambda is simply a shorthand version of a function call
	// that is ideal for anonymous delegates
	Bills.Max(x => x.BillDate).Dump();
		// => such that
	
	
	//	 longer version using an actual method name
	// 	that we pass in to the Max() Methid
	//	Note that the Max() method is overloaded, therefore we need to specify
	// 	in the generic identifier of the method
	// 	which version we are using
	Bills.Max < Bills, DateTime > (GetProperty).Dump();

}

//define other methods and classes here

private DateTime GetProperty(Bills x)
{
	return x.BillDate;
}

