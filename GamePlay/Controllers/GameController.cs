using GamePlay.Models;
using GamePlay.ViewModels;
using Microsoft.AspNet.Identity;
using System;
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
        public ActionResult Edit(int id)
        {
            var userid = User.Identity.GetUserId();
            var game = context.Games.Single(g => g.Id == id && g.StudioId == userid);

            var viewModel = new GameFormViewModel
            {
                Categories = context.Categories.ToList(),
                Id = game.Id,
                Date = game.DateTime.ToString("d MMM yyyy"),
                Time = game.DateTime.ToString("HH:mm"),
                Category = game.CategoryID,
                Desc = game.Desc,
                Heading = "Edit a game"
            };

            return View("GameForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GameFormViewModel viewModel) 
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = context.Categories.ToList();

                return View("GameForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var game = context.Games.Single(g => g.Id == viewModel.Id && g.StudioId == userId);
            game.Desc = viewModel.Desc;
            game.DateTime = viewModel.GetDataTime();
            game.CategoryID = viewModel.Category;

            context.SaveChanges();

            return RedirectToAction("Mine", "Game");
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var games = context.Games
                .Where(g => g.StudioId == userId && g.DateTime > DateTime.Now && !g.IsDeleted)
                .Include(g => g.Category)
                .ToList();

            return View(games);
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
                Categories = context.Categories.ToList(),
                Heading = "Add a game"
            };

            return View("GameForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = context.Categories.ToList();

                return View("GameForm", viewModel);
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

            return RedirectToAction("Mine", "Game");
        }
    }
}