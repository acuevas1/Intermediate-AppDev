using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities.POCOs
{
    public class CategorizedItemsSale
    {
        public string ItemDescription { get; set; }

        public string CategoryDescription { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }

        public decimal Price { get; set; }
    }
}
