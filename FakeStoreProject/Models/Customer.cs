using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeStoreProject.Models
{
    public class Customer
    {

        public Customer()
        {
            Orders = new List<Order>();  
        }
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }

        [Required]
        public int AddressId { get; set; }
        

        public List<Order> Orders { get; set; }
    }
}

