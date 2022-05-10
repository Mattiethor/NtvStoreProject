using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Product
    {
        public Product()
        {
            ItemOrders = new List<ItemOrder>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        
        public int StockId { get; set; }

        public int ListPrice { get; set; }

        public int ModelYear { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }
        
        public List<ItemOrder> ItemOrders { get; set; }

        
    }
}
//Búið spyrja kennara