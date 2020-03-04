using GamePlay.DTO;
using GamePlay.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GamePlay.Controllers
{
    [Authorize]
    public class UserGameController : ApiController
    {
        private ApplicationDbContext context;

        public UserGameController()
        {
            context = new ApplicationDbContext();
        }
        
        [HttpPost]
        public IHttpActionResult Attend(UserGameDTO dto) 
        {
            var userid = User.Identity.GetUserId();
            var duplicate = context.UserGames.Any(u => u.AppUserId == userid && u.GameId == dto.GameId);

            if (duplicate)
                return BadRequest("Already exists.");

            var games = new UserGame
            {
                GameId = dto.GameId,
                AppUserId = userid
            };

            context.UserGames.Add(games);
            context.SaveChanges();

            return Ok();
        }
    }
}
