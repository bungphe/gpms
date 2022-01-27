using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class ProxyAuth
    {
        [JsonProperty("proxyConnection")]
        public string ProxyConnection { get; private set; } = "";
        [JsonProperty("autoAuth")]
        public bool AutoAuth { get; set; } = false;
        [JsonProperty("username")]
        public string Username { get; set; } = "";
        [JsonProperty("password")]
        public string Password { get; set; } = "";
        public string RawProxy
        {
            get => $"{ProxyConnection}";//{(!string.IsNullOrEmpty(Username) ? $":{Username}" : "" )}{(!string.IsNullOrEmpty(Password) ? $":{Password}" : "")}";
            set
            {
                try
                {
                    ProxyInfo proxyInfo = new ProxyInfo(value);
                    this.ProxyConnection = proxyInfo.Port != 0 ? $"{proxyInfo.Host}:{proxyInfo.Port}" : "";
                    this.Username = proxyInfo.UserName ?? "";
                    this.Password = proxyInfo.Password ?? "";
                    this.AutoAuth = !string.IsNullOrEmpty(this.Username);
                }
                catch { }
            }
        }
    }
}
