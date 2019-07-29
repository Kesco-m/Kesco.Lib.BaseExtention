using System;
using System.Collections.Generic;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     расширяющие методы для различных коллекций
    /// </summary>
    /// <remarks>
    ///     Класс в котором хранится все расширяющие методы для коллекций,
    ///     чтобы было все в одном месте
    /// </remarks>
    public static class CollectionExtension
    {
        /// <summary>
        ///     Добавляет в коллекцию Set
        /// </summary>
        public static void AddCollection<T>(this ISet<T> s, IEnumerable<T> c)
        {
            if (c != null)
                foreach (var i in c)
                    s.Add(i);
        }

        /// <summary>
        ///     Клонирует коллекцию, создает новую коллекцию(с новой ссылкой)
        ///     с копированными значениями(ссылка новая, значения старые), все значения должны иметь типизированный интерфейс
        ///     ICloneable.
        ///     Корректно обрабатывает null параметры
        /// </summary>
        public static void CloneList<T>(this List<T> l, List<T> c)
        {
            if (c != null && l != null)
            {
                l = new List<T>(c.Count);

                foreach (var i in c)
                {
                    var cl = i as ICloneable<T>;
                    if (cl != null)
                        l.Add(cl.Clone());
                    else // сообщение программисту, чтобы явно указать ошибку
                        throw new Exception(
                            "Для использования CloneList необходимо чтобы класс поддерживал интерфейс ICloneable<T>");
                }
            }
        }
    }
}