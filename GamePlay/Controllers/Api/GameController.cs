using GamePlay.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GamePlay.Controllers.Api
{
    [Authorize]
    public class GameController : ApiController
    {
        private ApplicationDbContext context;

        public GameController()
        {
            context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id) 
        {
            var userId = User.Identity.GetUserId();
            var game = context.Games
                .Include(g => g.UserGames.Select(u => u.AppUser))
                .Single(g => g.Id == id && g.StudioId == userId);

            if (game.IsDeleted)
                return NotFound();

            game.Cancel();

            context.SaveChanges();
            return Ok();
        }
    }
}
