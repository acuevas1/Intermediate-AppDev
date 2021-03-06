<Query Kind="Statements">
  <Connection>
    <ID>250dc3fa-7ab1-4768-9ae8-cdb45c2d8830</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>



// This query is for pulling out data to be used in a
// Details report. The query gets all the menu items
// and their categories, sorting them by the category
// description and then by the menu item description.
from cat in Items
orderby cat.MenuCategory.Description, cat.Description
select new
{
    CategoryDescription = cat.MenuCategory.Description,
    ItemDescription = cat.Description,
    Price = cat.CurrentPrice,
    Calories = cat.Calories,
    Comment = cat.Comment
}