using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;

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
                    "$('body').append('<a id=\"{0}\"></a>'); $(\"#{0}\").attr(\"href\", {1}); v4_stopAsyncEvent = true; $('body').append('<div id=\"v4_divReloadWait\" style=\"position:absolute;top:0;left:0;height:100%;width:100%;z-index:99999\"></div>'); $(\"#v4_divReloadWait\").css({{'cursor' : 'wait'}}); v4_evalHref('{0}'); $('#{0}').remove();",
                    id, hrefIsVar ? href : "\"" + href + "\"");
        }

        /// <summary>
        ///     Построитель строки uri
        /// </summary>
        /// <param name="uri">Путь к форме</param>
        /// <param name="qparams">Коллекция параметров</param>
        /// <returns>URI с параметрами</returns>
        public static string UriBuilder(string uri, NameValueCollection qparams)
        {
            var sb = new StringBuilder();

            foreach (string key in qparams)
                sb.AppendFormat("{0}={1}{2}", key, HttpUtility.UrlDecode(qparams[key]), "&");


            if (qparams.Count > 0)
            {
                if (uri.Contains("?")) uri += "&";
                else uri += "?";
            }

            uri += sb.ToString().TrimEnd('&');

            return uri;
        }
    }
}