<Query Kind="Statements">
  <Connection>
    <ID>250dc3fa-7ab1-4768-9ae8-cdb45c2d8830</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>


// Find out information on the tables in the restaurant at a specific date/time

// Create a date and time object to use for sample input data
var date = Bills.Max(b => b.BillDate).Date;
var time = Bills.Max(b => b.BillDate).TimeOfDay.Add(new TimeSpan(0, 30, 0));
date.Add(time).Dump("The test date/time I am using");

// Step 1 - Get the table info along with any walk-in bills and reservation bills for the specific time slot
var step1 = from data in Tables
             select new
             {
                Table = data.TableNumber,
                Seating = data.Capacity,
                // This sub-query gets the bills for walk-in customers
                Bills = from billing in data.Bills
                        where 
                               billing.BillDate.Year == date.Year
                            && billing.BillDate.Month == date.Month
                            && billing.BillDate.Day == date.Day
                            && billing.BillDate.TimeOfDay <= time
                            && (!billing.OrderPaid.HasValue || billing.OrderPaid.Value >= time)
//                          && (!billing.PaidStatus || billing.OrderPaid >= time)
                        select billing,
                 // This sub-query gets the bills for reservations
                 Reservations = from booking in data.ReservationTables
                        from billing in booking.Reservation.Bills
                        where 
                               billing.BillDate.Year == date.Year
                            && billing.BillDate.Month == date.Month
                            && billing.BillDate.Day == date.Day
                            && billing.BillDate.TimeOfDay <= time
                            && (!billing.OrderPaid.HasValue || billing.OrderPaid.Value >= time)
//                          && (!billing.PaidStatus || billing.OrderPaid >= time)
                        select billing
             };
step1.Dump();

