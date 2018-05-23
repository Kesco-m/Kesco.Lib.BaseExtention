using System;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс расширений для WEB-приложениф
    /// </summary>
    public class WebExtention
    {
        /// <summary>
        ///     Генерация динамической ссылки
        /// </summary>
        /// <param name="href">URI, на который надо перейти</param>
        /// <param name="hrefIsVar">URI передано в ковычках, по-умолчанию true</param>
        /// <returns></returns>
        public static string DynamicLink(string href, bool hrefIsVar = true)
        {
            var id = Guid.NewGuid();
            return
                string.Format(
                    "$('body').append('<a id=\"{0}\"></a>'); $(\"#{0}\").attr(\"href\", {1}); v4_evalHref('{0}'); $('#{0}').remove();",
                    id, hrefIsVar ? href : "\"" + href + "\"");
        }
    }
}