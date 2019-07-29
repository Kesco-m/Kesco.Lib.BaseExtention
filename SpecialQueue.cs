using System.Collections.Generic;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс, реализующий специализированную очередь объектов.
    ///     Используется, например для хранения полей сортировки.
    ///     Позволяет легко менять порядок сортировки
    /// </summary>
    /// <typeparam name="T">Динамический тип данных</typeparam>
    public class SpecialQueue<T>
    {
        /// <summary>
        ///     Список объектов
        /// </summary>
        public LinkedList<T> QE = new LinkedList<T>();

        /// <summary>
        ///     Количество объектов в очереди
        /// </summary>
        public int Count => QE.Count;

        /// <summary>
        ///     Получение списка объектов через ',' в порядке от конца к началу очереди
        /// </summary>
        public string ReverseListValues
        {
            get
            {
                if (QE.Count == 0) return "";

                LinkedListNode<T> node;
                var s = "";

                for (node = QE.Last; node != null; node = node.Previous)
                {
                    s += node.Value;
                    if (!node.Equals(QE.First)) s += ", ";
                }

                return s;
            }
        }

        /// <summary>
        ///     Добавление объекта в конец очередь
        /// </summary>
        /// <param name="t">Объект, который необходимо добавить в очередь</param>
        public void Enqueue(T t)
        {
            QE.AddLast(t);
        }

        /// <summary>
        ///     Удаление первого объекта из очереди
        /// </summary>
        /// <returns>Результат операции</returns>
        public T Dequeue()
        {
            var result = QE.First.Value;
            QE.RemoveFirst();
            return result;
        }

        /// <summary>
        ///     Получение последнего элемента в очереди
        /// </summary>
        /// <returns>Значение объекта</returns>
        public T Last()
        {
            return QE.Last.Value;
        }

        /// <summary>
        ///     Удаление конкретного объекта из очереди
        /// </summary>
        /// <param name="t">Объект, который необходимо удалить из очередь</param>
        /// <returns>Результат операции</returns>
        public bool Remove(T t)
        {
            return QE.Remove(t);
        }
    }
}