using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TesterValidation.Validations.Validations
{
    public class AssertPhone
    {
        public static void AssertIsValid(string phone, string errorMessage)
        {
            /*
                Formatos aceitos:

                (61)99999 - 9999
                (61)9999 - 9999
                (61) 9999 - 9999
                (61) 99999 - 9999
                (61) 9 9999 - 9999
                61999999999
            */
            if (!Regex.IsMatch(phone, @"^((\(\d{2}\))|(\d{2}))\s?(9)?(\s|-)?\d{4}\-?\d{4}", RegexOptions.IgnoreCase))
                throw new InvalidOperationException(errorMessage);
        }
    }
}
