<Query Kind="Statements">
  <Connection>
    <ID>214367ab-b89e-423f-9d66-eaa1fd130952</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

/* these statements are to build a report of income and # of customers per day in a given month/year
*
*/

// Get the follorinwg from the Bills table for a given month/year:
// Billdate, ID, # of people served, total amount billed

// 0) Set up info that would be passed into my BLL
var month = DateTime.Today.Month - 1;
var year= DateTime.Today.Year;
		
		

// 1) Get the Bill data for the month/year with a sum of each bill's item
var billsInMonth= from info in Bills
					where info.BillDate.Month == 9 // month
					&& info.BillDate.Year == 2014//year
					select new
					{
						BillDate = info.BillDate,
						BillID =info.BillID,
						NumberOfCustomers= info.NumberInParty,
						TotalAmount= 
							info.BillItems.Sum( bi => bi.Quantity * bi.SalePrice)
					};
	billsInMonth.Dump("Raw bill data for month/year");

// 2) Build a report from the billsInMonth data