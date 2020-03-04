using GamePlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamePlay.ViewModels
{
    public class GameFormViewModel
    {
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

    }
}