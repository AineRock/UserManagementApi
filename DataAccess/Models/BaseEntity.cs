using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
