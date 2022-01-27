using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class Screen
    {
        // Screen
        /// <summary>
        /// Not set: -1
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; } = -1;
        /// <summary>
        /// Not set: -1
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; } = -1;
        /// <summary>
        /// Not set: -1
        /// </summary>
        [JsonProperty("availWidth")]
        public int AvailWidth { get; set; } = -1;
        /// <summary>
        /// Not set: -1
        /// </summary>
        [JsonProperty("availHeight")]
        public int AvailHeight { get; set; } = -1;
    }
}
