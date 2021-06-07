﻿using System;

namespace Kesco.Lib.BaseExtention.Enums.Corporate
{
    /// <summary>
    /// Коды сотрудников
    /// </summary>
    public enum КодыСотрудников
    {

        /// <summary>
        /// Анисимов В.Л.
        /// </summary>
        Анисимов = 1
    }

    /// <summary>
    /// Варианты закрытия дежурства
    /// </summary>
    public enum ВариантыЗакрытияДежурства {
       
        /// <summary>
        /// Невозможно определить
        /// </summary>
        НевозможноОпределить = 0,
        /// <summary>
        /// Дежурил тот кто планировался
        /// </summary>
        ЗамечанийКДежурствуНет = 1,

        /// <summary>
        /// Дежурил другой сотрудник
        /// </summary>
        ДежурилДругойСотрудник = 2,

        /// <summary>
        /// Никто не дежурил
        /// </summary>
        НиктоНеДежурил = 3,

    }

    /// <summary>
    ///     Перечисление типов рабочих мест расположений
    /// </summary>
    public enum ТипыРабочихМест
    {
        /// <summary>
        ///     Компьютеризированное рабочее место
        /// </summary>
        [Specifications.InventoryWorkPlaceType("Notebook.gif", "NotebookGrayed.gif", "ENUM_РабочееМесто_1")]
        КомпьютеризированноеРабочееМесто = 1,

        /// <summary>
        ///     Номер гостиницы
        /// </summary>
        [Specifications.InventoryWorkPlaceType("bed.gif", "bed.gif", "ENUM_РабочееМесто_2")]
        НомерГостиницы = 2,

        /// <summary>
        ///     Оборудование
        /// </summary>
        [Specifications.InventoryWorkPlaceType("service.gif", "service.gif", "ENUM_РабочееМесто_3")]
        Оборудование = 3,

        /// <summary>
        ///     Cклад оборудования
        /// </summary>
        [Specifications.InventoryWorkPlaceType("Store.gif", "Store.gif", "ENUM_РабочееМесто_4")]
        CкладОборудования = 4,

        /// <summary>
        ///     Гостевое рабочее место
        /// </summary>
        [Specifications.InventoryWorkPlaceType("chat.png", "chat.png", "ENUM_РабочееМесто_5")]
        ГостевоеРабочееМесто = 5
    }

    /// <summary>
    ///     Перечисление Сотояния Сотрудника
    /// </summary>
    public enum СотоянияСотрудника
    {
        /// <summary>
        ///     Неважно
        /// </summary>
        Неважно = -1,

        /// <summary>
        ///     Работающие
        /// </summary>
        Работающие = 2,

        /// <summary>
        ///     Работающие и Уволенные
        /// </summary>
        РаботающиеИУволенные = 3,

        /// <summary>
        ///     Все сотрудники
        /// </summary>
        Все = 5
    }

    /// <summary>
    ///     Перечисление Наличие Логина
    /// </summary>
    public enum НаличиеЛогина
    {
        /// <summary>
        ///     Неважно
        /// </summary>
        Неважно = 0,

        /// <summary>
        ///     Есть Логин
        /// </summary>
        ЕстьЛогин = 1,

        /// <summary>
        ///     Нет Логина
        /// </summary>
        НетЛогина = 2
    }

    /// <summary>
    ///     Перечисление Наличие Email
    /// </summary>
    public enum НаличиеEmail
    {
        /// <summary>
        ///     Неважно
        /// </summary>
        Неважно = 0,

        /// <summary>
        ///     Есть EMail
        /// </summary>
        ЕстьEmail = 1,

        /// <summary>
        ///     Нет Email
        /// </summary>
        НетEmail = 2
    }

    /// <summary>
    ///     Перечисление Виртуальный Сотрудник
    /// </summary>
    public enum ВиртуальныйСотрудник
    {
        /// <summary>
        ///     Не важно
        /// </summary>
        Неважно = 0,

        /// <summary>
        ///     Исключить виртуальных сотрудников
        /// </summary>
        ИсключитьВиртуальныхСотрудников = 1
    }

    /// <summary>
    ///     Перечень значений, которые принимает поле Совместитель в таблице Должности
    /// </summary>
    public enum CombineType
    {
        /// <summary>
        ///     Неважно
        /// </summary>
        Неважно = -1,

        /// <summary>
        ///     Основное Место Работы
        /// </summary>
        ОсновноеМестоРаботы = 0,

        /// <summary>
        ///     Совместитель
        /// </summary>
        Совместитель = 1
    }

    /// <summary>
    ///     Роли сотрудника
    /// </summary>
    public enum Role
    {
        /// <summary>
        ///     Имеет полный доступ к лицам в справочнике лиц, проверяет и фиксирует финансово-юридическую информацию о лице
        /// </summary>
        Администратор_Лиц = 11,

        /// <summary>
        ///     Имеет доступ ко всем лицам в справочнике лиц - Будет изменено
        /// </summary>
        Секретарь = 12,

        /// <summary>
        ///     Вносит курсы валют, переносит их в Абакус
        /// </summary>
        Ответственный_за_курсы_валют = 14,

        /// <summary>
        ///     Назначает и администрирует типы ресурсов
        /// </summary>
        Администратор_типов_ресурсов = 15,

        /// <summary>
        ///     Проверяет верность занесения параметров договора и подписывает эл. форму договора.
        /// </summary>
        Администратор_договоров = 17,

        /// <summary>
        ///     Имеет право удалять документы (с изображениями) из архива документов
        /// </summary>
        Администратор_документов = 20,

        /// <summary>
        ///     Обрабатывает (архивирует и рапределяет) все входящие факсы, отправляет исходящие документы по факсу и E-mail
        /// </summary>
        Администратор_факсов = 21,

        /// <summary>
        ///     Имеет право самостоятельно (без администратора факсов) отправлять документы по факсу и E-mail из офиса
        /// </summary>
        Отправитель_документов_из_офиса = 22,

        /// <summary>
        ///     ВРЕМЕННО Имеет доступ ко всем документам в архиве
        /// </summary>
        Наблюдатель_документов = 23,

        /// <summary>
        ///     Видит все сообщения по документам
        /// </summary>
        Наблюдатель_сообщений_по_документам = 24,

        /// <summary>
        ///     Вносит изменения в штатное расписание, информацию о сотрудниках
        /// </summary>
        Кадровик = 31,

        /// <summary>
        ///     Даёт права сотрудникам на получение ключей и выдачу гостевых карточек. Проссматривает отчёты доступа в здание.
        /// </summary>
        Администратор_доступа = 32,

        /// <summary>
        ///     Выдаёт ключи и гостевые карточки. Проссматривает отчёты доступа в здание.
        /// </summary>
        Охранник = 33,

        /// <summary>
        ///     Выдаёт ключи и гостевые карточки.
        /// </summary>
        Охранник_охранного_предприятия = 34,

        /// <summary>
        ///     Управляет выданными ему IP-телефонами через Web
        /// </summary>
        Пользователь_IP_телефона = 40,

        /// <summary>
        ///     Может просматривать детальные данные о телефонных переговорах и трафике web для всех сотрудников,
        /// </summary>
        Наблюдатель_услуг_связи = 41,

        /// <summary>
        ///     Администрирует направления и тарифы телефонной связи
        /// </summary>
        Администратор__тарифов_связи = 42,

        /// <summary>
        ///     Ведёт учёт оборудования в Инвентаризации
        /// </summary>
        Специалист_по_инвентаризации_оборудования = 43,

        /// <summary>
        ///     Ведёт учёт программного обеспечения в Инвентаризации
        /// </summary>
        Специалист_по_инвентаризации_по = 44,

        /// <summary>
        ///     Имеет возможность использовать все номерные ёмкости холдинга
        /// </summary>
        Пользователь_расширенной_телефонной_связи = 45,

        /// <summary>
        ///     Могут использвать функционал автоматического дозвона и напоминаний  автосекретаря телефонного помощника
        /// </summary>
        Пользователи__автосекретаря_телефона = 46,

        /// <summary>
        ///     Просматривает и изменяет данные по хеджированию
        /// </summary>
        Специалист_по_хеджированию = 51,

        /// <summary>
        ///     Просматривает данные по хеджированию
        /// </summary>
        Наблюдатель_хеджирования = 52,

        /// <summary>
        ///     Просматривает и изменяет данные по хеджированию, может отменять заказ
        /// </summary>
        Администратор_хеджирования = 53,

        /// <summary>
        ///     Создают и изменяют доставки
        /// </summary>
        Логисты = 55,

        /// <summary>
        ///     Работает в основном с чертежами Autocad
        /// </summary>
        Проектировщик = 56,

        /// <summary>
        ///     Работает с программой 1С ЖКХ
        /// </summary>
        Специалист_ЖКХ = 59,

        /// <summary>
        ///     Работает с программой 1С Управление отелем
        /// </summary>
        Портье_отеля = 60,

        /// <summary>
        ///     Ведёт учёт в 1С Колос
        /// </summary>
        Специалист_по_учёту_зерна = 61,

        /// <summary>
        ///     Имеет доступ ко всем бухгалтерским проводкам только для просмотра
        /// </summary>
        Аудитор_бухгалтерии = 62,

        /// <summary>
        ///     Работает с кассовыми терминалами ресторана
        /// </summary>
        Кассир__ресторана = 63,

        /// <summary>
        ///     Просматривает данные 1С Управление рестораном
        /// </summary>
        Аудитор_ресторана = 64,

        /// <summary>
        ///     Ведёт учёт в 1С Управление рестораном
        /// </summary>
        Учётчик__ресторана = 65,

        /// <summary>
        ///     Имеет доступ ко всем бухгалтерским проводкам, изменяет книги покупок и продаж
        /// </summary>
        Бухгалтер = 66,

        /// <summary>
        ///     Начисляет зарплату в 1С Зарплата и Управление Персоналом
        /// </summary>
        Бухгалтер_по_зарплате_и_управление_персоналом = 67,

        /// <summary>
        ///     Выполняет роль главного бухгалтера 1С (разрешает ручные проводки, закрывает месяц и т.п.)
        /// </summary>
        Главный_Бухгалтер_1С = 68,

        /// <summary>
        ///     Настраивает связи документов оперативного учёта с документами 1С
        /// </summary>
        Администратор_1С = 69,

        /// <summary>
        ///     Видит результаты консолидации бухгалтерской и финановой отчётности 1С
        /// </summary>
        Аудитор_консолидированной_отчётности = 70,

        /// <summary>
        ///     Видит все финансовые операции по реализации товаров и услуг
        /// </summary>
        Аудитор_реализации = 71,

        /// <summary>
        ///     Вносит и изменяет финансовые операции по реализации товаров и услуг
        /// </summary>
        Финансист_реализации = 72,

        /// <summary>
        ///     Видит все финансовые операции по безналичным платежам
        /// </summary>
        Аудитор_платежей = 73,

        /// <summary>
        ///     Вносит и изменяет финансовые операции по безналичным платежам
        /// </summary>
        Финансист_платежей = 74,

        /// <summary>
        ///     Видит все финансовые операции по кассе
        /// </summary>
        Аудитор_кассы = 75,

        /// <summary>
        ///     Вносит и изменяет финансовые операции по кассе
        /// </summary>
        Финансист_кассы = 76,

        /// <summary>
        ///     Работает с отчётами 1С по данным оперативного учёта
        /// </summary>
        Финансист_оперучёта_1С = 77,

        /// <summary>
        ///     Распределяет входящие сообщения об ошибках и предложениях, формирует заявки
        /// </summary>
        Сотрудник_службы_поддержки_пользователей = 101,

        /// <summary>
        ///     Выполняет регламентные работы по обслуживанию оборудования
        /// </summary>
        Дежурный_инженер = 102,

        /// <summary>
        ///     Исполняет заявки по сообщениям пользователей об ошибках и предложениях в службу поддержки
        /// </summary>
        Исполнитель_заявок_службы_поддержки_пользователей = 103,

        /// <summary>
        ///     Тестирует и ставит подпись под изменениями в компонентах приложений по заяквам службы поддержки
        /// </summary>
        Тестировщик_заявок_службы_поддержки = 104,

        /// <summary>
        ///     Программисты
        /// </summary>
        Программисты = 105,

        /// <summary>
        ///     Aspect user as Admin
        /// </summary>
        Aspect_Admin = 200,

        /// <summary>
        ///     Aspect user as Manager
        /// </summary>
        Aspect_Manager = 201,

        /// <summary>
        ///     Aspect user as Financier
        /// </summary>
        Aspect_Financier = 202,

        /// <summary>
        ///     Aspect user as Economist
        /// </summary>
        Aspect_Economist = 203,

        /// <summary>
        ///     Создает и подтверждает выполнение заявок ЖКХ
        /// </summary>
        Диспетчер_ЖКХ = 300
    }
}