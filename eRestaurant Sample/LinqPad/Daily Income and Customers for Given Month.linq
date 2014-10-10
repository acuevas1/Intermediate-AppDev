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
					
	// temp: for "exploring" the results
	billsInMonth.Dump("Raw bill data for month/year");
 
 	billsInMonth.Sum(tb => tb.TotalAmount).Dump("Total income for month");
	billsInMonth.Sum(tb => tb.NumberOfCustomers).Dump("Customers for month");
	billsInMonth.Count().Dump("# of bills for month");
	
	var total= billsInMonth.Sum(tb=> tb.TotalAmount);
	var avg= total/ billsInMonth.Count();
	avg.ToString("C").Dump("Average amount per bill");
	
	
// 2) Build a report from the billsInMonth data
		
		var report= from item in billsInMonth
					group item by item.BillDate.Day into dailySummary
					select new
					{
						Day= dailySummary.Key,
						DailyCustomers = dailySummary.Sum (grp => grp.NumberOfCustomers),
						Income= dailySummary.Sum (grp => grp.TotalAmount),
						BillCount = dailySummary.Count(),
						AveragePerBill=	dailySummary.Sum(grp => grp.TotalAmount) / dailySummary.Count()
										
									
					};

					report.OrderBy (r => r.Day).Dump("Daily Income Report");

 