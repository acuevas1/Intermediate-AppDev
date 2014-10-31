<Query Kind="Statements">
  <Connection>
    <ID>214367ab-b89e-423f-9d66-eaa1fd130952</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

 // TO DO:
 // Income per Waiter for a given month and year
 
 // get data in a month 
 var billsInMonth= from info in Bills
					where info.BillDate.Month == 9 // month
					&& info.BillDate.Year == 2014//year
					select new
					{
						BillDate = info.BillDate,
						Waiter= info.Waiter.FirstName + " " + info.Waiter.LastName,
						Amount= info.BillItems.Sum( bi => bi.Quantity * bi.SalePrice)
					};
					
					billsInMonth.Dump("Raw bill data for month/year");
					
					//billsInMonth(w => w.Waiter).Dump("Waiters?");
	// income per waiter per month
