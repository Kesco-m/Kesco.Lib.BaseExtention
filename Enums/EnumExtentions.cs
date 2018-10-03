using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kesco.Lib.BaseExtention.Enums
{
    /// <summary>
    /// Класс определения дополнительных аттрибутов enums
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Получение аттрибутов enum
        /// </summary>
        /// <typeparam name="TAttribute">Аттрибут</typeparam>
        /// <param name="value">Значение enum</param>
        /// <returns>Аттрибут</returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name) 
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}
