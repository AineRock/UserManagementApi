using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; }
    }
}
