using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Order
    {
        
        public int Id { get; set; }

        [Required]
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int ItemOrderId { get; set; }

    }
}

//finsished ask teacher