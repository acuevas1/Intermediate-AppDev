﻿using eRestaurant.DAL;
using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel; // for supporting DataBound Controls in webforms
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    [DataObject]
    public class RestaurantAdminController
    {
        #region Manage Waiters
        #region Command
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int AddWaiter(Waiter item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                // TODO: Validation rules...
                var added = context.Waiters.Add(item);
                context.SaveChanges();
                return added.WaiterID;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateWaiter(Waiter item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                // TODO: Validation...
                var attached = context.Waiters.Attach(item);
                var existing = context.Entry<Waiter>(attached);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteWaiter(Waiter item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var existing = context.Waiters.Find(item.WaiterID);
                context.Waiters.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Query
        [DataObjectMethod(DataObjectMethodType.Select, false)]

        public List<Waiter> ListAllWaiters()
        {
            using (RestaurantContext context = new RestaurantContext()) // using frees context it was used
            {
                return context.Waiters.ToList();    
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Waiter GetWaiter(int waiterId)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.Waiters.Find(waiterId);
            }
        }
        #endregion
        #endregion

        #region Manage Tables
        #region Command Tables
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int AddTable(Table item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                // TODO: Validation rules...
                var added = context.Tables.Add(item);
                context.SaveChanges();
                return added.TableID;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateTable(Table item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                // TODO: Validation...
                var attached = context.Tables.Attach(item);
                var existing = context.Entry<Table>(attached);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteTable(Table item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var existing = context.Tables.Find(item.TableID);
                context.Tables.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Query Tables
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Table> ListAllTables()
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.Tables.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Table GetTable(int TableId)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.Tables.Find(TableId);
            }
        }
        #endregion
        #endregion

        #region Manage Items
        #region Command Items
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int AddItem(Item item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                // TODO: Validation rules...
                var added = context.Items.Add(item);
                context.SaveChanges();
                return added.ItemID;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateItem(Item item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                // TODO: Validation...
                var attached = context.Items.Attach(item);
                var existing = context.Entry<Item>(attached);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteItem(Item item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var existing = context.Items.Find(item.ItemID);
                context.Items.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Query Items
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Item> ListAllItems()
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.Items.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Item GetItem(int ItemId)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.Items.Find(ItemId);
            }
        }
        #endregion
        #endregion

        #region Manage Special Events
        #region Command
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void AddSpecialEvent(SpecialEvent item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                // TODO: Validation rules...
                var added = context.SpecialEvents.Add(item);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void UpdateSpecialEvent(SpecialEvent item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                // TODO: Validation...
                var attached = context.SpecialEvents.Attach(item);
                var existing = context.Entry<SpecialEvent>(attached);
                existing.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void DeleteSpecialEvent(SpecialEvent item)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var existing = context.SpecialEvents.Find(item.EventCode);
                context.SpecialEvents.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Query Special Events
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> ListAllSpecialEvents()
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.SpecialEvents.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SpecialEvent GetSpecialEvent(int SpecialEventId)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                return context.SpecialEvents.Find(SpecialEventId);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> ReservationsBySpecialEvent(string specialEventId)
        {
            using (var context = new RestaurantContext())
            {
                var data = from item in context.Reservations
                           where item.EventCode == specialEventId
                           select item;
                return data.ToList();
            }
        }
        #endregion
        #endregion


    }
}