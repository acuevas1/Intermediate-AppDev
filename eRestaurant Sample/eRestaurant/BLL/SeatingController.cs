using eRestaurant.DAL;
using eRestaurant.Entities;
using eRestaurant.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    [DataObject]
    public class SeatingController
        // tells us info about front desk needs (Reservations for the day and the occupancy)
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ReservationCollection> ReservationsByTime(DateTime date)
        //public List<dynamic> ReservationsByTime(DateTime date)
        {

            using (var context = new RestaurantContext()) // MUST PUT INSIDE A VAR CONTEXT AFTER GRABBING CODE FROM LINQ PAD
            {

                var result = from data in context.Reservations //ADD 'context.' HERE
                             where data.ReservationDate.Year == date.Year
                                && data.ReservationDate.Month == date.Month
                                && data.ReservationDate.Day == date.Day
                                && data.ReservationStatus == Reservation.Booked
                             select new ReservationSummary()
                             {
                                 Name = data.CustomerName,
                                 Date = data.ReservationDate,
                                 NumberInParty = data.NumberInParty,
                                 Status = data.ReservationStatus,
                                 Event = data.SpecialEvent.Description,
                                 Contact = data.ContactPhone
                                 
                                 // DONT NEED THIS PART
                                 //,
                                 //Tables = from seat in data.ReservationTable
                                 //         select seat.Table.TableNumber
                             };
                var finalResult = from item in result
                                  group item by item.Date.Hour into itemGroup
                                  select new ReservationCollection() 
                                  { 
                                    Hour= itemGroup.Key,
                                    
                                    Reservations=itemGroup.ToList()
                                  }; 



                return finalResult.ToList();
                //return finalResult.ToList<dynamic>();
            }
        }
    }
}
