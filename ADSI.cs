using System.DirectoryServices;

namespace Kesco.Lib.BaseExtention
{
    /// <summary>
    ///     Класс, содержащий функции для работы с AD
    /// </summary>
    public class ADSI
    {
        /// <summary>
        ///     Поиск учетных записей в АД по email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>DirectorySearcher с результатами поиска</returns>
        public static SearchResult FindAccountByEmail(string email)
        {
            var filter = string.Format("(proxyaddresses=SMTP:{0})", email);

            using (var gc = new DirectoryEntry("GC:"))
            {
                foreach (DirectoryEntry z in gc.Children)
                {
                    using (var root = z)
                    {
                        using (
                            var searcher = new DirectorySearcher(root, filter,
                                new[] {"proxyAddresses", "objectGuid", "displayName", "distinguishedName"}))
                        {
                            searcher.ReferralChasing = ReferralChasingOption.All;
                            var result = searcher.FindOne();

                            return result;
                        }
                    }
                    break;
                }
            }

            return null;
        }
    }
}