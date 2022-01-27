using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class WebRTC
    {
        /// <summary>
        /// real, disable, fake
        /// </summary>
        /// 
        [JsonProperty("mode")]
        public string Mode { get; set; } = "real";
        [JsonProperty("publicIP")]
        public string PublicIP { get; set; } = "";
    }
}
