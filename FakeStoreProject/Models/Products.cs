using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Products
    {
        public Products()
        {
            ItemOrders = new List<ItemOrder>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int categoryId { get; set; }

        public int price { get; set; }
        
        public List<ItemOrder> ItemOrders { get; set; }

        
    }
}
//Búið spyrja kennara