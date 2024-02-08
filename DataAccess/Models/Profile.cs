using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Profile : BaseEntity
    {
        public int UserId { get; set; }

        [Key]
        [Required]
        public string ProfileName { get; set; }
        [Required]
        public string ProfileDescription { get; set; }
    }
}
