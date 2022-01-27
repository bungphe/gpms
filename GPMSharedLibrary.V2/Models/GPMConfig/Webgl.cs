using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class Webgl
    {
        /// <summary>
        /// Not set: -1
        /// Range: 0.0001 -> 0.9990
        /// </summary>
        [JsonProperty("canvasNoise")]
        public double CanvasNoise { get; set; } = -1;
        /// <summary>
        /// Not set: -1
        /// Range: 0.0001 -> 0.0999
        /// </summary>
        [JsonProperty("clientRectNoise")]
        public double ClientRectNoise { get; set; } = -1;

        [JsonProperty("vendor")]
        public string Vendor { get; set; } = "";
        [JsonProperty("render")]
        public string Render { get; set; } = "";
        /// <summary>
        /// Not set: -1
        /// Range: 0.001 -> 0.199 (total 4 number. Eg error 0.0001)
        /// </summary>
        [JsonProperty("uniform2fNoise")]
        public double Uniform2fNoise { get; set; }

    }
}
