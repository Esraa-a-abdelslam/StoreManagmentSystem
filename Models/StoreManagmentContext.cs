using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace StoreManagmentSystem
{
    public partial class StoreManagmentContext : DbContext
    {
        public StoreManagmentContext()
            : base("name=StoreManagmentContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<Sales_Invoice> Sales_Invoice { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Store_Item> Store_Item { get; set; }
        public virtual DbSet<Store_Item_Quantity> Store_Item_Quantity { get; set; }
        public virtual DbSet<Supply_Invoice> Supply_Invoice { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Mobile)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Sales_Invoice)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_ID);

            modelBuilder.Entity<Item>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Item>()
                .HasMany(e => e.Store_Item)
                .WithOptional(e => e.Item)
                .HasForeignKey(e => e.Item_ID);

            modelBuilder.Entity<Measure>()
                .Property(e => e.Main_Measure)
                .IsFixedLength();

            modelBuilder.Entity<Measure>()
                .Property(e => e.Sub_Measure)
                .IsFixedLength();

            modelBuilder.Entity<Measure>()
                .HasMany(e => e.Items)
                .WithOptional(e => e.Measure)
                .HasForeignKey(e => e.Measure_Unit_ID);

            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.Responsible_Employee)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Store_Item)
                .WithOptional(e => e.Store)
                .HasForeignKey(e => e.Store_ID);

            modelBuilder.Entity<Store_Item>()
                .HasMany(e => e.Store_Item_Quantity)
                .WithOptional(e => e.Store_Item)
                .HasForeignKey(e => e.Store_Item_ID);

            modelBuilder.Entity<Store_Item_Quantity>()
                .Property(e => e.Measure_Name)
                .IsFixedLength();

            modelBuilder.Entity<Store_Item_Quantity>()
                .Property(e => e.Notes)
                .IsFixedLength();

            modelBuilder.Entity<Store_Item_Quantity>()
                .HasMany(e => e.Sales_Invoice)
                .WithOptional(e => e.Store_Item_Quantity)
                .HasForeignKey(e => e.Store_Item_Quantity_ID);

            modelBuilder.Entity<Store_Item_Quantity>()
                .HasMany(e => e.Supply_Invoice)
                .WithOptional(e => e.Store_Item_Quantity)
                .HasForeignKey(e => e.Store_Item_Quantity_ID);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Mobile)
                .IsFixedLength();

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.Supply_Invoice)
                .WithOptional(e => e.Vendor)
                .HasForeignKey(e => e.Vendor_ID);
        }
    }
}
