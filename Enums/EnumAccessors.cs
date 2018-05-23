﻿using Kesco.Lib.BaseExtention.Enums.Controls;

namespace Kesco.Lib.BaseExtention.Enums
{
    /// <summary>
    /// Полезные функции для работы с enums
    /// </summary>
    public class EnumAccessors
    {
        /// <summary>
        /// Возвращает название Css-класса в зависимости типа нотификации
        /// </summary>
        /// <param name="ntf">Тип нотификации</param>
        /// <returns></returns>
        public static string GetCssClassByNtfStatus(NtfStatus ntf)
        {
            string className;

            switch (ntf)
            {
                case NtfStatus.Error:
                    className = "v4NtfError";
                    break;
                case NtfStatus.Information:
                    className = "v4NtfInformation";
                    break;
                case NtfStatus.Recommended:
                    className = "v4NtfRecommended";
                    break;
                default:
                    className = "";
                    break;
            }
            
            return className;
        }

        /// <summary>
        /// Возвращает цвет текста в зависимости типа нотификации
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