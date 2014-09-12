﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities
{
    public class SpecialEvent
    {
        [Key] //identifies this property as mapping to a primary key 
        public string EventCode { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        #region Navigation Properties
        //build a rich object model for a table class

        public virtual ICollection<Reservation> Reservations { get; set; }

        #endregion  
    }
}
