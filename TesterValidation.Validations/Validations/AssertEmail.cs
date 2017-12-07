using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TesterValidation.Validations.Validations
{
    public class AssertEmail
    {
        public static void AssertIsValid(string email, string errorMessage)
        {
            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                throw new InvalidOperationException(errorMessage);
        }
    }
}
