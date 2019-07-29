namespace Kesco.Lib.BaseExtention.BindModels
{
    /// <summary>
    ///     Интерфейс связывателя(Binder)
    /// </summary>
    public interface IBinderValue<T>
    {
        /// <summary>
        ///     Значение
        /// </summary>
        T Value { get; set; }

        /// <summary>
        ///     Событие изменения значения
        /// </summary>
        event ValueChangedEventHandler ValueChangedEvent;

        /// <summary>
        ///     Выполяняет действия события ValueChangedEvent
        /// </summary>
        void ValueChangedEvent_Invoke(string newVal, string oldVal);
    }
}