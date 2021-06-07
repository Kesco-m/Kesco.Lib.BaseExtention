using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     расширяющие методы для String
    /// </summary>
    /// <remarks>
    ///     Класс в котором хранится все расширяющие методы для String,
    ///     чтобы было все в одном месте
    /// </remarks>
    public static class StringExtensionMethods
    {
        /// <summary>
        ///     Убирает лишние пробелы слева, справа и внутри строки
        /// </summary>
        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            var text = Regex.Replace(value, @"\s+", " ");
            return text.Trim();
        }

        /// <summary>
        ///     Убирает символы перевода строки
        /// </summary>
        public static string RemoveNewLine(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Replace("\r\n", " ");
        }

        /// <summary>
        ///     Является ли текст только русскими буквами
        /// </summary>
        public static bool IsRussian(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var valueLower = value.ToLower();
                foreach (var c in valueLower)
                {
                    if (char.IsDigit(c) || c >= 'а' && c <= 'я' || c == 'ё')
                        continue;
                    return false;
                }
            }

            return true;


            //if (!string.IsNullOrEmpty(value))
            //{
            //    //return Regex.Match(value, @"\p{IsCyrillic}|\p{IsCyrillicSupplement}").Success;
            // //   var rus = new Regex(@"[А-Яа-яё]");
            ////    var eng = new Regex(@"[A-Za-z]");
            // //   return rus.IsMatch(value) && !eng.IsMatch(value);
            //}
            //return false;
        }

        /// <summary>
        ///     переводит ИВАНОВ ИВАН ИВАНОВИЧ в Иванов Иван Иванович
        /// </summary>
        public static string FirstCharToUpper(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var s = value.Split(' ');
                for (var i = 0; i < s.Length; i++)
                    if (s[i].Length > 1)
                        s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1).ToLower();
                    else
                        s[i] = s[i].ToUpper();

                return string.Join(" ", s);
            }

            return null;
        }

        /// <summary>
        ///     переводит проверка в Проверка
        /// </summary>
        public static string FirstWordCharToUpper(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                switch (value)
                {
                    case null: throw new ArgumentNullException(nameof(value));
                    case "": throw new ArgumentException($"{nameof(value)} cannot be empty", nameof(value));
                    default: return value.First().ToString().ToUpper() + value.Substring(1);
                }
            }
            return null;
        }

        /// <summary>
        ///     Проверяет явлется строка целым числом
        /// </summary>
        /// <remarks>
        ///     Не подходит для дробных чисел
        /// </remarks>
        public static bool IsDigit(this string value)
        {
            return value.All(char.IsDigit);
        }

        /// <summary>
        ///     Делает первый символ строки заглавной буквой
        /// </summary>
        public static string FirstCharOfStringToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        /// <summary>
        ///     Является ли текст только латинскими буквами
        /// </summary>
        public static bool IsLatin(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var valueLower = value.ToLower();
                foreach (var c in valueLower)
                {
                    if (char.IsDigit(c) || c >= 'a' && c <= 'z')
                        continue;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Содержит ли текст латинские буквы
        /// </summary>
        public static bool HaveLatin(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var valueLower = value.ToLower();
                foreach (var c in valueLower)
                    if (c >= 'a' && c <= 'z')
                        return true;
            }

            return false;
        }

        /// <summary>
        ///     Содержит ли текст русские буквы
        /// </summary>
        public static bool HaveRussian(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var valueLower = value.ToLower();
                foreach (var c in valueLower)
                    if (c >= 'а' && c <= 'я' || c == 'ё')
                        return true;
            }

            return false;
        }

        /// <summary>
        ///     Содержит ли текст русские буквы, c указанием на позицию
        /// </summary>
        public static bool HaveRussian(this string value, out char letter, out int position)
        {
            letter = '\0';
            position = 0;
            if (!string.IsNullOrWhiteSpace(value))
            {
                var valueLower = value.ToLower();
                foreach (var c in valueLower)
                {
                    position++;

                    if (c >= 'а' && c <= 'я' || c == 'ё')
                    {
                        letter = c;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     определяет явлется ли строка почтой
        /// </summary>
        public static bool IsEmail(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var match = Regex.Match(input,
                    @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
                return match.Success;
            }

            return false;
        }


        /// <summary>
        ///     Определяет явлется ли строка числом, представляющим 0; 00; 000 и тд
        /// </summary>
        public static bool IsIntegerZero(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                decimal tmp;

                return decimal.TryParse(input, out tmp) && tmp == 0;
            }

            return false;
        }

        /// <summary>
        ///     Определяет явлется ли строка целым  числом, не равным нулю
        /// </summary>
        public static bool IsIntegerNotZero(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                decimal tmp;

                return decimal.TryParse(input, out tmp) && tmp != 0;
            }

            return false;
        }

        /// <summary>
        ///     Определяет, является целым числом
        /// </summary>
        public static bool IsInteger(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            foreach (var c in input)
                if (!char.IsDigit(c))
                    return false;

            return true;
        }

        /// <summary>
        ///     определяет явлется ли стороковое представление датой
        /// </summary>
        public static bool IsDate(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                DateTime dt;
                return DateTime.TryParse(input, out dt);
            }

            return false;
        }

        /// <summary>
        ///     переводит все слова с первыми заглавными буквами
        /// </summary>
        /// <example>
        ///     tHiS is a sTring TesT => This Is A String Test
        /// </example>
        public static string ToProperCase(this string text)
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text);
        }

        /// <summary>
        ///     Конвертирует в int значение, в случае неудачи возращает дефолтное значение для типа int - 0.
        ///     Корректно обрабатывает null, пустые значения и т.д.
        /// </summary>
        public static int ToInt(this string value)
        {
            int integer;

            int.TryParse(value, out integer);

            return integer;
        }

        /// <summary>
        ///     Конвертирует в bool значение, исходя из предположения 1 или "true" - true, 0 или "false" - false
        /// </summary>
        public static bool ToBool(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            switch (value)
            {
                case "1":
                    return true;
                case "true":
                    return true;
                case "0":
                    return false;
                case "false":
                    return false;
            }

            return false;
        }

        /// <summary>
        ///     Конвертация строки в Decimal. Инвариантно относительно разделителя
        /// </summary>
        /// <param name="value">String</param>
        /// <returns>Decimal</returns>
        public static decimal ToDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            var tempValue = (string) value.Clone();
            decimal result;

            if (TryStrToAmount(tempValue, out result))
                return result;

            throw new InvalidCastException("Imput string in incorrect format " + tempValue);
        }

        /// <summary>
        ///     Конвертация строки в Byte[].
        /// </summary>
        /// <param name="value">String</param>
        /// <returns>Decimal</returns>
        public static byte[] ToBytes(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return new byte[0];

            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        ///     Конвертация строки в Decimal
        /// </summary>
        /// <param name="str"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static bool TryStrToAmount(this string str, out decimal amount)
        {
            amount = 0.0M;

            var val = str;
            // Новая метода парсинга числа. Точка как и запятая воспринимается как 
            // разделитель дробной части, если этот же символ не используется как разделитель групп.
            // Учитывается последний в строке символ, остальные вычищаются.
            var decSep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var groupSep = CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator;

            if (groupSep != ".") val = val.Replace(".", "*");

            if (groupSep != ",") val = val.Replace(",", "*");

            var index = val.Trim().LastIndexOf("*", StringComparison.Ordinal);

            if (index != -1 && decSep.Length != 0)
            {
                var array = val.ToCharArray();
                array[index] = decSep[0];
                val = new string(array);
            }

            val = val.Replace("*", "");
            val = val.Replace(" ", "").Trim().ToLower();

            if (string.IsNullOrEmpty(val)) return false;

            var multiplier = 1.0M;

            if (val.EndsWith("k"))
                multiplier = 1000.0M;
            else if (val.EndsWith("m")) multiplier = 1000000.0M;

            var chars = val.ToList();

            chars.RemoveAll(c => !(c == '-' || decSep.Length != 0 && c == decSep[0] || char.IsDigit(c)));

            val = new string(chars.ToArray());


            val = val.Replace(".", ",");

            var format = CultureInfo.GetCultureInfo("ru").NumberFormat;

            amount = decimal.Parse(val, format);

            amount *= multiplier;

            return true;
        }

        /// <summary>
        ///     Trim с проверкой на null. Не выдает ошибки при value == null
        /// </summary>
        public static string TrimNoNullError(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return value.Trim();

            return value;
        }

        /// <summary>
        ///     Убрать из строки запрещенные символы
        ///     Разрешенные символы – символы с десятичными кодами из диапазона [32-126] (кодировки Windows-1251, UTF-8), русские
        ///     буквы из диапазона [А-Я] [а-я] и символ «№».
        /// </summary>
        /// <returns> Строка без запрещенных символов</returns>
        public static string RemoveIllegalSymbolsRus(this string value)
        {
            var result = value;

            if (!string.IsNullOrEmpty(result))
            {
                var sb = new StringBuilder(value.Length, value.Length);

                foreach (var c in value)
                    if (c >= 32 && c <= 126 || c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я' || c == '№' || c == 'ё' ||
                        c == 'Ё')
                        sb.Append(c);

                result = sb.ToString();
            }
            else
            {
                result = value;
            }

            return result;
        }

        /// <summary>
        ///     Является ли строковое значение пустым или равным "0"
        /// </summary>
        public static bool IsNullEmptyOrZero(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            if (value == "0")
                return true;

            return false;
        }

        /// <summary>
        ///     Удалить последний символ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveLastSymbol(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            return value.Substring(0, value.Length - 1);
        }

        /// <summary>
        ///     Определяет, совпадает ли указанное значение с одним из значений.
        ///     Подобен оператору IN(...) в MS SQL
        /// </summary>
        /// <returns> true - содержит</returns>
        public static bool In(this string value, params string[] par)
        {
            if (par == null)
                return false;

            return par.Any(p => p == value);
        }


        /// <summary>
        /// Подобен оператору LIKE в MS SQL
        /// </summary>
        /// <param name="toSearch">Где ищем</param>
        /// <param name="toFind">Что ищем</param>
        /// <param name="replaceStar">Надо ли заменять * на % </param>
        /// <returns></returns>
        public static bool Like(this string toSearch, string toFind, bool replaceStar = false)
        {
            if (!string.IsNullOrEmpty(toFind) && replaceStar)
                toFind = toFind.Replace('*', '%');

            return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(toSearch);
        }
        

        /// <summary>
        ///     Преобразование строки к nullable int
        /// </summary>
        /// <param name="s">строка</param>
        /// <returns>nullable int</returns>
        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        /// <summary>
        ///     Получение слева подстроки указанной длины
        /// </summary>
        /// <param name="value">Исходная строка</param>
        /// <param name="length">Длина</param>
        /// <returns>Подстрока</returns>
        public static string Left(this string value, int length)
        {
            value = value ?? string.Empty;
            return value.Substring(0, Math.Min(length, value.Length));
        }

        /// <summary>
        ///     Получение справа подстроки указнной длины
        /// </summary>
        /// <param name="value">Исходная строка</param>
        /// <param name="length">Длина</param>
        /// <returns>Подстрока</returns>
        public static string Right(this string value, int length)
        {
            value = value ?? string.Empty;
            return value.Length >= length
                ? value.Substring(value.Length - length, length)
                : value;
        }

        /// <summary>
        ///     Nullable object to string
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>string</returns>
        public static string SafeToString(this object obj)
        {
            return (obj ?? "").ToString();
        }
    }
}