using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kesco.Lib.BaseExtention.Enums
{
    /// <summary>
    /// Расширения(аттрибуты) для перечеслений
    /// </summary>
    public class Specifications
    {
        /// <summary>
        ///     Аттрибут: названия вилов указаний ИТ
        /// </summary>
        public class DirectionsType : Attribute
        {
            internal DirectionsType(string radioLabel, string documentName, string documentTitle)
            {
                RadioLabel = radioLabel;
                DocumentName = documentName;
                DocumentTitle = documentTitle;
            }

            /// <summary>
            ///     Название радио-элемента
            /// </summary>
            public string RadioLabel { get; }

            /// <summary>
            ///     Название документа
            /// </summary>
            public string DocumentName { get; }

            /// <summary>
            ///     Заголовок документа
            /// </summary>
            public string DocumentTitle { get; }
        }

        /// <summary>
        ///     Аттрибут: иконки в зависимости от типа рабочего места
        /// </summary>
        public class InventoryWorkPlaceType : Attribute
        {
            internal InventoryWorkPlaceType(string icon, string iconGrayed, string name)
            {
                Icon = icon;
                IconGrayed = iconGrayed;
                Name = name;
            }

            /// <summary>
            ///     Иконка
            /// </summary>
            public string Icon { get; }

            /// <summary>
            ///     Иконка не готового рабочего места
            /// </summary>
            public string IconGrayed { get; }

            /// <summary>
            ///     Название типа рабочего места
            /// </summary>
            public string Name { get; }
        }
    }
}
