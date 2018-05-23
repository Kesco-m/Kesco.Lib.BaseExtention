using System;

// здесь содержатся наследники EventArgs доступные компонентам
namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    /// Класс обработки события ValueChange
    /// </summary>
    public class ValueChangedEventArgs : EventArgs
    {
        /// <summary>
        ///  Конструктор
        /// </summary>
        public ValueChangedEventArgs(string newValue, string oldValue)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }

        /// <summary>
        /// Старое значение
        /// </summary>
        public string OldValue;
        /// <summary>
        /// Новое значение
        /// </summary>
        public string NewValue;

        /// <summary>
        /// Признак изменения значения
        /// </summary>
        public bool IsChange
        {
            get { return OldValue != NewValue; }
        }
    }
}
