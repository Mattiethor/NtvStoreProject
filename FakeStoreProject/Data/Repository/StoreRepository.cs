using FakeStoreProject.Models;
using FakeStoreProject.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace FakeStoreProject.Data.Interfaces
{
    public class StoreRepository : IRepository
    {
        private FakeStoreDbContext _dbContext;



        public StoreRepository()
        {
            _dbContext = new FakeStoreDbContext();
        }

        //Including a list of all products under this Category.
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            List<Category> categories;
            using (var db = _dbContext)
            {
                categories = await db.Categories.Include(p => p.Products).ToListAsync();
            }

            return categories;

        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            Category category;
            using var db = _dbContext;
            {
                category = await db.Categories.Include(p => p.Products).FirstOrDefaultAsync(c => c.Id == id);
            }
            Category categoryToReturn = category;
            List<ProductDTO> p = new List<ProductDTO>();

            //only runs if category.id exists when making a get request.
            if (categoryToReturn != null)
            {
                foreach (Product product in category.Products)
                {
                    ProductDTO prodToReturn = new ProductDTO();
                    prodToReturn.Id = product.Id;
                    prodToReturn.Name = product.Name;
                    prodToReturn.ListPrice = product.ListPrice;
                    prodToReturn.ImgUrl = product.ImgUrl;
                    prodToReturn.Description = product.Description;
                    prodToReturn.CategoryName = category.Name;
                    prodToReturn.StockId = product.StockId;
                    prodToReturn.ModelYear = product.ModelYear;
                    p.Add(prodToReturn);
                }

            }

            return categoryToReturn;

        }

        //Get all products
        public async Task<List<Product>> GetAllProductsAsync()
        {
            List<Product> products;
            using (var db = _dbContext)
            {
                products = await db.Products.ToListAsync();
            }
            return products;
        }
        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            Product product;
            Category category;
            using var db = _dbContext;
            {
                product = await db.Products.FirstOrDefaultAsync(c => c.Id == id);

                category = await db.Categories.FirstOrDefaultAsync(c => c.Id == product.CategoryId);
            }

            ProductDTO prodToReturn = new ProductDTO();


            if (product != null)
            {
                prodToReturn.Id = product.Id;
                prodToReturn.Name = product.Name;
                prodToReturn.ListPrice = product.ListPrice;
                prodToReturn.ImgUrl = product.ImgUrl;
                prodToReturn.Description = product.Description;
                prodToReturn.CategoryName = category.Name;
                prodToReturn.StockId = product.StockId;
                prodToReturn.ModelYear = product.ModelYear;

                return prodToReturn;
            }
            return null;

        }
        public async Task<List<Stock>> GetAllStocksAsync()
        {
            List<Stock> stocks;

            using var db = _dbContext;
            {
                stocks = await db.Stocks.ToListAsync();
            }
            return stocks;
        }
        public async Task<Stock> GetStockByIdAsync(int id)
        {
            Stock stockToReturn;

            using var db = _dbContext;
            {
                stockToReturn = await db.Stocks.FirstOrDefaultAsync(c => c.Id == id);
            }
            return stockToReturn;
        }

        public async Task<Store> GetStoreByIdAsync(int id)
        {

            Store storeToReturn;

            using var db = _dbContext;
            {
                storeToReturn = await db.Stores.FirstOrDefaultAsync(c => c.Id == id);
            }

            return storeToReturn;
        }

        public async Task<List<Store>> GetAllStoresAsync()
        {
            List<Store> store;
            using (var db = _dbContext)
            {
                store = await db.Stores.ToListAsync();
            }
            return store;
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            List<Address> addresses;
            using (var db = _dbContext)
            {
                addresses = await db.Addresses.ToListAsync();
            }
            return addresses;
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            Address addressToReturn;

            using var db = _dbContext;
            {
                addressToReturn = await db.Addresses.FirstOrDefaultAsync(c => c.Id == id);
            }
            return addressToReturn;
        }


        public async Task<List<Staff>> GetAllStaffAsync()
        {
            List<Staff> staff;
            using (var db = _dbContext)
            {
                staff = await db.Staffs.ToListAsync();
            }
            return staff;
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            Staff staffToReturn;

            using var db = _dbContext;
            {
                staffToReturn = await db.Staffs.FirstOrDefaultAsync(c => c.Id == id);
            }

            return staffToReturn;
        }

        //CREATE SECTION
        public async Task CreateCategoryAsync(Category category)
        {
            using (var db = _dbContext)
            {
                await db.Categories.AddAsync(category);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateProductAsync(Product product)
        {
            using (var db = _dbContext)
            {
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateStockAsync(Stock stock)
        {
            using (var db = _dbContext)
            {
                await db.Stocks.AddAsync(stock);
                await db.SaveChangesAsync();
            }

        }

        public async Task CreateStoreAsync(Store store)
        {
            using (var db = _dbContext)
            {
                await db.Stores.AddAsync(store);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateAddressAsync(Address address)
        {
            using (var db = _dbContext)
            {
                await db.Addresses.AddAsync(address);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateStaffAsync(Staff staff)
        {
            using (var db = _dbContext)
            {
                await db.Staffs.AddAsync(staff);
                await db.SaveChangesAsync();
            }
        }

        //DELETE SECTION

        //Uses the Product Id to find and remove the product
        public async Task<bool> DeleteProductAsync(int id)
        {
            Product ProductToDelete;
            using (var db = _dbContext)
            {
                ProductToDelete = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (ProductToDelete == null)
                {
                    //False means the item was not deleted.
                    return false;
                }
                else
                {
                    db.Products.Remove(ProductToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }

            }

        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            Category CategoryToDelete;
            using (var db = _dbContext)
            {
                CategoryToDelete = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (CategoryToDelete == null)
                {
                    //False means the item was not deleted.
                    return false;
                }
                else
                {
                    db.Categories.Remove(CategoryToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }

            }
        }
        public async Task<bool> DeleteStockAsync(int id)
        {
            Stock StockToDelete;
            using (var db = _dbContext)
            {
                StockToDelete = await db.Stocks.FirstOrDefaultAsync(x => x.Id == id);
                if (StockToDelete == null)
                {
                    //False means the item was not deleted.
                    return false;
                }
                else
                {
                    db.Stocks.Remove(StockToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }

            }

        }

        public async Task<bool> DeleteStoreAsync(int id)
        {
            Store StoreToDelete;
            using (var db = _dbContext)
            {
                StoreToDelete = await db.Stores.FirstOrDefaultAsync(x => x.Id == id);
                if (StoreToDelete == null)
                {
                    //False means the item was not deleted.
                    return false;
                }
                else
                {
                    db.Stores.Remove(StoreToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            Address addressToDelete;
            using (var db = _dbContext)
            {
                addressToDelete = await db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                if (addressToDelete == null)
                {
                    //False means the item was not deleted.
                    return false;
                }
                else
                {
                    db.Addresses.Remove(addressToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }
        public async Task<bool> DeleteStaffAsync(int id)
        {
            Staff staffToDelete;
            using (var db = _dbContext)
            {
                staffToDelete = await db.Staffs.FirstOrDefaultAsync(x => x.Id == id);
                if (staffToDelete == null)
                {
                    //False means the item was not deleted.
                    return false;
                }
                else
                {
                    db.Staffs.Remove(staffToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }


        //UPDATE SECTION
        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            Product productToUpdate;
            using var db = _dbContext;
            {
                productToUpdate = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (productToUpdate == null)
                {
                    return null;
                }

                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.StockId = product.StockId;
                productToUpdate.ListPrice = product.ListPrice;
                productToUpdate.ModelYear = product.ModelYear;
                productToUpdate.Description = product.Description;
                productToUpdate.ImgUrl = product.ImgUrl;
                productToUpdate.Name = product.Name;

                await db.SaveChangesAsync();
                return productToUpdate;
            }
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            {
                Category categoryToUpdate;
                using var db = _dbContext;
                {
                    categoryToUpdate = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
                    if (categoryToUpdate == null)
                    {
                        return null;
                    }

                    categoryToUpdate.Name = category.Name;





                    await db.SaveChangesAsync();
                    return categoryToUpdate;
                }
            }
        }

        public async Task<Stock> UpdateStockAsync(int id, Stock stock)
        {
            {
                Stock stockToUpdate;
                using var db = _dbContext;
                {
                    stockToUpdate = await db.Stocks.FirstOrDefaultAsync(x => x.Id == id);
                    if (stockToUpdate == null)
                    {
                        return null;
                    }

                    stockToUpdate.Quantity = stock.Quantity;
                    stockToUpdate.ProductsId = stock.ProductsId;
                    stockToUpdate.StoreId = stock.StoreId;

                    await db.SaveChangesAsync();

                    return stockToUpdate;
                }
            }
        }

        public async Task<Store> UpdateStoreAsync(int id, Store store)
        {
            {
                Store storeToUpdate;
                using var db = _dbContext;
                {
                    storeToUpdate = await db.Stores.FirstOrDefaultAsync(x => x.Id == id);
                    if (storeToUpdate == null)
                    {
                        return null;
                    }

                    storeToUpdate.Name = store.Name;
                    storeToUpdate.Phone = store.Phone;
                    storeToUpdate.Email = store.Email;
                    storeToUpdate.AddressId = store.AddressId;



                    await db.SaveChangesAsync();

                    return storeToUpdate;
                }
            }
        }




        public async Task<Address> UpdateAddressAsync(int id, Address address)
        {
            {
                Address addressToUpdate;
                using var db = _dbContext;
                {
                    addressToUpdate = await db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
                    if (addressToUpdate == null)
                    {
                        return null;
                    }

                    addressToUpdate.Street = address.Street;
                    addressToUpdate.PostCode = address.PostCode;
                    addressToUpdate.City = address.City;

                    await db.SaveChangesAsync();

                    return addressToUpdate;
                }
            }
        }

        public async Task<Staff> UpdateStaffAsync(int id, Staff staff)
        {
            {
                Staff staffToUpdate;
                using var db = _dbContext;
                {
                    staffToUpdate = await db.Staffs.FirstOrDefaultAsync(x => x.Id == id);
                    if (staffToUpdate == null)
                    {
                        return null;
                    }

                    staffToUpdate.FirstName = staff.FirstName;
                    staffToUpdate.LastName = staff.LastName;
                    staffToUpdate.StoreId = staff.StoreId;
                    staffToUpdate.ManagerId = staff.ManagerId;


                    await db.SaveChangesAsync();

                    return staffToUpdate;
                }
            }
        }

        //Customer
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> customers;
            using (var db = _dbContext)
            {
                customers = await db.Customers.ToListAsync();
            }

            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            {

                Customer customer;

                using var db = _dbContext;
                {
                    customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == id);
                }

                return customer;
            }
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            using (var db = _dbContext)
            {
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            Customer customerToDelete;
            using (var db = _dbContext)
            {
                customerToDelete = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
                if (customerToDelete == null)
                {
                    //False means the item was not deleted.
                    return false;
                }
                else
                {
                    db.Customers.Remove(customerToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            {
                Customer customerToUpdate;
                using var db = _dbContext;
                {
                    customerToUpdate = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
                    if (customerToUpdate == null)
                    {
                        return null;
                    }

                    customerToUpdate.FirstName = customer.FirstName;
                    customerToUpdate.LastName = customer.LastName;
                    customerToUpdate.AddressId = customer.AddressId;
                    
                    await db.SaveChangesAsync();

                    return customerToUpdate;
                }
            }
        }

        //ItemOrder

        public async Task<List<ItemOrder>> GetAllItemOrdersAsync()
        {
            List<ItemOrder> itemOrders;
            using (var db = _dbContext)
            {
                itemOrders = await db.ItemsOrders.ToListAsync();
            }

            return itemOrders;
        }

        public async Task<ItemOrder> GetItemOrderByIdAsync(int id)
        {
            {

                ItemOrder itemOrder;

                using var db = _dbContext;
                {
                    itemOrder = await db.ItemsOrders.FirstOrDefaultAsync(c => c.Id == id);
                }

                return itemOrder;
            }
        }

        public async Task CreateItemOrderAsync(ItemOrder itemOrder)
        {
            using (var db = _dbContext)
            {
                await db.ItemsOrders.AddAsync(itemOrder);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteItemOrderAsync(int id)
        {
            ItemOrder itemOrder;
            using (var db = _dbContext)
            {
                itemOrder = await db.ItemsOrders.FirstOrDefaultAsync(x => x.Id == id);
                if (itemOrder == null)
                {
                    //False means the item was not deleted.
                    return false;
                }
                else
                {
                    db.ItemsOrders.Remove(itemOrder);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<ItemOrder> UpdateItemOrderAsync(int id, ItemOrder itemOrder)
        {
            {
                ItemOrder itemOrderToUpdate;
                using var db = _dbContext;
                {
                    itemOrderToUpdate = await db.ItemsOrders.FirstOrDefaultAsync(x => x.Id == id);
                    if (itemOrderToUpdate == null)
                    {
                        return null;
                    }
                    itemOrderToUpdate.OrderId = itemOrder.OrderId;
                    itemOrderToUpdate.ProductId = itemOrder.ProductId;
                    itemOrderToUpdate.Quantity = itemOrder.Quantity;
                    
                    await db.SaveChangesAsync();

                    return itemOrderToUpdate;
                }
            }
        }
    }
}
