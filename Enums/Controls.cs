namespace Kesco.Lib.BaseExtention.Enums.Controls
{
    /// <summary>
    /// Переченинь иконок для стандартных кнопок
    /// </summary>
    public sealed class ButtonIconsEnum
    {
        /// <summary>
        /// Иконка для кнопки Добавить
        /// </summary>
        public const string Add = "v4_buttonIcons.Add";

        /// <summary>
        /// Иконка для кнопки Добавить
        /// </summary>
        public const string Edit = "v4_buttonIcons.Edit";

        /// <summary>
        /// Иконка для кнопки ОК
        /// </summary>
        public const string Ok = "v4_buttonIcons.Ok";
        /// <summary>
        /// Иконка для кнопки Сохранить
        /// </summary>
        public const string Save = "v4_buttonIcons.Save";
        /// <summary>
        /// Иконка для кнопки Отмена
        /// </summary>
        public const string Cancel = "v4_buttonIcons.Cancel";
        /// <summary>
        /// Иконка для кнопки Обновить
        /// </summary>
        public const string Refresh = "v4_buttonIcons.Refresh";
        /// <summary>
        /// Иконка для кнопки Закрыть
        /// </summary>
        public const string Close = "v4_buttonIcons.Close";
        /// <summary>
        /// Иконка для кнопки Копировать
        /// </summary>
        public const string Copy = "v4_buttonIcons.Copy";
        /// <summary>
        /// Иконка для кнопки Удалить
        /// </summary>
        public const string Delete = "v4_buttonIcons.Delete";

        /// <summary>
        /// Иконка для кнопки Справка
        /// </summary>
        public const string Help = "v4_buttonIcons.Help";

        /// <summary>
        /// Иконка для кнопки Alert
        /// </summary>
        public const string Alert = "v4_buttonIcons.Alert";

        /// <summary>
        /// Иконка для кнопки Alert
        /// </summary>
        public const string FolderOpen = "v4_buttonIcons.FolderOpen";

        /// <summary>
        /// Иконка для кнопки Alert
        /// </summary>
        public const string Print = "v4_buttonIcons.Print";

        /// <summary>
        /// Иконка для кнопки Search
        /// </summary>
        public const string Search = "v4_buttonIcons.Search";

        /// <summary>
        /// Иконка для кнопки Swap
        /// </summary>
        public const string Swap = "v4_buttonIcons.Swap";

    }

    /// <summary>
    /// Как искать переданные значения
    /// </summary>
    public enum SearchIds
    {
        /// <summary>
        /// включая
        /// </summary>
        In = 0,
        /// <summary>
        /// не включая
        /// </summary>
        NotIn = 1   
    }
    /// <summary>
    /// Статус пользовательского сообщения
    /// </summary>
    public enum MessageStatus
    {
        /// <summary>
        /// Информация
        /// </summary>
        Information = 1,
        /// <summary>
        /// Предупреждение
        /// </summary>
        Warning = 2,
        /// <summary>
        ///Ошибка
        /// </summary>
        Error = 3,
        /// <summary>
        /// Внимание
        /// </summary>
        Attention = 4,
        /// <summary>
        /// Подтверждение
        /// </summary>
        Confirmation = 5

    }

    /// <summary>
    /// Перечислитель статусов нотификации
    /// </summary>
    public enum NtfStatus
    {
        /// <summary>
        /// Пустое
        /// </summary>
        Empty = 0,
        /// <summary>
        /// Информационное
        /// </summary>
        Information = 1,
        /// <summary>
        /// Рекоммендационное
        /// </summary>
        Recommended = 2,
        /// <summary>
        /// Ошибка
        /// </summary>
        Error = 3
    }

    /// <summary>
    /// Перечислитель направления чтения/записи
    /// </summary>
    public enum BindingDirection
    {
        /// <summary>
        /// запись
        /// </summary>
        ToSource = 0,
        /// <summary>
        /// чтение
        /// </summary>
        FromSource = 1
    }

    /// <summary>
    /// Тип значения, чьи контакты отображаются в контроле
    /// </summary>
    public enum CallerTypeEnum
    {
        /// <summary>
        /// Не указан
        /// </summary>
        Empty = 0,

        /// <summary>
        /// Непосредственный звонок
        /// </summary>
        Contact = 1,

        /// <summary>
        /// В приложение контакты будет передан КодСотрудника
        /// </summary>
        Employee = 2,

        /// <summary>
        /// В приложение контакты будет передан КодЛица
        /// </summary>
        Person = 3
    }

    /// <summary>
    /// Перечисление условий для даты
    /// </summary>
    public enum DatePickerEnum
    {
        /// <summary>
        /// Точно совпадает
        /// </summary>
        Equal = 0,
        /// <summary>
        /// Меньше или равна
        /// </summary>
        LessOrEqual = 1,
        /// <summary>
        /// Больше или равна
        /// </summary>
        MoreOrEqual = 2,
        /// <summary>
        /// Находится в интервале
        /// </summary>
        Interval = 3,
        /// <summary>
        /// Любое значение
        /// </summary>
        Any = 4,
        /// <summary>
        /// Не указана
        /// </summary>
        Null = 5
    }

    /// <summary>
    /// Перечисление типов действий для меню
    /// </summary>
    public enum MenuButtonActionType
    {
        /// <summary>
        /// ссылка
        /// </summary>
        UrlAction = 0,
        /// <summary>
        /// действие
        /// </summary>
        CmdAction = 1,
        /// <summary>
        /// javaScript
        /// </summary>
        JSAction = 2,
        /// <summary>
        /// нет действий
        /// </summary>
        None = 3
    }

    /// <summary>
    /// Перечисление условий для числового поля
    /// </summary>
    public enum NumbersEnum
    {
        /// <summary>
        /// Равно
        /// </summary>
        Equally = 0,
        /// <summary>
        /// Больше
        /// </summary>
        More = 1,
        /// <summary>
        /// Меньше
        /// </summary>
        Less = 2,
        /// <summary>
        /// Больше или равно
        /// </summary>
        MoreOrEqual = 3,
        /// <summary>
        /// Меньше или равно
        /// </summary>
        LessOrEqual = 4,
        /// <summary>
        /// Не равно
        /// </summary>
        NotEqual = 5,
        /// <summary>
        /// Интервал
        /// </summary>
        Interval = 6,
        /// <summary>
        /// Любое значение
        /// </summary>
        Any = 7,
        /// <summary>
        /// Значение не указано
        /// </summary>
        NoValue = 8
    }

    /// <summary>
    /// Перечисление периодов
    /// </summary>
    public enum PeriodsEnum
    {
        /// <summary>
        /// Неопределено
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// День
        /// </summary>
        Day = 1,
        /// <summary>
        /// Неделя
        /// </summary>
        Week = 2,
        /// <summary>
        /// Месяц
        /// </summary>
        Mounth = 3,
        /// <summary>
        /// Квартал
        /// </summary>
        Quarter = 4,
        /// <summary>
        /// Год
        /// </summary>
        Year = 5,
        /// <summary>
        /// Произвольно
        /// </summary>
        Custom = 6
    }

    /// <summary>
    /// Перечисление условий для Select
    /// </summary>
    public enum SelectEnum
    {
        /// <summary>
        /// Элементы из списка
        /// </summary>
        Contain = 0,

        /// <summary>
        /// Элементы за исключением
        /// </summary>
        NotContain = 1,

        /// <summary>
        /// Любое значение
        /// </summary>
        Any = 2,

        /// <summary>
        /// Значение не указано
        /// </summary>
        NoValue = 3
    }


    /// <summary>
    /// Перечисление типов текстового поля
    /// </summary>
    public enum TextBoxType
    {
        /// <summary>
        /// Текст
        /// </summary>
        Text = 1,
        /// <summary>
        /// Пароль
        /// </summary>
        Password = 2,
        /// <summary>
        /// Электронная почта
        /// </summary>
        Email = 3,
        /// <summary>
        /// Телефон
        /// </summary>
        Phone = 4
    };

    /// <summary>
    /// Перечисление условий для текстового поля
    /// </summary>
    public enum TextBoxEnum
    {
        /// <summary>
        /// Содержит все слова
        /// </summary>
        ContainsAll = 0,
        /// <summary>
        /// Не содержит какого-либо слова
        /// </summary>
        NotContainsAny = 1,
        /// <summary>
        /// Содержит все слова в заданном порядке
        /// </summary>
        ContainsAllOrdered = 2,
        /// <summary>
        /// Не содержит слов в заданном порядке
        /// </summary>
        NotContainsAllOrdered = 3,
        /// <summary>
        ///  Содержит какое-либо слово
        /// </summary>
        ContainsAny = 4,
        /// <summary>
        /// Не содержит ни одного слова
        /// </summary>
        NotContainsAll = 5,
        /// <summary>
        /// Слова начинаются
        /// </summary>
        Starts = 6,
        /// <summary>
        /// Слова не начинаются
        /// </summary>
        NotStart = 7,
        /// <summary>
        /// Слова заканчиваются
        /// </summary>
        Ends = 8,
        /// <summary>
        /// Слова не заканчиваются
        /// </summary>
        NotEnds = 9,
        /// <summary>
        /// Полностью совпадает
        /// </summary>
        Matches = 10,
        /// <summary>
        /// Полностью не совпадает
        /// </summary>
        NotMatches = 11,
        /// <summary>
        /// Пустая строка
        /// </summary>
        Empty = 12,
        /// <summary>
        /// Не пустая строка
        /// </summary>
        NotEmpty = 13
    }

    /// <summary>
    ///  Перечисление способ задания даты
    /// </summary>
    public enum DateSearchType
    {
        /// <summary>
        ///  равен перичисленным документам
        /// </summary>
        Equals = 0,

        /// <summary>
        ///  Больше или равно даты
        /// </summary>
        MoreThan = 1,

        /// <summary>
        /// Меньше даты
        /// </summary>
        LessThan = 2
    }

    /// <summary>
    /// Стратегия поиска ресурсов
    /// </summary>
    public enum SearchResources
    {
        /// <summary>
        /// Стратегия не задана
        /// </summary>
        None = 0,
        /// <summary>
        /// Будут искаться ресурсы, характерные только заданным лицам
        /// </summary>
        SearchResOnlyForSpecifiedPersons = 1,
        /// <summary>
        /// Будут искаться все ресурсы, характерные заданным лицам
        /// </summary>
        SearchAllResForPersons = 2
    }

    /// <summary>
    /// Типы запросов к таблицам древовидной структуры
    /// </summary>
    public enum TreeQueryType
    {
        /// <summary>
        /// Тип запроса: все подчиненные элементы включая родителя
        /// </summary>
        AllChildrenWithParent = 1,

        /// <summary>
        /// Тип запроса: все подчиненные элементы исключая родителя
        /// </summary>
        AllChildrenWithoutParent = 2,

        /// <summary>
        /// Тип запроса: непосредственные подчиненные элементы включая родителя
        /// </summary>
        ChildrenWithParent = 3,

        /// <summary>
        /// Тип запроса: непосредственные подчиненные элементы
        /// </summary>
        ChildrenWithoutParent = 4
    }
}
