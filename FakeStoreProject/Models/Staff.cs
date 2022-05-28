using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeStoreProject.Models
{
    public class Staff
    {

        public Staff()
        {
            Staffs = new List<Staff>();
        }

        public int Id { get; set; }

        [Required]
        public int StoreId { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string LastName { get; set; }

        public int ManagerId { get; set; }

        //Used to assign a manager. 
        public List<Staff> Staffs { get; set; }



    }
}

