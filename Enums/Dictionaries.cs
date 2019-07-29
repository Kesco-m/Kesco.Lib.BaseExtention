namespace Kesco.Lib.BaseExtention.Enums
{
    /// <summary>
    ///     Класс списка месяцев в разных падежах
    /// </summary>
    public sealed class Dictionaries
    {
        /// <summary>
        ///     Список в именительном падеже
        /// </summary>
        public static string[] Month = new string[12]
        {
            "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь",
            "декабрь"
        };

        /// <summary>
        ///     Список в родительном падеже
        /// </summary>
        public static string[] MonthRP = new string[12]
        {
            "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября",
            "декабря"
        };

        /// <summary>
        ///     Список в дательном падеже
        /// </summary>
        public static string[] MonthWhen = new string[12]
        {
            "январе", "феврале", "марте", "апреле", "мае", "июне", "июле", "августе", "сентябре", "октябре", "ноябре",
            "декабре"
        };
    }
}