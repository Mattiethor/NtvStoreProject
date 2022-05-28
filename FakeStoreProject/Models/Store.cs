using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeStoreProject.Models;
public class Store
{
    public Store()
    {
        Staffs = new List<Staff>();

        Orders = new List<Order>();


    }
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string Phone { get; set; }
    [Column(TypeName = "varchar(255)")]
    public string Email { get; set; }

    [Required]

    public int AddressId { get; set; }


    public List<Staff>? Staffs { get; set; }

    //can be null
    public List<Order>? Orders { get; set; }

}

