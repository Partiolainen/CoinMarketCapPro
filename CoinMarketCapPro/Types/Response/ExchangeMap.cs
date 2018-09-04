using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
    public class ExchangeMap
    {
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; }
        [JsonProperty("data")]
        public List<ExchangeMapDatum> Data { get; set; }
    }
 
    public class ExchangeMapDatum
	{
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("is_active")]
        public int IsActive { get; set; }
        [JsonProperty("first_historical_data")]
        public DateTime FirstHistoricalData { get; set; }
        [JsonProperty("last_historical_data")]
        public DateTime LastHistoricalData { get; set; }
    }

}
