using Newtonsoft.Json;

namespace GPMSharedLibrary.V2.Models.GPMConfig
{
    public class Navigator
    {
        /// <summary>
        /// Not set: -1
        /// </summary>
        [JsonProperty("processorCount")]
        public int ProcessorCount { get; set; } = -1;
    }
}
