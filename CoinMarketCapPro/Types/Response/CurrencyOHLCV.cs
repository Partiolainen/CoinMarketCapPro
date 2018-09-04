using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
    public class CurrencyOHLCV
    {
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; }
        [JsonProperty("data")]
        public ResponseOHLCVData Data { get; set; }
    }
    public class ResponseOHLCVData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("quotes")]
        public List<ResponseOHLCVQuote> Quotes { get; set; }
    }
    public class ResponseOHLCVQuote
    {
        [JsonProperty("time_open")]
        public DateTime TimeOpen { get; set; }
        [JsonProperty("time_close")]
        public DateTime TimeClose { get; set; }
        [JsonProperty("quote")]
        public Dictionary<string, ResponseOHLCVDetail> Quote { get; set; }
    }
    public class ResponseOHLCVDetail
    {
        [JsonProperty("open")]
        public double Open { get; set; }
        [JsonProperty("high")]
        public double High { get; set; }
        [JsonProperty("low")]
        public double Low { get; set; }
        [JsonProperty("close")]
        public double Close { get; set; }
        [JsonProperty("volume")]
        public long Volume { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

}
