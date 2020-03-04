using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamePlay.Models
{
    public class Follow
    {
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FolloweeID { get; set; }

        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followee { get; set; }

    }
}