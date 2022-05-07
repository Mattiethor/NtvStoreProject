using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Staff
    {
        public Staff()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        [Required]

        public string firstName { get; set; }
        [Required]
        public int lastName { get; set; }

        public int managerId { get; set; }
        public List<Order> Orders { get; set; }

    }
}
