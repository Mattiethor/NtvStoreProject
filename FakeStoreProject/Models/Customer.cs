namespace FakeStoreProject.Models
{
    public class Customer
    {

        public Customer()
        {
            Orders = new List<Orders>();
        }
        public int Id { get; set; }

        public string firstName { get; set; }

        public int lastName { get; set; }

        public string street { get; set; }

        public string city { get; set; }

        public string postCode { get; set; }

        List<Orders> Orders { get; set; }
    }
}

//Búið spyrja kennara