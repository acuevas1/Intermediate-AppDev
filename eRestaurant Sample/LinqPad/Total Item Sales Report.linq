<Query Kind="Statements">
  <Connection>
    <ID>fc618045-c805-4cee-a07a-a91c7cce7297</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var result = from info in BillItems 
			 orderby info.Item.MenuCategory.Description,info.Item.Description //Ordering
			 select new
			 {
			 	CategoryDescription = info.Item.MenuCategory.Description,
				ItemDescription = info.Item.Description,
				Quantity= info.Quantity,
				Price = info.SalePrice * info.Quantity,
				Cost= info.UnitCost * info.Quantity
			 };
			 
result.Count().Dump();
result.Dump();

// we are getting raw information we wanna want to get the actual price that we really sold
// we need to think what the information means