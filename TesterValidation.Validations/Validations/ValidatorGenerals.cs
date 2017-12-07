using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TesterValidation.Validations.Validations
{
    public class ValidatorGenerals
    {
        public static void AreEqual(object object1, object object2, Action notify)
        {
            if (!object1.Equals(object2))
                notify();
        }

        public static void IsFalse(bool boolValue, Action notify)
        {
            if (boolValue)
                notify();
        }

        public static void Length(string stringValue, int maximum, Action notify)
        {
            int length = stringValue.Trim().Length;
            if (length > maximum)
                notify();
        }

        public static void Tamanho(string stringValue, int minimum, int maximum, Action notify)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
                notify();
        }

        public static void Tamanho<T>(IList<T> list, int minimum, int maximum, Action notify)
        {
            int count = list.Count;
            if (count < minimum || count > maximum)
                notify();
        }

        public static void Matches(string pattern, string stringValue, Action notify)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
                notify();
        }

        public static void NaoVazio(string value, Action notify)
        {
            if (string.IsNullOrEmpty(value))
                notify();
        }

        public static void NotEqual(object object1, object object2, Action notify)
        {
            if (object1.Equals(object2))
                notify();
        }

        public static void NaoNulo(object object1, Action notify)
        {
            if (object1 == null)
                notify();
        }

        public static void Range(decimal value, decimal minimum, decimal maximum, Action notify)
        {
            if (value < minimum || value > maximum)
                notify();
        }

        public static void Range(double value, double minimum, double maximum, Action notify)
        {
            if (value < minimum || value > maximum)
                notify();
        }

        public static void Range(float value, float minimum, float maximum, Action notify)
        {
            if (value < minimum || value > maximum)
                notify();
        }

        public static void Range(int value, int minimum, int maximum, Action notify)
        {
            if (value < minimum || value > maximum)
                notify();
        }

        public static void Range(long value, long minimum, long maximum, Action notify)
        {
            if (value < minimum || value > maximum)
                notify();
        }

        public static void Verdadeiro(bool boolValue, Action notify)
        {
            if (!boolValue)
                notify();
        }

        public static void CepValido(string number, Action notify)
        {
            Matches(@"^\d{2}(.)?\d{3}(-)?\d{3}$", number, notify);
        }

        public static void EmailValido(string email, Action notify)
        {
            Matches(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", email, notify);
        }

        public static void TelefoneValido(string number, Action notify)
        {
            Matches(@"^((\(\d{2}\))|(\d{2}))\s?(9)?(\s|-)?\d{4}\-?\d{4}", number, notify);
        }

        public static void UrlValida(string url, Action notify)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                notify();
        }

        public static void DataHoraIncorreta(DateTime data, Action notify)
        {
            if (data == DateTime.MinValue)
                notify();
        }

        public static void ValorMenorQueUm(int valor, Action notify)
        {
            if (valor < 1)
                notify();
        }
    }
}
