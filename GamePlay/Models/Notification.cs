using System;
using System.ComponentModel.DataAnnotations;

namespace GamePlay.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalDesc { get; private set; }


        [Required]
        public Game Game { get; set; }

        private Notification(NotificationType type, Game game)
        {
            if (game == null)
                throw new ArgumentNullException("game");

            Type = type;
            Game = game;
            DateTime = DateTime.Now;
        }

        //Factory Methods
        public static Notification GameCreated(Game game)
        {
            return new Notification(NotificationType.GameCreated, game);
        }
        public static Notification GameUpdated(Game newGame, DateTime originalDataTime, string desc)
        {
            var notification = new Notification(NotificationType.GameUpdateed, newGame);
            notification.OriginalDateTime = originalDataTime;
            notification.OriginalDesc = desc;

            return notification;
        }

        public static Notification GameCanceld(Game game)
        {
            return new Notification(NotificationType.GameCanceled, game);
        }
    }
}

