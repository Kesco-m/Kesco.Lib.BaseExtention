using Kesco.Lib.BaseExtention.Enums.Controls;

namespace Kesco.Lib.BaseExtention.Enums
{
    /// <summary>
    ///     Полезные функции для работы с enums
    /// </summary>
    public class EnumAccessors
    {
        /// <summary>
        ///     Возвращает название Css-класса в зависимости типа нотификации
        /// </summary>
        /// <param name="ntf">Тип нотификации</param>
        /// <param name="sizeIsNtf">Размер NTF</param>
        /// <returns></returns>
        public static string GetCssClassByNtfStatus(NtfStatus ntf, bool sizeIsNtf)
        {
            string className;

            switch (ntf)
            {
                case NtfStatus.Error:
                    className = !sizeIsNtf ? "v4Error" : "v4NtfError";
                    break;
                case NtfStatus.Information:
                    className = !sizeIsNtf ? "v4Information" : "v4NtfInformation";
                    break;
                case NtfStatus.Recommended:
                    className = !sizeIsNtf ? "v4Recommended" : "v4NtfRecommended";
                    break;
                case NtfStatus.Empty:
                    className = !sizeIsNtf ? "v4Empty" : "v4NtfEmpty";
                    break;
                default:
                    className = "";
                    break;
            }

            return className;
        }

        /// <summary>
        ///     Возвращает цвет текста в зависимости типа нотификации
        /// </summary>
        /// <param name="ntf">Тип нотификации</param>
        /// <returns></returns>
        public static string GetColorByNtfStatus(NtfStatus ntf)
        {
            string className;

            switch (ntf)
            {
                case NtfStatus.Error:
                    className = "red";
                    break;
                case NtfStatus.Information:
                    className = "gray";
                    break;
                case NtfStatus.Recommended:
                    className = "blue";
                    break;
                default:
                    className = "black";
                    break;
            }

            return className;
        }
    }
}