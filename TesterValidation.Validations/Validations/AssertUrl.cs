using System;
using System.Collections.Generic;
using System.Text;

namespace TesterValidation.Validations.Validations
{
    public class AssertUrl
    {
        public static void AssertIsValid(string url, string errorMessage)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                throw new InvalidOperationException(errorMessage);
        }
    }
}
