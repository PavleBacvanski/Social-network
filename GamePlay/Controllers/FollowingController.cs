using GamePlay.DTO;
using GamePlay.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GamePlay.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private ApplicationDbContext context;

        public FollowingController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDTO dto)
        {
            var userId = User.Identity.GetUserId();

            var following = context.Follows.Any(f => f.FolloweeID == userId && f.FolloweeID == dto.FolloweeId);

            if (following)
                return BadRequest("Follow already exists!");

            var follow = new Follow
            {
                FollowerId = userId,
                FolloweeID = dto.FolloweeId
            };

            context.Follows.Add(follow);
            context.SaveChanges();

            return Ok();
        }
    }
}
