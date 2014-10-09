<Query Kind="Statements">
  <Connection>
    <ID>fc618045-c805-4cee-a07a-a91c7cce7297</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var data = from cat in MenuCategories
			
			orderby cat.Description
			select new
			{
				Description = cat.Description,
				MenuItems=from food in cat.Items
							where food.Active
							select new 
							{
								Description=food.Description,
								Price=food.CurrentPrice
							}
			};
			
data.Dump("Menu Items by Category");

// .Dump() is only available to LINQ Pad