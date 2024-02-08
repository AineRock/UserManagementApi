using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccess.Models
{
    [Table("Profile")]
    public class Profile : BaseEntity
    {
        [JsonIgnore]
        public int UserId { get; set; }

        [Key]
        [Required]
        public string? ProfileName { get; set; }
        [Required]
        public string? ProfileDescription { get; set; }

        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
