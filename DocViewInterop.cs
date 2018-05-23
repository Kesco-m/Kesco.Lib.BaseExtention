using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    /// Класс, реализующий функционал для взаимодействия с Архивом документов
    /// </summary>
    public class DocViewInterop
    {
        private const string GroupSeparator = "%20";
        private const string ValueSeparator = "%20";
        private const string EscapeEqual = "%3D";

        private const string EscapeXmlSpace = "&#32;";
        private const string EscapeXmlQuot = "&#34;";
        private const string EscapeXmlApos = "&#39;";
        private const string EscapeXmlAmp = "&#38;";
        private const string EscapeXmlLt = "&#60;";
        private const string EscapeXmlGt = "&#62;";
        
        /// <summary>
        /// Открытие документа в Архиве документов по коду документа
        /// </summary>
        /// <param name="id">КодДокумента</param>
        /// <param name="openImage">true-если необходимо открыть документ на основном изображении, при его наличии; false-открыть документа на электронной форме</param>
        /// <param name="replicate">true-реплицировать изображения, если оно отсутствует в локальном архиве; false - не реплицировать</param>
        /// <returns>Возвращает сгенерированную http-ссылку</returns>
        public static string OpenDocument(string id, bool openImage = true, bool replicate = false)
        {
            if (string.IsNullOrEmpty(id))
                throw new Kesco.Lib.Log.LogicalException("Ошибка вызова метода OpenDocument", "Не указан код документа",
                    System.Reflection.Assembly.GetExecutingAssembly().GetName());

            return
                WebExtention.DynamicLink(
                    string.Format(
                        "KescoRun:Docview{0}<OPENDOC{0}id{1}'{2}'{0}newwindow{1}'1'{0}imageid{1}'{3}'{0}replicate{1}'{4}'/>",
                        ValueSeparator,
                        EscapeEqual,
                        id,
                        openImage ? -2 : 0,
                        replicate ? "true" : "false"), false);
        }

        /// <summary>
        /// Открыть в Архиве документов форму поиска
        /// </summary>
        /// <param name="context">Текущий HTTPContext</param>
        /// <param name="htmlId">Идентификатор контрола, в который необходимо подствить значение</param>
        /// <param name="paramTypes">Ограничение по типам документов</param>
        /// <param name="paramPersons">Ограничение по кодам лиц</param>
        /// <param name="paramSearch">Строка поиска</param>
        /// <returns>Возвращает сгенерированную http-ссылку</returns>
        public static string SearchDocument(HttpContext context, string htmlId, string paramTypes, string paramPersons, string paramSearch)
        {
            var callbackUrl = context.Request.Url.Scheme + "://" +
                                 context.Request.Url.Authority +
                                 context.Request.ApplicationPath.TrimEnd('/') + "/dialogResult.ashx";

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" var paramSearch = \"KescoRun:Docview\";");
            sb.AppendFormat(" paramSearch += \"{0}<SEARCH\";", ValueSeparator);
            sb.AppendFormat(" paramSearch += \"{0}control{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, HttpUtility.JavaScriptStringEncode(htmlId));
            sb.AppendFormat(" paramSearch += \"{0}callbackKey{1}'\" + escape(idp) + \"'\";", ValueSeparator, EscapeEqual);
            sb.AppendFormat(" paramSearch += \"{0}callbackUrl{1}'\" + escape('{2}')+ \"'\";", ValueSeparator, EscapeEqual, HttpUtility.JavaScriptStringEncode(callbackUrl));
            sb.AppendFormat(" paramSearch += \"{0}tray{1}'1'\";", ValueSeparator, EscapeEqual);

            if (!string.IsNullOrEmpty(paramTypes))
                sb.AppendFormat(" paramSearch += \"{0}types{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, HttpUtility.JavaScriptStringEncode(paramTypes));
            if (!string.IsNullOrEmpty(paramPersons))
                sb.AppendFormat(" paramSearch += \"{0}persons{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, HttpUtility.JavaScriptStringEncode(paramPersons));
            if (!string.IsNullOrEmpty(paramSearch))
            {
                paramSearch =
                    paramSearch
                        .Replace("&", EscapeXmlAmp)
                        .Replace(" ", EscapeXmlSpace)
                        .Replace("\"", EscapeXmlQuot)
                        .Replace("'", EscapeXmlApos)
                        .Replace("<", EscapeXmlLt)
                        .Replace(">", EscapeXmlGt);

                sb.AppendFormat(" paramSearch += \"{0}search{1}'\" + escape('{2}') + \"'\";",
                    ValueSeparator,
                    EscapeEqual,
                    HttpUtility.JavaScriptStringEncode(paramSearch));
            }
            sb.AppendFormat(" paramSearch += \"/>\";");
            sb.Append(WebExtention.DynamicLink("paramSearch"));
            return sb.ToString();

        }

        /// <summary>
        /// Открыть в Архиве документов форму отправки сообщения по документу
        /// </summary>
        /// <param name="id">Код документа</param>
        /// <param name="empids">Список сотрудников через ",", которым должно быть отправлено сообщение</param>
        /// <param name="message">Текст сообщения</param>
        /// <param name="openDocument">Вместе с формой отправки открыть и сам документ</param>
        /// <returns>Возвращает сгенерированную http-ссылку</returns>
        public static string SendMessageDocument(string id, string empids, string message, bool openDocument = true)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat(" var paramSend = \"KescoRun:Docview\";");
            sb.AppendFormat(" paramSend += \"{0}<SENDMESSAGE\";", ValueSeparator);
            sb.AppendFormat(" paramSend += \"{0}id{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, id);
            sb.AppendFormat(" paramSend += \"{0}opendoc{1}'{2}'\";", ValueSeparator, EscapeEqual, openDocument ? 1 : 0);
            sb.AppendFormat(" paramSend += \"{0}empids{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, empids);
            if (!string.IsNullOrEmpty(message))
            {
                message =
                    message
                        .Replace("&", EscapeXmlAmp)
                        .Replace(" ", EscapeXmlSpace)
                        .Replace("\"", EscapeXmlQuot)
                        .Replace("'", EscapeXmlApos)
                        .Replace("<", EscapeXmlLt)
                        .Replace(">", EscapeXmlGt);

                sb.AppendFormat(" paramSend += \"{0}message{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, HttpUtility.JavaScriptStringEncode(message));
            }

            sb.AppendFormat(" paramSend += \"{0}checkall{1}'1'\";", ValueSeparator, EscapeEqual);
            sb.AppendFormat(" paramSend += \"/>\";");

            sb.Append(WebExtention.DynamicLink("paramSend"));
            
            return sb.ToString();
        }

        /// <summary>
        /// Открыть в Архиве документоа форму поиска похожих документов
        /// </summary>
        /// <param name="context">Текущий HTTPContext</param>
        /// <param name="id">Код документа</param>
        /// <param name="typeId">Код типа документа</param>
        /// <param name="date">Дата документа</param>
        /// <param name="number">Номер документа</param>
        /// <param name="personIds">Коды лиц документа</param>
        /// <param name="usePersonIds">Условие похожести</param>
        /// <returns>Возвращает сгенерированную http-ссылку</returns>
        public static string CheckSimilarDocument(HttpContext context, string id, string typeId, string date, string number, string personIds, string usePersonIds)
        {
            var callbackUrl = context.Request.Url.Scheme + "://" +
                     context.Request.Url.Authority +
                     context.Request.ApplicationPath.TrimEnd('/') + "/dialogResult.ashx";

            StringBuilder sb = new StringBuilder();

            if (usePersonIds.Length == 0) usePersonIds = "0";
            sb.AppendFormat(" var paramCheck = \"KescoRun:Docview\";");
            sb.AppendFormat(" paramCheck += \"{0}<CHECKSIMILAR\";", ValueSeparator);
            sb.AppendFormat(" paramCheck += \"{0}control{1}'\" + escape(idp) + \"'\";", ValueSeparator, EscapeEqual);
            sb.AppendFormat(" paramCheck += \"{0}callbackKey{1}'\" + escape(idp) + \"'\";", ValueSeparator, EscapeEqual);
            sb.AppendFormat(" paramCheck += \"{0}callbackUrl{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, HttpUtility.JavaScriptStringEncode(callbackUrl));
            sb.AppendFormat(" paramCheck += \"{0}id{1}'{2}'\";", ValueSeparator, EscapeEqual, string.IsNullOrEmpty(id) ? "0" : id);
            sb.AppendFormat(" paramCheck += \"{0}type{1}'{2}'\";", ValueSeparator, EscapeEqual, typeId);
            sb.AppendFormat(" paramCheck += \"{0}date{1}'{2}'\";", ValueSeparator, EscapeEqual, date);
            sb.AppendFormat(" paramCheck += \"{0}number{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, number);
            sb.AppendFormat(" paramCheck += \"{0}personids{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, personIds);
            sb.AppendFormat(" paramCheck += \"{0}usepersonids{1}'\" + escape('{2}') + \"'\";", ValueSeparator, EscapeEqual, usePersonIds);
            sb.AppendFormat(" paramCheck += \"/>\";");

            sb.Append(WebExtention.DynamicLink("paramCheck"));
            return sb.ToString();
        }

    }
}
