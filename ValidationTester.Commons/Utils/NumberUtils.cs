using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationTester.Commons.Utils
{
    public class NumberUtils
    {
        private static StringBuilder sb = new StringBuilder(100);

        /// <summary>
        /// Simple checksum formula used to validate a variety of identification numbers.
        /// </summary>
        /// <param name="number">Number to validate (prior check-digit).</param>
        /// <returns>Returns the check-digit o the number.</returns>
        public static int Modulus10(string number)
        {
            /*
             * Rotina usada para cálculo de alguns dígitos verificadores
             * Pega-se cada um dos dígitos contidos no parâmetro VALOR, da direita para a
             * esquerda e multiplica-se por 2121212...
             * Soma-se cada um dos subprodutos. Caso algum dos subprodutos tenha mais de um
             * dígito, deve-se somar cada um dos dígitos. (Exemplo: 7*2 = 14 >> 1+4 = 5)
             * Divide-se a soma por 10.
             * Faz-se a operação 10-Resto da divisão e devolve-se o resultado dessa operação
             * como resultado da função Modulo10.
             * Obs.: Caso o resultado seja maior que 9, deverá ser substituído por 0 (ZERO).
             * 
             * Mais informações sobre o Modulus10 podem ser obtidas na Wikipedia:
             * https://en.wikipedia.org/wiki/Luhn_algorithm
             * */
            sb.Clear();
            int mult = 2;
            int digit = 0;

            for (int i = (number.Length - 1); i >= 0; i--)
            {
                sb.Insert(0, int.Parse(number[i].ToString()) * mult);
                if (mult == 1)
                    mult = 2;
                else
                    mult = 1;
            }

            for (int i = 0; i < sb.Length; i++)
                digit += int.Parse(sb[i].ToString());

            digit = 10 - (digit % 10);

            if (digit > 9)
                digit = 0;

            return digit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Modulus11(string number, int basis, bool remainder)
        {
            /*
             * Rotina muito usada para calcular dígitos verificadores
             * Pega-se cada um dos dígitos contidos no parâmetro VALOR, da direita para a
             * esquerda e multiplica-se pela seqüência de pesos 2, 3, 4 ... até BASE.
             * Por exemplo: se a base for 9, os pesos serão 2,3,4,5,6,7,8,9,2,3,4,5...
             * Se a base for 7, os pesos serão 2,3,4,5,6,7,2,3,4...
             * Soma-se cada um dos subprodutos.
             * Divide-se a soma por 11.
             * Faz-se a operação 11-Resto da divisão e devolve-se o resultado dessa operação
             * como resultado da função Modulo11.
             * Obs.: Caso o resultado seja maior que 9, deverá ser substituído por 0 (ZERO).
             * */
            int sum = 0;
            int mult = 2;
            int digit = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                sum += int.Parse(number[i].ToString()) * mult;
                if (mult < basis)
                    mult++;
                else
                    mult = 2;
            }

            if (remainder)
                return sum % 11;
            else
            {
                digit = 11 - (sum % 11);
                if (digit > 9)
                    digit = 0;
                return digit;
            }
        }

        /// <summary>
        /// Returns the decimal part af a number.
        /// </summary>
        /// <param name="value">Number whose decimal part shall be analysed.</param>
        /// <returns>Returns a integer number which corresponds to the decimal part of the informed number.</returns>
        public static int ReturnDecimals(Decimal value)
        {
            // Removes the integer part
            value -= Math.Truncate(value);

            int result = 0;
            while (value > 0)
            {
                result = (result * 10) + Convert.ToInt32(Math.Truncate(value * 10));
                value = value * 10 - Math.Truncate(value * 10);
            }
            return result;
        }
    }
}
