<Query Kind="Expression">
  <Connection>
    <ID>fc618045-c805-4cee-a07a-a91c7cce7297</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from cat in MenuCategories
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
}