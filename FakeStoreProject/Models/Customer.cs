namespace FakeStoreProject.Models
{
    public class Customer
    {

        public Customer()
        {
            Orders = new List<Order>();
        }
        public int Id { get; set; }

        public string firstName { get; set; }

        public int lastName { get; set; }

        //spyrja kennara
        public DateTime CreatedDate { get; set; }

        public string street { get; set; }

        public string city { get; set; }

        public string postCode { get; set; }

        List<Order> Orders { get; set; }
    }
}
