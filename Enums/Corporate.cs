using System;

namespace Kesco.Lib.BaseExtention.Enums.Corporate
{
    /// <summary>
    /// Аттрибут: иконки в зависимости от типа рабочего места
    /// </summary>
    public class ТипыРабочихМестSpecifications : Attribute
    {
        internal ТипыРабочихМестSpecifications(string icon, string iconGrayed, string name, string nameGrayed)
        {
            Icon = icon;
            IconGrayed = iconGrayed;
            Name = name;
            NameGrayed = nameGrayed;
        }
        /// <summary>
        /// Иконка
        /// </summary>
        public string Icon { get; private set; }
        /// <summary>
        /// Иконка не готового рабочего места
        /// </summary>
        public string IconGrayed { get; private set; }
        /// <summary>
        /// Название типа рабочего места
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Название типа рабочего места
        /// </summary>
        public string NameGrayed { get; private set; }
      
    }

    /// <summary>
    ///     Перечисление типов рабочих мест расположений
    /// </summary>
    public enum ТипыРабочихМест
    {
        /// <summary>
        ///     Компьютеризированное рабочее место
        /// </summary>
        [ТипыРабочихМестSpecifications("Notebook.gif", "NotebookGrayed.gif", "Компьютеризированное рабочее место", "Компьютеризированное рабочее место - не организовано")]
        КомпьютеризированноеРабочееМесто = 1,

        /// <summary>
        ///     Номер гостиницы
        /// </summary>
        [ТипыРабочихМестSpecifications("bed.gif", "bed.gif", "Номер гостиницы", "Номер гостиницы")]
        НомерГостиницы = 2,

        /// <summary>
        ///     Оборудование
        /// </summary>
        [ТипыРабочихМестSpecifications("service.gif", "service.gif", "В расположении может находиться оборудование", "В расположении может находиться оборудование")]
        Оборудование = 3,

        /// <summary>
        ///     Cклад оборудования
        /// </summary>
        [ТипыРабочихМестSpecifications("Store.gif", "Store.gif", "Cклад оборудования", "Cклад оборудования")]
        CкладОборудования = 4,

        /// <summary>
        ///     Гостевое рабочее место
        /// </summary>
        [ТипыРабочихМестSpecifications("chat.png", "chat.png", "Гостевое рабочее место, посменная работа", "Гостевое рабочее место, посменная работа")]
        ГостевоеРабочееМесто = 5
    }
    
    /// <summary>
    /// Перечисление Сотояния Сотрудника
    /// </summary>
    public enum СотоянияСотрудника
    {
        /// <summary>
        /// Неважно
        /// </summary>
        Неважно = -1,
        /// <summary>
        /// Работающие
        /// </summary>
        Работающие = 2,
        /// <summary>
        /// Работающие и Уволенные
        /// </summary>
        РаботающиеИУволенные = 3,
        /// <summary>
        /// Все сотрудники
        /// </summary>
        Все = 5
    }

    /// <summary>
    /// Перечисление Наличие Логина
    /// </summary>
    public enum НаличиеЛогина
    {
        /// <summary>
        /// Неважно
        /// </summary>
        Неважно = 0,
        /// <summary>
        /// Есть Логин
        /// </summary>
        ЕстьЛогин = 1,
        /// <summary>
        /// Нет Логина
        /// </summary>
        НетЛогина = 2
    }

    /// <summary>
    /// Перечисление Наличие Email
    /// </summary>
    public enum НаличиеEmail
    {
        /// <summary>
        /// Неважно
        /// </summary>
        Неважно = 0,
        /// <summary>
        /// Есть EMail
        /// </summary>
        ЕстьEmail = 1,
        /// <summary>
        /// Нет Email
        /// </summary>
        НетEmail = 2
    }

    /// <summary>
    /// Перечисление Виртуальный Сотрудник
    /// </summary>
    public enum ВиртуальныйСотрудник
    {
        /// <summary>
        /// Не важно
        /// </summary>
        Неважно = 0,
        /// <summary>
        /// Исключить виртуальных сотрудников
        /// </summary>
        ИсключитьВиртуальныхСотрудников = 1
    }

    /// <summary>
    /// Перечень значений, которые принимает поле Совместитель в таблице Должности
    /// </summary>
    public enum CombineType
    {
        /// <summary>
        /// Неважно
        /// </summary>
        Неважно = -1,
        /// <summary>
        /// Основное Место Работы
        /// </summary>
        ОсновноеМестоРаботы = 0,
        /// <summary>
        /// Совместитель
        /// </summary>
        Совместитель = 1
    }
}
