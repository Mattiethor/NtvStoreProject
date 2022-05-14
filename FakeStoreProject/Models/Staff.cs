using System.ComponentModel.DataAnnotations;

namespace FakeStoreProject.Models
{
    public class Staff
    {
        
       
        
        public int Id { get; set; }
        
        [Required]
        public int StoreId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        //Skoða betur
        public int ManagerId { get; set; }

       

    }
}

