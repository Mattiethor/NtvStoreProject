using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Order
    {
        
        [Key]
        public int OrderId { get; set; }

        //ask teacher
       /* [Required]
        public int StoreId { get; set; } */

        public int CustomerId { get; set; }
        [Required]
        public int StaffId { get; set; }
        [Required]
        public int ItemOrderId { get; set; }

    }
}

