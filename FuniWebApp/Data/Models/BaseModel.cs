using System.ComponentModel.DataAnnotations;

namespace FuniWebApp.Data.Models
{
    public abstract class BaseModel
    {
        [Key, Required]
        public int Id { get; set; }
    }

}
