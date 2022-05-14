using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Order
    {
        

        public int Id { get; set; }

        [Required]
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
      
       // public int StaffId { get; set; }
        
        public int ItemOrderId { get; set; }


    }
}

//finsished ask teacher