using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TesterValidation.Validations.Validations
{
    public class AssertZipCode
    {
        public static void AssertValid(string zipCode, Action notify)
        {
            if (!Regex.IsMatch(zipCode, @"^\d{2}(.)?\d{3}(-)?\d{3}$", RegexOptions.IgnoreCase))
                notify();
        }
    }
}
