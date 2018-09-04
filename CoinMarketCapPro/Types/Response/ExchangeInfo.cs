using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
     public class ExchangeInfo
    {
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; }
        [JsonProperty("data")]
        public Dictionary<string, ExchangeInfoData> Data { get; set; }
    }
    
    public class ExchangeInfoData
{
    [JsonProperty("urls")]
    public ExchangeInfoUrls Urls { get; set; }
    [JsonProperty("logo")]
    public string Logo { get; set; }
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("slug")]
    public string Slug { get; set; }
    }
    public class ExchangeInfoUrls
    {
        [JsonProperty("website")]
        public List<string> Website { get; set; }
        [JsonProperty("twitter")]
        public List<string> Twitter { get; set; }
        [JsonProperty("blog")]
        public List<object> Blog { get; set; }
        [JsonProperty("chat")]
        public List<string> Chat { get; set; }
        [JsonProperty("fee")]
        public List<string> Fee { get; set; }
    }

}
