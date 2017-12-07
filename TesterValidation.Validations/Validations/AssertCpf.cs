using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ValidationTester.Commons.Utils;

namespace TesterValidation.Validations.Validations
{
    public class AssertCpf
    {
        public static void IsValid(string cpf, Action notify)
        {
            if (cpf == null)
            {
                notify();
                return;
            }

            // If mask is detected, certify that is correct...
            if (cpf.Contains(".") || cpf.Contains("-"))
            {
                Match match = Regex.Match(cpf, @"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
                if (!match.Success)
                {
                    notify();
                    return;
                }
            }
            cpf = StringUtils.NumbersOnly(cpf);

            if ((cpf.Length < 11) || (cpf.Replace(cpf[0].ToString(), "") == ""))
            {
                notify();
                return;
            }

            int d1 = NumberUtils.Modulus11(cpf.Substring(0, 9), 11, false);
            int d2 = NumberUtils.Modulus11(cpf.Substring(0, 9) + d1, 11, false);

            string shouldBe = d1.ToString() + d2.ToString();
            string informed = cpf.Substring(9, 2);

            if (shouldBe != informed)
            {
                notify();
                return;
            }
        }
    }
}
