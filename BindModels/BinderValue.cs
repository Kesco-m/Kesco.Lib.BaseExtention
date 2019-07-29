using System;

namespace Kesco.Lib.BaseExtention.BindModels
{
    /// <summary>
    ///     Класс хронящий в себе одно string значение, с возможностью уведомлений об изменении
    /// </summary>
    /// <remarks>Основное предназначение - двухстронний binding при помощи классов V4Binding</remarks>
    /// <example>Пример использования есть в DocPage для Number и Description</example>
    [Serializable]
    public class BinderValue : IBinderValue<string>
    {
        private string _value;

        /// <summary>
        ///     Значение
        /// </summary>
        public string Value
        {
            get { return _value; }
            set
            {
                ValueChangedEvent_Invoke(value, _value);
                _value = value;
            }
        }

        /// <summary>
        ///     Выполяняет действия события ValueChangedEvent
        /// </summary>
        public void ValueChangedEvent_Invoke(string newVal, string oldVal)
        {
            var handler = ValueChangedEvent;

            if (handler != null)
                handler(this, new ValueChangedEventArgs(newVal, oldVal));
        }

        /// <summary>
        ///     Событие изменения значения
        /// </summary>
        public event ValueChangedEventHandler ValueChangedEvent;

        /// <summary>
        ///     Добавить значение без генерации события об изменении
        /// </summary>
        public void SetValueWithoutEvent(string value)
        {
            _value = value;
        }
    }
}