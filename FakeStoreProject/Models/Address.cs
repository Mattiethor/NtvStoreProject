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
        public string Street { get; set; }

        public string City { get; set; }

        public int PostCode { get; set; }

<<<<<<< HEAD
        public List<Customer> Customers { get; set; }

        public List<Store> Stores { get; set; }
=======

>>>>>>> 7d3e6030a0d57d462bd88f35342dacfd5720f95b
    }
}
