using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities
{
    public class Table
    {

        public Table() { Available = true; } //default


        // In EF, by convention, if there is a property with a same name as the class but with the suffix ID, then any framework will assume that this property is mapping to a primary key column on the database table.

        //You can still add the KEY but it is not necessary
        public int TableID { get; set; }
        //if table number is the primary key, put the [KEY] here.
        public byte TableNumber { get; set; }
        public bool Smoking { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }

        #region Navigation Properties
        //build a rich object model for a table class

        public virtual ICollection<Reservation> Reservations { get; set; }

        #endregion  
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
