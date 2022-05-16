using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public int StockId { get; set; }
        [Required]
        public int ListPrice { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public string ImgUrl { get; set; }

        public List<ItemOrder> ItemOrders { get; set; }


    }
}
//Búið spyrja kennara