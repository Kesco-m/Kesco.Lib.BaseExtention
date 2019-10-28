using System.Collections.Generic;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс, содержащий методы расширений для словарей
    /// </summary>
    public static class DictionaryExtensionMethods
    {
        /// <summary>
        ///     Метод поиска первого сопадения в словаре
        /// </summary>
        /// <param name="source">Словарь</param>
        /// <param name="value">Значение</param>
        /// <typeparam name="T">Тип значения</typeparam>
        /// <returns>Найдены ли совпадения</returns>
        public static bool TryFirstOrDefault<T>(this IEnumerable<T> source, out T value)
        {
            value = default(T);
            using (var iterator = source.GetEnumerator())
            {
                if (iterator.MoveNext())
                {
                    value = iterator.Current;
                    return true;
                }

                return false;
            }
        }
    }
}