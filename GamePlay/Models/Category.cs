using System.ComponentModel.DataAnnotations;

namespace GamePlay.Models
{
    public class Category
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; } 
    }
}