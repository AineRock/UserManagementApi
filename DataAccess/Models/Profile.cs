using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Profile : BaseEntity
    {
        public int UserId { get; set; }
        [Required]
        public string ProfileName { get; set; }
        [Required]
        public string ProfileDescription { get; set; }
    }
}
