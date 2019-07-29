using System.Text.RegularExpressions;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Различная валидация
    /// </summary>
    public class Validation
    {
        /// <summary>
        ///     Проверка, что переданная строка может является email
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
        ///     Проверка, что переданная строка может является логином
        /// </summary>
        /// <param name="login">Строка для проверки</param>
        /// <returns>true, если строка логин</returns>
        public static bool IsLogin(string login)
        {
            var pattern = new Regex(RegexPattern.Login, RegexOptions.IgnoreCase);

            var isPatternMatch = pattern.IsMatch(login);
            return isPatternMatch;
        }

        /// <summary>
        ///     Проверка, что Имя(Фамилия) есть в логине
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="name">Имя(Фамилия) сотрудника</param>
        /// <returns>true, если Имя(Фамилия) в логине</returns>
        public static bool IsNameInLogin(string login, string name)
        {
            name = name.Replace(" ", "");
            var pattern = $"^[\\.a-z]*({name})$";
            var r = new Regex(pattern, RegexOptions.IgnoreCase);
            var isPatternMatch = r.IsMatch(login);
            return isPatternMatch;
        }

        /// <summary>
        ///     Проверка вхождение имени и фамилии в название почтового ящика
        /// </summary>
        /// <param name="email">название почтового ящика</param>
        /// <param name="login">Логин</param>
        /// <param name="fName">Имя сотрудника</param>
        /// <param name="lName">Фамилия сотрудника</param>
        /// <returns></returns>
        public static bool IsNameInEmail(string email, string login, string fName, string lName)
        {
            fName = fName.Replace(" ", "");
            lName = lName.Replace(" ", "");

            var pattern = $"^({fName}\\.{lName})$";
            if (fName.Length == 0)
            {
                if (login.Length > 0)
                    pattern = $"^({login})$";
                else
                    return true;
            }

            var r = new Regex(pattern, RegexOptions.IgnoreCase);
            var isPatternMatch = r.IsMatch(email);
            return isPatternMatch;
        }
    }
}