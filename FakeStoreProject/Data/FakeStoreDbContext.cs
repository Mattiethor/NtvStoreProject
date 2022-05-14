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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            //test address
            modelBuilder.Entity<Address>().HasData(new Address { Id = 1, City = "Reykjavik", PostCode = 101, Street = "Store Street" });

            //test store
            modelBuilder.Entity<Store>().HasData(new Store { Id = 1,  Name = "FakeStore", Email = "Fakestore@fakestore.com", Phone = "444-5555", AddressId = 1});

            //test Category
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Test" });

            //test product
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, StockId = 1, Name = "Test Product 1", CategoryId = 1, Description = "Test desctiption", ImgUrl = "Test image", ListPrice = 100, ModelYear = 2000 });

            //Test stock
            modelBuilder.Entity<Stock>().HasData(new Stock { Id = 1, ProductsId = 1, Quantity = 10, StoreId = 1 });
            //Test costumer
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, AddressId = 1, FirstName = "John", LastName = "Doe" });

            //Test Staff
            modelBuilder.Entity<Staff>().HasData(new Staff { Id = 1, FirstName = "Bob", LastName = "Staffmann", StoreId = 1 });

            //Test order 
            modelBuilder.Entity<Order>().HasData(new Order { Id = 1,  StoreId = 1, ItemOrderId = 1, CustomerId = 1});
            //Test ItemOrder 

            modelBuilder.Entity<ItemOrder>().HasData(new ItemOrder { Id = 1, ProductId = 1, Quantity = 5, OrderId = 1 });


            

        }
       



    }
}
