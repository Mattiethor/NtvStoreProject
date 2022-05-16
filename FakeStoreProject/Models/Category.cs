﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeStoreProject.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
