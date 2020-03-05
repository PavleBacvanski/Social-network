using System;
using System.ComponentModel.DataAnnotations;

namespace GamePlay.Models
{
    public class Game
    {
        public int Id { get; set; }

        public ApplicationUser Studio { get; set; }

        [Required]
        public string StudioId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Desc { get; set; } 

        public Category Category { get; set; }

        [Required]
        public byte CategoryID { get; set; }

        public bool IsDeleted { get; set; }

    }

}