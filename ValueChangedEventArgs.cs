using System;

// здесь содержатся наследники EventArgs доступные компонентам
namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс обработки события ObjectChange
    /// </summary>
    public class ObjectChangedEventArgs : EventArgs
    {
        /// <summary>
        ///     Новое значение
        /// </summary>
        public object NewValue;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="newValue">Измененный объект</param>
        public ObjectChangedEventArgs(object newValue)
        {
            NewValue = newValue;
        }
    }


        /// <summary>
        ///     Класс обработки события ValueChange
        /// </summary>
        public class ValueChangedEventArgs : EventArgs
    {
        /// <summary>
        ///     Новое значение
        /// </summary>
        public string NewValue;

        /// <summary>
        ///     Старое значение
        /// </summary>
        public string OldValue;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public ValueChangedEventArgs(string newValue, string oldValue)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }

        /// <summary>
        ///     Признак изменения значения
        /// </summary>
        public bool IsChange => OldValue != NewValue;
    }
}