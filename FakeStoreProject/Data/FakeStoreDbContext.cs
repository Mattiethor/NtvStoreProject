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

        public DbSet<Order>? Orders { get; set; }

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
            modelBuilder.Entity<Address>().HasData(
                     new Address { Id = 1, City = "Reykjavik", PostCode = "101", Street = "Store Street" },
                     new Address { Id = 2, City = "New York", PostCode = "NY505", Street = "Customer Street" },
                     new Address { Id = 3, City = "Copehagen", PostCode = "CP808", Street = "Danish Streen" });
            
            //test store
            modelBuilder.Entity<Store>().HasData(new Store { Id = 1, Name = "FakeStore", Email = "Fakestore@fakestore.com", Phone = "444-5555", AddressId =  1 });

            //test Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Summer" }, 
                new Category { Id = 2, Name = "Bedroom" },
                new Category { Id = 3, Name = "Living Room" }
            
            );

            //test product
            modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1, StockId = 1, Name = "Summer Chair", CategoryId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sit amet nisi lacus. Aenean eget felis tempor, blandit velit vel, dictum est. Vestibulum sed diam vulputate, commodo ligula aliquet, dictum mauris. Nullam imperdiet elementum nisi, a venenatis nulla tempus quis. Sed tempor gravida felis. Cras porttitor eleifend auctor. ", ImgUrl = "https://media.istockphoto.com/photos/deck-chair-picture-id918244930", ListPrice = 100, ModelYear = 2000 },
                new Product { Id = 2, StockId = 2, Name = "Outdoor set", CategoryId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat.", ImgUrl = "https://media.istockphoto.com/photos/patio-table-set-picture-id903469302", ListPrice = 500, ModelYear = 2004 },
                new Product { Id = 3, StockId = 3, Name = "Table Set", CategoryId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim.", ImgUrl = "https://media.istockphoto.com/photos/table-and-chairs-picture-id645618262", ListPrice = 670, ModelYear = 1990 },
                new Product { Id = 4, StockId = 4, Name = "Summer Parasol", CategoryId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim.", ImgUrl = "https://media.istockphoto.com/photos/parasol-picture-id187264061", ListPrice = 400, ModelYear = 1980 },
                new Product { Id = 5, StockId = 5, Name = "Lounge Chair", CategoryId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim", ImgUrl = "https://media.istockphoto.com/photos/gardening-lounge-chair-picture-id182403766", ListPrice = 100, ModelYear = 2000 },
                new Product { Id = 6, StockId = 6, Name = "Plant Pot", CategoryId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim, ", ImgUrl = "https://media.istockphoto.com/photos/ornamental-plant-with-pink-petunia-flowers-on-a-large-traditional-picture-id1154401941", ListPrice = 250, ModelYear = 2006 },
                new Product { Id = 7, StockId = 7, Name = "Blue Drawer", CategoryId = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim, ", ImgUrl = "https://media.istockphoto.com/photos/blue-wooden-dresser-isolated-on-white-background-picture-id1162304784", ListPrice = 500, ModelYear = 2018 },
                new Product { Id = 8, StockId = 8, Name = "Oak Bed", CategoryId = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim, ", ImgUrl = "https://media.istockphoto.com/photos/bed-isolated-on-white-3-picture-id173698682", ListPrice = 800, ModelYear = 2010 },
                new Product { Id = 9, StockId = 9, Name = "Brown Drawer", CategoryId = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim, ", ImgUrl = "https://media.istockphoto.com/photos/brown-vintage-wooden-drawer-isolated-on-white-background-with-path-picture-id947145084", ListPrice = 250, ModelYear = 2000 },
                new Product { Id = 10, StockId = 10, Name = "White Sofa", CategoryId = 2, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", ImgUrl = "https://media.istockphoto.com/photos/sofa-picture-id173240457", ListPrice = 699, ModelYear = 2002 },
                new Product { Id = 11, StockId = 11, Name = "Gray Sofa", CategoryId = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", ImgUrl = "https://media.istockphoto.com/photos/white-sofa-with-pillows-picture-id519463114", ListPrice = 799, ModelYear = 1988 },
                new Product { Id = 12, StockId = 12, Name = "Classic Chair", CategoryId = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", ImgUrl = "https://media.istockphoto.com/photos/old-retro-sixties-style-chair-in-blue-picture-id933712184", ListPrice = 399, ModelYear = 2000 },
                new Product { Id = 13, StockId = 13, Name = "Side Table", CategoryId = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", ImgUrl = "https://media.istockphoto.com/photos/side-table-picture-id179599149", ListPrice = 200, ModelYear = 2022 },
                new Product { Id = 14, StockId = 14, Name = "Gray Chair", CategoryId = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", ImgUrl = "https://media.istockphoto.com/photos/dark-gray-living-rolled-top-club-chair-picture-id939688452", ListPrice = 350, ModelYear = 1989 },
                new Product { Id = 15, StockId = 15, Name = "Small Sofa", CategoryId = 3, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent posuere elementum sapien ac suscipit. Integer hendrerit erat sed lorem varius, quis consectetur enim feugiat. Etiam imperdiet nulla et justo laoreet, nec iaculis purus fringilla. Etiam eget erat vitae ipsum sodales commodo. Praesent at erat maximus, aliquam enim ac, tempor ligula. Pellentesque leo enim,", ImgUrl = "https://media.istockphoto.com/photos/sofa-picture-id642715652", ListPrice = 599, ModelYear = 2015 }


                );

            //Test stock
            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, ProductsId = 1, Quantity = 10, StoreId = 1 },
                new Stock { Id = 2, ProductsId = 2, Quantity = 13, StoreId = 1 },
                new Stock { Id = 3, ProductsId = 3, Quantity = 0, StoreId = 1 },
                new Stock { Id = 4, ProductsId = 4, Quantity = 50, StoreId = 1 },
                new Stock { Id = 5, ProductsId = 5, Quantity = 22, StoreId = 1 },
                new Stock { Id = 6, ProductsId = 6, Quantity = 4, StoreId = 1 },
                new Stock { Id = 7, ProductsId = 7, Quantity = 3, StoreId = 1 },
                new Stock { Id = 8, ProductsId = 8, Quantity = 10, StoreId = 1 },
                new Stock { Id = 9, ProductsId = 9, Quantity = 15, StoreId = 1 },
                new Stock { Id = 10, ProductsId = 11, Quantity = 25, StoreId = 1 },
                new Stock { Id = 11, ProductsId = 12, Quantity = 60, StoreId = 1 },
                new Stock { Id = 12, ProductsId = 13, Quantity = 1, StoreId = 1 },
                new Stock { Id = 13, ProductsId = 14, Quantity = 7, StoreId = 1 },
                new Stock { Id = 14, ProductsId = 15, Quantity = 9, StoreId = 1 },
                new Stock { Id = 15, ProductsId = 16, Quantity = 18, StoreId = 1 }



            );
            //Test costumer
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, FirstName = "Bob", LastName = "Customer", AddressId = 2});

            //Test Staff
            modelBuilder.Entity<Staff>().HasData(new Staff { Id = 1, FirstName = "Bob", LastName = "Staffmann", StoreId = 1 });

            //Test order 
            modelBuilder.Entity<Order>().HasData(new Order { Id = 1, StoreId = 1, ItemOrderId = 1, CustomerId = 1 });
            //Test ItemOrder 

            modelBuilder.Entity<ItemOrder>().HasData(new ItemOrder { Id = 1, ProductId = 1, Quantity = 5, OrderId = 1 });




        }




    }
}
