using System.ComponentModel.DataAnnotations.Schema;

namespace FakeStoreProject.Models
{
    public class Address
    {

        public Address()
        {
            Customers = new List<Customer>();
            Stores = new List<Store>();
        }

        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Street { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string PostCode { get; set; }

        public List<Customer> Customers { get; set; }

        public List<Store> Stores { get; set; }



    }
}
