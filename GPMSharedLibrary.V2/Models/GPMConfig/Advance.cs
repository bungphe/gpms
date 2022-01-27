using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class Advance
    {
        /// <summary>
        /// Range: 3000-4500
        /// </summary>
        [JsonProperty("maxVertexUniform")]
        public int MaxVertexUniform { get; set; }
        /// <summary>
        /// Range: 900->1500
        /// </summary>
        [JsonProperty("maxFragmentUniform")]
        public int MaxFragmentUniform { get; set; }
    }
}
