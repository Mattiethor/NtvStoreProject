using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Categories
    {
        public Categories()
        {
            Products = new List<Products>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        List<Products> Products { get; set; }
    }
}
