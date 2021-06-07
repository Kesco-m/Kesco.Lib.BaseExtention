using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

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

        /// <summary>
        /// Клонирование листа
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="listToClone">Что клонируем</param>
        /// <returns></returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// Удаление элемента из BlockingCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="itemToRemove"></param>
        /// <returns></returns>
        public static bool Remove<T>(this BlockingCollection<T> self, T itemToRemove)
        {
            lock (self)
            {
                T comparedItem;
                var itemsList = new List<T>();
                do
                {
                    var result = self.TryTake(out comparedItem);
                    if (!result)
                        return false;
                    if (!comparedItem.Equals(itemToRemove))
                    {
                        itemsList.Add(comparedItem);
                    }
                } while (!(comparedItem.Equals(itemToRemove)));
                Parallel.ForEach(itemsList, t => self.Add(t));
            }
            return true;
        }


        /// <summary>
        /// Удаление элемента из ConcurrentDictionary
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="self"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool TryRemove<TKey, TValue>(
            this ConcurrentDictionary<TKey, TValue> self, TKey key)
        {
            TValue ignored;
            return self.TryRemove(key, out ignored);
        }

        /// <summary>
        /// Найти в перечне элемент, удовлетворяющий услувию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
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