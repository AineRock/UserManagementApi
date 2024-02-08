using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataAccess.Models
{ 
    [Table("dbo.Users")]
    public class User : BaseEntity
    {
        [Key]
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Profile>? Profiles { get; set; }
    }
}
