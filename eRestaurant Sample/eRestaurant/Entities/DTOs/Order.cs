using eRestaurant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities.DTOs
{
    public class Order
    {
        public int TableNumber { get; set; }
        public string Waiter { get; set; }
        public int WaiterID { get; set; }
        public int? BillID { get; set; }
        public bool Served { get; set; }
        public string OrderComments { get; set; }
        //you do: Create a prop called TotalAmount which will sum up the item totals in the Items collection
        //remember to check if Items is null. Use a LINQ method .Sum() with a lambda to get the total

        public decimal TotalAmount 
        {
            get
            {
                decimal value = 0; //default
                if (Items != null)
                    value = Items.Sum(x => x.ItemTotal);
                return value;
            }
        }

        public IList<OrderItem> Items { get; set; }
    }
}
