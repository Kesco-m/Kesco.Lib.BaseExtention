using System;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс раширения для работы с объектами типа decimal
    /// </summary>
    public static class DecimalExtentionMethods
    {
        /// <summary>
        /// Получение количество знаков дробной части
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="defaultScale">Точность по-умолчанию</param>
        /// <param name="maxScale">Максимальная точность</param>
        /// <returns>Точность</returns>
        public static int GetScaleValue(this decimal value, int defaultScale, int maxScale)
        {
            int n = 0;
            for (decimal r = value; r - decimal.Truncate(r) != 0; r *= 10) n++;
            if (n < defaultScale) n = defaultScale;
            return Math.Min(maxScale, n);
        }

        /// <summary>
        /// Получение scale значения
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Scale</returns>
        public static int GetScale(this decimal value)
        {
            if (value == 0)
                return 0;
            int[] bits = decimal.GetBits(value);
            return (int)((bits[3] >> 16) & 0x7F);
        }

        /// <summary>
        /// Получение Precision значения
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Precision</returns>
        public static int GetPrecision(this decimal value)
        {
            if (value == 0)
                return 0;
            int[] bits = decimal.GetBits(value);
            decimal d = new Decimal(bits[0], bits[1], bits[2], false, 0);
            return (int)Math.Floor(Math.Log10((double)d)) + 1;
        }
    }
}