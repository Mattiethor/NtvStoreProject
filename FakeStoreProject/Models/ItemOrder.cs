using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class ItemOrder
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

       

    }
}

//Spyrja kennara aftur með product id. 
//Væri betra að breyta því í Public product product ?