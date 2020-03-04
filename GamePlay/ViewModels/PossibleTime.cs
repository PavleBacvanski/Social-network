using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GamePlay.ViewModels
{
    //Custom Validation
    public class PossibleTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            DateTime dataTime;

            bool isValid = DateTime.TryParseExact(Convert.ToString(value), "HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out dataTime);

            return isValid;
        }
    }
}