using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Stock
    {
        public int Id { get; set; }

        [Required]
        public int StoreId { get; set; }
        [Required]
        public int ProductsId { get; set; }

        public int Quantity { get; set; }
    }
}
