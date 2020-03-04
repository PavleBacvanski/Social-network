using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GamePlay.ViewModels
{
    //Custom Validation
    public class PossibleDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dataTime;

            bool isValid = DateTime.TryParseExact(Convert.ToString(value), "d MMM yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dataTime);

            return isValid && dataTime > DateTime.Now;
        }

    }
}