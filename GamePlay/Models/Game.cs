using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public bool IsDeleted { get; private set; }

        public ICollection<UserGame> UserGames { get; private set; }

        public Game()
        {
            UserGames = new Collection<UserGame>();
        }

        public void Cancel()
        {
            IsDeleted = true;

            var notification = Notification.GameCanceld(this);

            foreach (var attendee in UserGames.Select(a => a.AppUser))
            {
                attendee.Notify(notification);
            }
        }

        public void Modigy(DateTime dateTime, string desc, byte category)
        {
            var notification = Notification.GameUpdated(this, DateTime, Desc);

            Desc = desc;
            DateTime = dateTime;
            CategoryID = category;

            foreach (var attendee in UserGames.Select(a => a.AppUser))
                attendee.Notify(notification);
        }
    }

}