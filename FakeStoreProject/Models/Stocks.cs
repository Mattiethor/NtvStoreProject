using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Stocks
    {
        public int Id { get; set; }

        [Required]
        public int StoreId { get; set; }
        [Required]
        public int ProductsId { get; set; }

        public int quantity { get; set; }
    }
}
