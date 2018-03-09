using System.ComponentModel.DataAnnotations;

namespace Boilerplate.API.Database.Models
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
