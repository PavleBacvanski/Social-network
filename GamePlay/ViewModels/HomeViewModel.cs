using GamePlay.Models;
using System.Collections.Generic;

namespace GamePlay.ViewModels
{
    public class HomeViewModel
    {
        //relesed
        public IEnumerable<Game> RelesedGames { get; set; } 
        public IEnumerable<Game> UpcomingGames { get; set; }
        public bool ShowActions { get; set; }

    }
}