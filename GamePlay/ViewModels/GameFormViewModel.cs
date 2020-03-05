using GamePlay.Controllers;
using GamePlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace GamePlay.ViewModels
{
    public class GameFormViewModel
    {
        public int Id { get; set; }

        public string Desc { get; set; }

        [Required]
        [PossibleDate]
        public string Date { get; set; }

        [Required]
        [PossibleTime]
        public string  Time { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public DateTime GetDataTime()
        {         
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));           
        }

        public string Heading { get; set; }
        public string Action
        {
            get 
            {
                Expression<Func<GameController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<GameController, ActionResult>> create = (c => c.Create(this));

                var action = Id != 0 ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            } 
        }

    }
}