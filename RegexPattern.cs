using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    /// Класс содержащий разнообразные шаблоны для использования в регулярных выражениях
    /// </summary>
    public class RegexPattern
    {
        /// <summary>
        /// Шаблон телефонного номера
        /// </summary>
        public const string PhoneNumber = @"^[+]?[\d][\d\s()-.]{8,}[\d]$";

        /// <summary>
        /// Email
        /// </summary>
        public const string Email = @"^[a-z0-9_]+([-+.'][a-z0-9_]+)*@[a-z0-9_]+([-.][a-z0-9_]+)*\.\w+([-.][a-z0-9_]+)*$";

        /// <summary>
        /// Логин
        /// </summary>
        public const string Login = @"^[a-z0-9_]+([-+.'][a-z0-9_]+)*$";
    }
}
