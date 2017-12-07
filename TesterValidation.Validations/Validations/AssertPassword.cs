using System;
using System.Collections.Generic;
using System.Text;
using ValidationTester.Commons.Utils;

namespace TesterValidation.Validations.Validations
{
    public class AssertPassword
    {
        public static void AssertIsValid(string password, Action notify)
        {
            ValidatorGenerals.NaoNulo(password, notify);
        }

        public static string Encrypt(string password, string salt)
        {
            password += salt;
            return CryptoUtils.HashMD5(password);
        }
    }
}
