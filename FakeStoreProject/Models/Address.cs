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

        public List<Customer> Customers { get; set; }

        public List<Store> Stores { get; set; }
    }
}
