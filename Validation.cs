using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    /// Различная валидация
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Проверка, что переданная строка может является email
        /// </summary>
        /// <param name="email">Строка для проверки</param>
        /// <returns>true, если строка email</returns>
        public static bool IsEmail(string email)
        {

            var reLenient = new Regex(RegexPattern.Email, RegexOptions.IgnoreCase);

            var isLenientMatch = reLenient.IsMatch(email);
            return isLenientMatch;
        }

        /// <summary>
        /// Проверка, что переданная строка может является логином
        /// </summary>
        /// <param name="login">Строка для проверки</param>
        /// <returns>true, если строка логин</returns>
        public static bool IsLogin(string login)
        {
            var reLenient = new Regex(RegexPattern.Login, RegexOptions.IgnoreCase);

            var isLenientMatch = reLenient.IsMatch(login);
            return isLenientMatch;
        }
    }
}
