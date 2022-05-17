using System.ComponentModel.DataAnnotations.Schema;

namespace FakeStoreProject.Models
{
    public class Address
    {

        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Street { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string City { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string PostCode { get; set; }


    }
}
