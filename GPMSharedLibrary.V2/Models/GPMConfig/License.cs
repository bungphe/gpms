using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class License
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "";
        [JsonProperty("machineId")]
        public string MachineId { get; set; } = "";
        [JsonProperty("thirdparty_key")]
        public string Thirdparty_Key { get; set; } = "";
    }
}
