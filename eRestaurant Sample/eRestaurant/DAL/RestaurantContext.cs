using eRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity; // needed for DBContext
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.DAL
{
    public class RestaurantContext : DbContext // can make it internal
    {

        #region Constructor

        public RestaurantContext() : base("name=EatIn") { }

        #endregion

        #region Properties for the table-to-entity mappings
       
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Table> Tables { get; set; }
        //public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        
        #endregion


        #region Over-rideCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                //many to many
                .Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(t => t.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("ReservationID");
                    mapping.MapRightKey("TableID");

                });
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}