using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class Audio
    {
        /// <summary>
        /// Not set: -1
        /// Range: 0.0001 -> 0.9999
        /// </summary>
        [JsonProperty("noise")]
        public double Noise { get; set; } = -1;
    }
}
