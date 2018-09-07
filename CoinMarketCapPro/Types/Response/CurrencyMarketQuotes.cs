using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
    public class CurrencyMarketQuotes
    {
        [JsonProperty("status")]
        public ResponseStatus Status { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, ResponseMarketQuotesData> Data { get; set; }
    }


    public class ResponseMarketQuotesData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("circulating_supply")]
        public double? CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public double? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public double? MaxSupply { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("num_market_pairs")]
        public int NumMarketPairs { get; set; }

        [JsonProperty("cmc_rank")]
        public int CmcRank { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, ResponseMarketQuotesDetail> Quote { get; set; }
    }

    public class ResponseMarketQuotesDetail
    {
        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("volume_24h")]
        public double? Volume24h { get; set; }

        [JsonProperty("percent_change_1h")]
        public double? PercentChange1h { get; set; }

        [JsonProperty("percent_change_24h")]
        public double? PercentChange24h { get; set; }

        [JsonProperty("percent_change_7d")]
        public double? PercentChange7d { get; set; }

        [JsonProperty("market_cap")]
        public double? MarketCap { get; set; }

        [JsonProperty("last_updated")]
        public DateTime? LastUpdated { get; set; }
    }

}
