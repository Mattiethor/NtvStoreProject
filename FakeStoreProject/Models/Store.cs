using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models;
public class Store
{
    public Store()
    {
        Staffs = new List<Staff>();

        Orders = new List<Orders>();
    }
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    [Required]
    public string street { get; set; }
    [Required]
    public string city { get; set; }
    [Required]
    public int postcode { get; set; }

    public List<Staff> Staffs { get; set; }

    public List<Orders> Orders { get; set; }



   //finished get teachers opinion


}

