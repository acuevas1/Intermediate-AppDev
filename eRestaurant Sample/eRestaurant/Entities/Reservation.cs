using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities
{
    public class Reservation

    {
        //add in constants for valid reservation values
        // A = arrived B= booked ; C=complete; N=No-show; X= Cancelled

        public const string Arrived = "A";
        public const string Booked = "B";
        public const string Complete = "C";
        public const string NoShow = "N";
        public const string Cancelled = "X";
      


        public int ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }
        public string EventCode { get; set; }

        #region Navigation Properties
        //build a rich object model for a table class

        public virtual ICollection<Table> Tables { get; set; }
        public virtual SpecialEvent SpecialEvent { get; set; }


        #endregion  


    }
}
