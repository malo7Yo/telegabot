using Newtonsoft.Json;


namespace bottelega.classes
{
    class temp
    {
        public decimal Temp { get; set; }
        [JsonProperty("feels_like")]
        public decimal FeelsLike { get; set; }
    }
}
