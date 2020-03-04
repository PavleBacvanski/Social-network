using GamePlay.Models;
using GamePlay.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GamePlay.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext context;

        public GameController()
        {
            context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userid = User.Identity.GetUserId();
            var games = context.UserGames.Where(u => u.AppUserId == userid)
                .Select(u => u.Game)
                .Include(g => g.Studio)
                .Include(g => g.Category)
                .ToList();

            var viewModel = new HomeViewModel()
            {
                UpcomingGames = games,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        // GET: Game
        [Authorize]
        public ActionResult Create() 
        {
            var viewModel = new GameFormViewModel
            {
                Categories = context.Categories.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = context.Categories.ToList();

                return View("Create", viewModel);
            }

            var game = new Game
            {
                StudioId = User.Identity.GetUserId(), 
                DateTime = viewModel.GetDataTime(),
                CategoryID = viewModel.Category,
                Desc = viewModel.Desc
            };

            context.Games.Add(game);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}