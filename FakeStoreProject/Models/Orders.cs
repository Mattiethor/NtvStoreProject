﻿using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Orders
    {
        
        public int Id { get; set; }

        [Required]
        public int StoreId { get; set; }
        public int customer_id { get; set; }
        [Required]
        public int staffId { get; set; }
        [Required]
        public int ItemOrderId { get; set; }

    }
}

//finsished ask teacher