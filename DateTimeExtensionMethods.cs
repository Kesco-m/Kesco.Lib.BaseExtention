using System;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     расширяющие методы для DateTime
    /// </summary>
    /// <remarks>
    ///     Класс в котором хранится все расширяющие методы для DateTime,
    ///     чтобы было все в одном месте
    /// </remarks>
    public static class DateTimeExtensionMethods
    {
        /// <summary>
        ///     Мнимальное значение даты 01-01-1900
        /// </summary>
        /// <remarks>
        ///     Это минимальное значение для smalldatetime
        /// </remarks>
        public static readonly DateTime MinDateTime = new DateTime(1900, 1, 1);

        /// <summary>
        ///     Дата завершения - значение даты 06-06-2079
        /// </summary>
        /// <remarks>
        ///     Это максимальное значение для smalldatetime
        /// </remarks>
        public static readonly DateTime EndDateTime = new DateTime(2079, 6, 6);

        /// <summary>
        ///     Between как в SQL
        /// </summary>
        public static bool Between(this DateTime input, DateTime minDate, DateTime maxDate)
        {
            return input >= minDate && input <= maxDate;
        }

        /// <summary>
        ///     Преобразование к дате SQL
        /// </summary>
        public static string ToSqlDate(this DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }

        /// <summary>
        ///     Преобразование к дате SQL
        /// </summary>
        public static string ToSqlDate(this DateTime? value)
        {
            if (value == null)
                return null;

            return value.Value.ToString("yyyyMMdd");
        }

        /// <summary>
        ///     Преобразование к дате и времени SQL
        /// </summary>
        public static string ToSqlDateTime(this DateTime value)
        {
            return value.ToString("yyyyMMdd HH:mm:ss");
        }

        /// <summary>
        ///     Получение календарного дня: 1 => 01
        /// </summary>
        public static string GetCalendarDay(this DateTime value)
        {
            if (value.Day < 10)
                return "0" + value.Day;

            return value.Day.ToString();
        }

        /// <summary>
        ///     Получение календарного месяца: 1 => 01
        /// </summary>
        public static string GetCalendarMonth(this DateTime value)
        {
            if (value.Month < 10)
                return "0" + value.Month;

            return value.Month.ToString();
        }

        /// <summary>
        ///     Получение календарного года: 1 => 0001
        /// </summary>
        public static string GetCalendarYear(this DateTime value)
        {
            if (value.Year < 10)
                return "000" + value.Year;
            if (value.Year < 100)
                return "00" + value.Year;
            if (value.Year < 1000)
                return "0" + value.Year;

            return value.Year.ToString();
        }

        /// <summary>
        ///     Получение часа в строковом формате: 1 => 01
        /// </summary>
        public static string GetHourString(this DateTime value)
        {
            if (value.Hour < 10)
                return "0" + value.Hour;

            return value.Hour.ToString();
        }

        /// <summary>
        ///     Получение часа в строковом формате: 1 => 01
        /// </summary>
        public static string GetMinuteString(this DateTime value)
        {
            if (value.Minute < 10)
                return "0" + value.Minute;

            return value.Minute.ToString();
        }

        /// <summary>
        ///     Получение даты в формате dd.MM.yyyy не зависимо от культуры
        /// </summary>
        public static string GetIndependenceDate(this DateTime value)
        {
            return value.GetCalendarDay() + "." + value.GetCalendarMonth() + "." + value.GetCalendarYear();
        }

        /// <summary>
        ///     Получение даты и времени в формате dd.MM.yyyy HH:mm не зависимо от культуры
        /// </summary>
        public static string GetIndependenceDateTime(this DateTime value)
        {
            return value.GetIndependenceDate() + " " + value.GetHourString() + ":" + value.GetMinuteString();
        }


        /// <summary>
        ///     Возвращает нормализованные граничные значения для SQL
        /// </summary>
        public static DateTime ToSqlDateNormalized(this DateTime value)
        {
            var minDate = MinDateTime;

            if (value < minDate) return minDate;

            var maxDate = EndDateTime;

            if (value > maxDate) return maxDate;

            return value;
        }

        /// <summary>
        ///     Возвращает нормализованные граничные значения для SQL
        /// </summary>
        public static DateTime? ToSqlDateNormalized(this DateTime? value)
        {
            if (value == null)
                return MinDateTime;

            var minDate = MinDateTime;

            if (value < minDate) return minDate;

            var maxDate = EndDateTime;

            if (value > maxDate) return maxDate;

            return value;
        }
    }
}