using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamePlay.Models
{
    public class UserGame
    {
        public Game Game { get; set; }
        public ApplicationUser AppUser { get; set; }

        [Key]
        [Column(Order = 1)]
        public int GameId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AppUserId { get; set; }

    }
}