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




    }
}
