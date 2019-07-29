using System;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс раширения для работы с объектами типа decimal
    /// </summary>
    public static class DecimalExtentionMethods
    {
        /// <summary>
        ///     Получение количество знаков дробной части
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="defaultScale">Точность по-умолчанию</param>
        /// <param name="maxScale">Максимальная точность</param>
        /// <returns>Точность</returns>
        public static int GetScaleValue(this decimal value, int defaultScale, int maxScale)
        {
            var n = 0;
            for (var r = value; r - decimal.Truncate(r) != 0; r *= 10) n++;
            if (n < defaultScale) n = defaultScale;
            return Math.Min(maxScale, n);
        }

        /// <summary>
        ///     Получение scale значения
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Scale</returns>
        public static int GetScale(this decimal value)
        {
            if (value == 0)
                return 0;
            var bits = decimal.GetBits(value);
            return (bits[3] >> 16) & 0x7F;
        }

        /// <summary>
        ///     Получение Precision значения
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Precision</returns>
        public static int GetPrecision(this decimal value)
        {
            if (value == 0)
                return 0;
            var bits = decimal.GetBits(value);
            var d = new decimal(bits[0], bits[1], bits[2], false, 0);
            return (int) Math.Floor(Math.Log10((double) d)) + 1;
        }
    }
}