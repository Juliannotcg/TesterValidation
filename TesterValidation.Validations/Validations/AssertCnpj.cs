using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TesterValidation.Validations.Validations
{
    public class AssertCnpj
    {
        public static void IsValid(string cnpj, Action notify)
        {
            if (cnpj == null)
            {
                notify();
                return;
            }

            // If mask is detected, certify that is correct...
            if (cnpj.Contains(".") || cnpj.Contains("-"))
            {
                Match match = Regex.Match(cnpj, @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$");
                if (!match.Success)
                {
                    notify();
                    return;
                }
            }
            //cnpj = StringUtils.NumbersOnly(cnpj);

            if (cnpj.Length < 14)
            {
                notify();
                return;
            }

            // eliminando os iguais
            if (cnpj.Replace(cnpj[0].ToString(), "") == "")
            {
                notify();
                return;
            }

            //int d1 = NumberUtils.Modulus11(cnpj.Substring(0, 12), 9, false);
            //int d2 = NumberUtils.Modulus11(cnpj.Substring(0, 12) + d1, 9, false);

            string shouldBe = d1.ToString() + d2.ToString();
            string informed = cnpj.Substring(12);

            if (shouldBe != informed)
            {
                notify();
                return;
            }
        }
    }
}
