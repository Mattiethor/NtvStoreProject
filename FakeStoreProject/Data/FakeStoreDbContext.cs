using FakeStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeStoreProject.Data
{
    public class FakeStoreDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ItemOrder> ItemsOrders { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Store> Stores { get; set; }

        public string DbPath { get; }

        public FakeStoreDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "FakeStore.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FakeStoreDb");
        }

        //TODO fill out initial seed 
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //test store
            modelBuilder.Entity<Store>().HasData(new Store { Id = 1, Name = "FakeStore", Email = "Fakestore@fakestore.com", Phone = "444-5555", });

            
        }
        #endregion



    }
}
