using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kesco.Lib.BaseExtention
{
    
    /// <summary>
    /// Класс для проверки вхождения IP-адреса в диапазон
    /// </summary>
    public class IPAddressRange
    {
        readonly AddressFamily addressFamily;
        readonly byte[] lowerBytes;
        readonly byte[] upperBytes;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="lowerIP">Начало диапазона</param>
        /// <param name="upperIP">Конец диапазона</param>
        public IPAddressRange(IPAddress lowerIP, IPAddress upperIP)
        {
            this.addressFamily = lowerIP.AddressFamily;
            this.lowerBytes = lowerIP.GetAddressBytes();
            this.upperBytes = upperIP.GetAddressBytes();
        }

        /// <summary>
        /// Проверка вхождения IP-адреса в диапазон
        /// </summary>
        /// <param name="address">IP-адрес</param>
        /// <returns>Входит/не входит</returns>
        public bool IsInRange(IPAddress address)
        {
            if (address.AddressFamily != addressFamily)
            {
                return false;
            }

            byte[] addressBytes = address.GetAddressBytes();

            bool lowerBoundary = true, upperBoundary = true;

            for (int i = 0; i < this.lowerBytes.Length &&
                (lowerBoundary || upperBoundary); i++)
            {
                if ((lowerBoundary && addressBytes[i] < lowerBytes[i]) ||
                    (upperBoundary && addressBytes[i] > upperBytes[i]))
                {
                    return false;
                }

                lowerBoundary &= (addressBytes[i] == lowerBytes[i]);
                upperBoundary &= (addressBytes[i] == upperBytes[i]);
            }

            return true;
        }
    }
}
