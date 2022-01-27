using Newtonsoft.Json;
using System;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class ProxyInfo
    {
        /// <summary>
        /// Proxy, Socks 4, Socks 5  -- Do not change, it is fixed!
        /// </summary>
        public ProxyType Type { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Raw string can be: IP:Port or IP:Port:User:Pass
        /// </summary>
        /// <param name="proxyRawString"></param>
        /// <returns></returns>
        public ProxyInfo(string proxyString)
        {
            // Default (some times, app can be dis because Host is null)
            this.Host = "No";
            this.Type = ProxyType.HttpProxy;
            string proxyRawString = proxyString;

            if (string.IsNullOrEmpty(proxyRawString))
                return;

            string prefix = "";
            if (proxyRawString.IndexOf("socks5://") == 0)
            {
                prefix = "socks5://";
                this.Type = ProxyType.Socks5;
                proxyRawString = proxyRawString.Replace(prefix, "");
            }
            if (proxyRawString.IndexOf("socks://") == 0)
            {
                prefix = "socks://";
                this.Type = ProxyType.Socks4;
                proxyRawString = proxyRawString.Replace(prefix, "");
            }

            string[] spliter = proxyRawString.Split(':');
            if (spliter.Length == 2)
            {
                this.Host = spliter[0];
                int port = 80;
                int.TryParse(spliter[1], out port);
                this.Port = port;
            }
            else if (spliter.Length == 4)
            {
                this.Host = spliter[0];
                int port = 80;
                int.TryParse(spliter[1], out port);
                this.Port = port;
                this.UserName = spliter[2];
                this.Password = spliter[3];
            }
        }
        public IPInfo GetIPInfo()
        {
            try
            {
                IPInfo info = new IPInfo();

                xNet.HttpRequest request = new xNet.HttpRequest();

                if (this.Type == ProxyType.HttpProxy)
                {
                    if (string.IsNullOrEmpty(UserName)) request.Proxy = new xNet.HttpProxyClient(Host, Port);
                    else request.Proxy = new xNet.HttpProxyClient(Host, Port, UserName, Password);
                }
                else if (this.Type == ProxyType.Socks5)
                {
                    if (string.IsNullOrEmpty(UserName)) request.Proxy = new xNet.Socks5ProxyClient(Host, Port);
                    else request.Proxy = new xNet.Socks5ProxyClient(Host, Port, UserName, Password);
                }
                else if (this.Type == ProxyType.Socks4)
                {
                    if (string.IsNullOrEmpty(UserName)) request.Proxy = new xNet.Socks4ProxyClient(Host, Port);
                    else request.Proxy = new xNet.Socks4ProxyClient(Host, Port, UserName);
                }

                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.93 Safari/537.36";
                request.AddHeader(xNet.HttpHeader.Accept, "application/json");
                
                string html = request.Get("http://ip-api.com/json").ToString();
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(html);
                info.IP = Convert.ToString(obj.query);
                info.Country = Convert.ToString(obj.country);
                info.Region = Convert.ToString(obj.region);
                info.City = Convert.ToString(obj.city);
                info.Timezone = Convert.ToString(obj.timezone);

                return info;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Raw string can be: IP:Port or IP:Port:User:Pass
        /// </summary>
        /// <param name="proxyRawString"></param>
        /// <returns></returns>
        public static bool CanParse(string proxyRawString)
        {
            if (string.IsNullOrEmpty(proxyRawString))
                return true;

            string proxy = proxyRawString.Replace("socks5://", "").Replace("socks://", "");

            string[] spliter = proxy.Split(':');
            return (spliter.Length == 2 || spliter.Length == 4);
        }
    }
}
