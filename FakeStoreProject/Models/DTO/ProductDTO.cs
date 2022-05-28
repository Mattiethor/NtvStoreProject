using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeStoreProject.Models.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            Category Category = new Category();
        }
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public int StockId { get; set; }
        [Required]
        public int ListPrice { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public string ImgUrl { get; set; }

    }
}
