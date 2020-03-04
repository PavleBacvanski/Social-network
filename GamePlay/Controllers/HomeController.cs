using GamePlay.Models;
using GamePlay.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GamePlay.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;

        public HomeController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var games = context.Games.Include(g => g.Studio)
                .Include(g => g.Category)
                .Where(g => g.DateTime > DateTime.Now);

            var relesedGames = context.Games.Include(g => g.Studio)
                            .Include(g => g.Category)
                            .Where(g => g.DateTime <= DateTime.Now);

            var viewModel = new HomeViewModel
            {
                UpcomingGames = games,
                ShowActions = User.Identity.IsAuthenticated,
                RelesedGames = relesedGames
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}