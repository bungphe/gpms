using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class Brand
    {
        [JsonProperty("version")]
        public string Version { get; set; } = "";
    }
}
