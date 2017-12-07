using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidationTester.Commons.Utils
{
    public class StringUtils
    {
        /// <summary>
        /// StringBuilder that will hold the current expected value.
        /// </summary>
        private static StringBuilder sb = new StringBuilder(100);

        /// <summary>
        /// Temporary auxiliar StringBuilder that will be used to manipulate data that will be appended/inserted into "sb" final value.
        /// </summary>
        private static StringBuilder aux = new StringBuilder(100);

        public enum FillPosition
        {
            Left,
            Right
        }

        /// <summary>
        /// Preenche uma string com o caracter informado.
        /// </summary>
        /// <param name="text">Texto a ser complementado</param>
        /// <param name="finalLength">Tamanho final que o texto deverá ter..</param>
        /// <param name="letter">Letra a ser usada para preencher o texto.</param>
        /// <param name="position">Em qual lado do texto a letra informada deverá ser usada para complementar o texto.</param>
        /// <returns>Retorna o texto original preenchido conforme o informado.</returns>
        public static string Fill(string text, int finalLength, char letter, FillPosition position)
        {
            if (text == null)
                text = "";

            if (text.Length == finalLength)
                return text;
            else if (text.Length > finalLength)
                switch (position)
                {
                    case FillPosition.Left:
                        return text.Substring(text.Length - finalLength);
                    default:
                        return text.Substring(0, finalLength);
                }
            else
            {
                aux.Clear();
                aux.Append(text);
                int times = finalLength - text.Length;
                switch (position)
                {
                    case FillPosition.Left:
                        aux.Insert(0, letter.ToString(), times);
                        return aux.ToString();
                    default:
                        aux.Append(letter, times);
                        return aux.ToString();
                }
            }
        }

        /// <summary>
        /// Recebe um valor de entrada e retorna somente os números constatntes nele.
        /// </summary>
        /// <param name="text">Texto de onde serão extraídos os números</param>
        /// <returns>Retorna somente os números contidos na String inicial</returns>
        public static String NumbersOnly(string text)
        {
            return Regex.Replace(text, @"[^\d]", "");
        }

        /// <summary>
        /// Remove os zeros à esquerda de um número
        /// </summary>
        /// <param name="number">Número a ser analisado.</param>
        /// <returns></returns>
        public static string RemoveLeadingZeros(string number)
        {
            return number.TrimStart('0');
        }

        /// <summary>
        /// Retira acentos do texto informado.
        /// </summary>
        /// <param name="text">Texto cujos caracteres devem ser removidos.</param>
        /// <returns>Retorna o texto original sem a acentuação e caracteres especiais.</returns>
        public static String RemoveAccents(string text)
        {
            /*
             * A rotina abaixo foi retirada do endereço:
             * http://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
             * Data/Hora: 23/09/2016 09:34
             */
            String normalizedString = text.Normalize(NormalizationForm.FormD);
            sb.Clear();

            foreach (char c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Retira acentos do texto informado.
        /// </summary>
        /// <param name="text">Texto cujos caracteres devem ser removidos.</param>
        /// <returns>Retorna o texto original sem a acentuação e caracteres especiais.</returns>
        public static String RemoveAccentsAndSpecialCharacters(string text)
        {
            /*
             * A rotina abaixo foi retirada do endereço:
             * http://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
             * Data/Hora: 23/09/2016 09:34
             */
            String normalizedString = text.Normalize(NormalizationForm.FormD);
            sb.Clear();

            foreach (char c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    if (((c >= '0') && (c <= '9')) ||
                        ((c >= 'a') && (c <= 'z')) ||
                        ((c >= 'A') && (c <= 'Z')) ||
                        (c == ' '))
                        sb.Append(c);
                    else
                        sb.Append("");
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Leaves only A-Z and 0-9 characters (ignores case).
        /// </summary>
        /// <param name="text">Text to be analaysed</param>
        /// <returns>Retorna apenas as letras e números do texto original.</returns>
        public static String PureText(string text, bool keepSpaces = true)
        {
            if (keepSpaces)
                return Regex.Replace(text, @"[^a-zA-Z\d\s]*", "");
            else
                return Regex.Replace(text, @"[^a-zA-Z\d]*", "");
        }

        /// <summary>
        /// Formata um texto para ter um determinado tamanho.
        /// </summary>
        /// <param name="text">Texto a ser formatado</param>
        /// <param name="length">Tamanho desejado para o texto.</param>
        /// <returns>Retorna o texto formatado preenchendo-o com espaços em branco à direita quando ele não atende o tamanho informado ou cortando-o quando ultrapassa o tamanho desejado.</returns>
        public static String FormatText(String text, int length)
        {
            return Fill(text, length, ' ', FillPosition.Right);
        }

        /// <summary>
        /// Converte um número em uma string com um determinado tamanho.
        /// </summary>
        /// <param name="number">Número a ser formatado</param>
        /// <param name="length">Tamanho desejado para o texto.</param>
        /// <returns>Retorna o número formatado preenchendo-o com zeros zeros à esquerda quando ele não atende o tamanho informado ou cortando-o quando ultrapassa o tamanho desejado.</returns>
        public static String FormatNumber(long number, int length)
        {
            // Retorna o módulo (ou valor absoluto) do número informado.
            number = Math.Abs(number);
            return Fill(number.ToString(), length, '0', FillPosition.Left);
        }

        /// <summary>
        /// Converte um número em uma string com um determinado tamanho.
        /// </summary>
        /// <param name="value">Número a ser formatado</param>
        /// <param name="length">Tamanho desejado para o texto.</param>
        /// <returns>Retorna o número formatado preenchendo-o com zeros zeros à esquerda quando ele não atende o tamanho informado ou cortando-o quando ultrapassa o tamanho desejado.</returns>
        public static string FormatNumber(string value, int length)
        {
            return Fill(NumbersOnly(value), length, '0', FillPosition.Left);
        }

        /// <summary>
        /// Converte um número em uma string com um determinado tamanho, removendo os algarismos à direita caso ele seja maior que o tamanho informado.
        /// (usado, essencialmente, para geração de Nosso Número no BRB)
        /// </summary>
        /// <param name="value">Número a ser formatado</param>
        /// <param name="length">Tamanho desejado para o texto.</param>
        /// <returns>Retorna o número formatado preenchendo-o com zeros zeros à esquerda quando ele não atende o tamanho informado ou cortando-o quando ultrapassa o tamanho desejado.</returns>
        public static String FormatNumberTrimLeft(long value, int length)
        {
            string text = Math.Abs(value).ToString();
            if (text.Length > length)
                return text.Substring(text.Length - length, length);
            else
                return Fill(text, length, '0', FillPosition.Left);
        }

        /// <summary>
        /// Converte um número em uma string com um determinado tamanho, removendo os algarismos à direita caso ele seja maior que o tamanho informado.
        /// (usado, essencialmente, para geração de Nosso Número no BRB)
        /// </summary>
        /// <param name="value">Número a ser formatado</param>
        /// <param name="length">Tamanho desejado para o texto.</param>
        /// <returns>Retorna o número formatado preenchendo-o com zeros zeros à esquerda quando ele não atende o tamanho informado ou cortando-o quando ultrapassa o tamanho desejado.</returns>
        public static String FormatNumberTrimLeft(string value, int length)
        {
            value = NumbersOnly(value);
            if (value.Length > length)
                return value.Substring(value.Length - length, length);
            else
                return Fill(value, length, '0', FillPosition.Left);
        }

        /// <summary>
        /// Converte um número em uma string com um determinado tamanho.
        /// </summary>
        /// <param name="value">Número a ser formatado</param>
        /// <param name="integers">Tamanho desejado para a parte inteira.</param>
        /// <param name="decimals">Tamanho desejado para a parte decimal.</param>
        /// <returns>Retorna o número formatado preenchendo-o com zeros zeros à esquerda na parte inteira e zeros à direita na parte decimal.</returns>
        public static string FormatNumber(decimal value, int integers, int decimals)
        {

            decimal raised = Convert.ToDecimal(Math.Pow(10, decimals)) * value;
            return FormatNumber(Convert.ToInt64(Math.Truncate(raised)), integers + decimals);
        }

        public static string Reverse(string value)
        {
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
