using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Profile : BaseEntity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [Required]
        public string ProfileName { get; set; }
        [Required]
        public string ProfileDescription { get; set; }

        public string Email { get; set; }
    }
}
