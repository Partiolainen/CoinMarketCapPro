using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
    public class CurrencyMarketQuotesHistorical
    {
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; }
        [JsonProperty("data")]
        public ResponseMarketQuotesHistoricalData Data { get; set; }
    }
   
    public class ResponseMarketQuotesHistoricalData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("quotes")]
        public List<ResponseMarketQuotesHistoricalQuote> Quotes { get; set; }
    }
    public class ResponseMarketQuotesHistoricalQuote
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("quote")]
        public Dictionary<string, ResponseMarketQuotesHistoricalDetail> Quote { get; set; }
    }
    public class ResponseMarketQuotesHistoricalDetail
    {
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("market_cap")]
        public double MarketCap { get; set; }
        [JsonProperty("volume_24h")]
        public long Volume24h { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

}
