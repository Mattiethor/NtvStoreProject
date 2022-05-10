namespace FakeStoreProject.Models
{
    public class Customer
    {

        public Customer()
        {
            Orders = new List<Order>();
            Address = new Address();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}

//Búið spyrja kennara