using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс глубокого копирования объекта
    /// </summary>
    //// <see cref="http://www.c-sharpcorner.com/uploadfile/ff2f08/deep-copy-of-object-in-c-sharp/"/>
    //// <seealso cref="http://stackoverflow.com/questions/78536/deep-cloning-objects"/>
    public static class ObjectDeepCloner
    {
        /// <summary>
        ///     Глубокое копирование объекта(включая вложенные объекты)
        /// </summary>
        /// <remarks>
        ///     Чтобы класс клонировался быстро(через сериализацию) необходимо все классы(основной, вложенные и используемые)
        ///     пометить атрибутом [Serializable]
        ///     Если хотябы один вложенный объект не поддерживает сериализацию, то выведится исключение
        /// </remarks>
        public static T DeepClone<T>(T source)
        {
            // Нельзя сериализовать нулевой объект, вернем объект по умолчанию
            if (ReferenceEquals(source, null)) return default(T);

            if (typeof(T).IsSerializable) return CloneBySerializing(source);

            return CloneByReflection(source);
        }


        /// <summary>
        ///     Клонировние используя сериализацию/десереализацию
        /// </summary>
        /// <remarks>Работает в разы быстрее чем через Reflection</remarks>
        private static T CloneBySerializing<T>(T objSource)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(stream, objSource);

                stream.Position = 0;

                return (T) formatter.Deserialize(stream);
            }
        }

        /// <summary>
        ///     Клонировние используя Reflection
        /// </summary>
        /// <remarks>Проходит всей иерархии объекта рекурсивно, с помощью рефлексии</remarks>
        private static T CloneByReflection<T>(T objSource)
        {
            // шаг: 1 Получить тип исходного объекта и создать новый экземпляр этого типа
            var typeSource = objSource.GetType();

            var objTarget = Activator.CreateInstance(typeSource);

            // Шаг 2: получить все свойства типа исходного объекта
            var propertyInfo =
                typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // Шаг: 3 Назначает все свойства source для свойств объекта taget.
            foreach (var property in propertyInfo)
                // Проверяем, может ли свойство быть записано
                if (property.CanWrite)
                {
                    // Шаг: 4 проверить, является ли тип свойства типом значения, перечислением или строковым типом
                    if (property.PropertyType.IsValueType || property.PropertyType.IsEnum ||
                        property.PropertyType == typeof(string))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }

                    // else тип свойства - тип объекта / комплекса, поэтому нужно рекурсивно вызывать этот метод до тех пор, пока не будет достигнут конец дерева
                    else
                    {
                        var objPropertyValue = property.GetValue(objSource, null);

                        if (objPropertyValue == null)
                            property.SetValue(objTarget, null, null);

                        else
                            property.SetValue(objTarget, CloneByReflection(objPropertyValue), null);
                    }
                }

            return (T) objTarget;
        }
    }
}