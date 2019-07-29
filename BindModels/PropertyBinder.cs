using System;
using System.Globalization;
using System.Reflection;

namespace Kesco.Lib.BaseExtention.BindModels
{
    /// <summary>
    ///     Двухсторонний байдинг.
    ///     Класс "связыватель" контрола и полей класса: при измении контрола изменяется модель и наоборот
    /// </summary>
    /// <remarks>Если поле типа string лучше использовать BinderValue</remarks>
    /// <example>
    ///     Допустим необходимо связать TextBox и свойство "Description" в объекте Document:
    ///     Создаем поле: PropertyBinder DescriptionBinder;
    ///     В конструкторе класса инициализируем: DescriptionBinder = new PropertyBinder(this, "Description");
    ///     Присваиваем байндер контролу TextBoxControl.BindStringValue = Doc.DescriptionBinder;
    ///     Можно пользоватся:
    ///     При изменении значения в TextBox тут же изменяется значение "Description" в объекте Document
    ///     При присваивании значения DescriptionBinder.Value = "Пример текста"; на контроле отображается присвоенное значение
    /// </example>
    public class PropertyBinder : IBinderValue<string>
    {
        private readonly object _obj;

        private readonly PropertyInfo _property;
        private readonly Type _propertyType;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="obj">Обьект, в котором содержится поле</param>
        /// <param name="propName">Название поля</param>
        public PropertyBinder(object obj, string propName)
        {
            _obj = obj;
            var t = obj.GetType();
            _property = t.GetProperty(propName);
            _propertyType = _property.PropertyType;
        }

        private string _value
        {
            get { return GetPropertyValue(); }
            set { SetPropertyValue(value); }
        }

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
        ///     Событие изменения значения
        /// </summary>
        public event ValueChangedEventHandler ValueChangedEvent;


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
        ///     Получить значение свойства у объекта
        /// </summary>
        public string GetPropertyValue()
        {
            var val = _property.GetValue(_obj, null);

            if (val == null)
                return "";

            if (_propertyType == typeof(DateTime)) return ((DateTime) val).ToString("dd.MM.yyyy");
            if (_propertyType == typeof(DateTime?)) return ((DateTime?) val).Value.ToString("dd.MM.yyyy");
            if (_propertyType == typeof(bool)) return (bool) val ? "1" : "0";
            if (_propertyType == typeof(bool?)) return (bool) val ? "1" : "0";

            return val.ToString();
        }

        /// <summary>
        ///     Установить значение свойства
        /// </summary>
        private void SetPropertyValue(string value)
        {
            var type = _propertyType;
            object newval = null;

            if (type == typeof(string))
            {
                newval = value;
            }
            else if (type == typeof(int) || type == typeof(int?))
            {
                if (value.Length > 0) newval = int.Parse(value, NumberStyles.Any);
            }
            else if (type == typeof(short) || type == typeof(short?))
            {
                if (value.Length > 0) newval = short.Parse(value, NumberStyles.Any);
            }
            else if (type == typeof(Guid))
            {
                newval = value.Length > 0 ? Guid.Parse(value) : Guid.Empty;
            }
            else if (type == typeof(Guid?))
            {
                if (value.Length > 0 && !Guid.Empty.Equals(Guid.Parse(value))) newval = Guid.Parse(value);
            }
            else if (type == typeof(DateTime) || type == typeof(DateTime?))
            {
                if (value.Length > 0) newval = DateTime.ParseExact(value, "dd.MM.yyyy", null);
            }
            else if (type == typeof(bool))
            {
                newval = value.Equals("1");
            }
            else if (type == typeof(bool?) && value.Length > 0)
            {
                newval = value.Equals("1");
            }
            else if (type == typeof(byte))
            {
                newval = byte.Parse(value.Length == 0 ? "0" : value);
            }
            else if (type == typeof(decimal))
            {
                newval = value.Length == 0 ? 0m : decimal.Parse(value);
            }
            else if (type == typeof(decimal?))
            {
                if (value.Length > 0) newval = decimal.Parse(value);
            }
            else
            {
                throw new ArgumentException(
                    "В классе PropertyBinder, передоваемое значение неизвестного типа. Необходимо добавить обработку типа: " +
                    type);
            }

            _property.SetValue(_obj, newval, null);
        }
    }
}