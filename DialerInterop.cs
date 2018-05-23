using System.Web;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс, реализующий функционал для взаимодействия с web-звонилкой
    /// </summary>
    public class DialerInterop
    {
        /// <summary>
        ///     Получить ClientName для функционировании web-звонилки
        /// </summary>
        /// <param name="context">Текущий HTTPContext</param>
        /// <param name="idp">Идентификатор страницы</param>
        /// <returns>Возвращает сгенерированную http-ссылку</returns>
        public static string GetClientName(HttpContext context, string idp)
        {
            var callbackUrl = string.Format("{0}://{1}{2}/dialogResult.ashx?callbackKey={3}",
                context.Request.Url.Scheme,
                context.Request.Url.Authority,
                context.Request.ApplicationPath.TrimEnd('/'),
                idp);

            return WebExtention.DynamicLink(string.Format("KescoRun:GetClientName {0}", callbackUrl), false);
        }
    }
}