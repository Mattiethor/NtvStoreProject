using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Staff
    {
        public Staff()
        {
            Orders = new List<Orders>();
        }
        public int Id { get; set; }
        
        [Required]
        public int StoreId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public int lastName { get; set; }

        public int managerId { get; set; }
        public List<Orders> Orders { get; set; }

    }
}

//finished ask teacher