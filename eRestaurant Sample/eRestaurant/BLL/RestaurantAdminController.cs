using eRestaurant.DAL;
using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    public class RestaurantAdminController
    {

        #region Manage Waiters
                #region Command
        public int AddWaiter(Waiter item) 
        {
            using (RestaurantContext context = new RestaurantContext())
            { 
                //to do: validation rules....

                var added = context.Waiters.Add(item);
                context.SaveChanges();
                return added.WaiterID; // gets the ID of the waiter added
            }
        }

        public void UpdateWaiter(Waiter item) // stuff coming in from the user . take that and attach it to 
            //our database context and get the entity that matches that entity accdng to the PK
            //then DBset will have info about the information we got from the user and the info from the db
            // update the stuff that has only been changed to the DB
            //2 roundtrip = get the existing one and one to save the changes

        {
            using (RestaurantContext context = new RestaurantContext())
            { 
                //to do: validation

                var attached = context.Waiters.Attach(item);
                var existing = context.Entry<Waiter>(attached);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteWaiter(Waiter item) {
            using (RestaurantContext context = new RestaurantContext()) {
                var existing = context.Waiters.Find(item.WaiterID);
                context.Waiters.Remove(existing);
                context.SaveChanges();
            }
        }

                #endregion


                #region Query
        public List<Waiter> ListAllWaiters() 
        {
            using (RestaurantContext context = new RestaurantContext()) 
            {
                return context.Waiters.ToList();
            }
        }

        public Waiter GetWaiter(int waiterID)
        {
            using (RestaurantContext context = new RestaurantContext())

                return context.Waiters.Find(waiterID);
        }
                #endregion
        #endregion

        #region Manage Tables
                #region Command


                #endregion


                #region Query


                #endregion
        #endregion

        #region Manage Items
                #region Command


                #endregion


                #region Query


                #endregion
        #endregion

        #region Manage Special Events
                #region Command


                #endregion


                #region Query


                #endregion
        #endregion
    }
}
