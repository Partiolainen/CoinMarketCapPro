using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
	public class GlobalMetricsQuotes
	{
		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }
		[JsonProperty("data")]
		public GlobalMetricsQuotesData Data { get; set; }
	}
	
	public class GlobalMetricsQuotesData
	{
		[JsonProperty("active_cryptocurrencies")]
		public int ActiveCryptocurrencies { get; set; }
		[JsonProperty("active_market_pairs")]
		public int ActiveMarketPairs { get; set; }
		[JsonProperty("active_exchanges")]
		public int ActiveExchanges { get; set; }
		[JsonProperty("eth_dominance")]
		public double EthDominance { get; set; }
		[JsonProperty("btc_dominance")]
		public double BtcDominance { get; set; }
		[JsonProperty("quote")]
		public Dictionary<string, GlobalMetricsQuotesDetail> Quote { get; set; }
		[JsonProperty("last_updated")]
		public DateTime LastUpdated { get; set; }
	}
	
	public class GlobalMetricsQuotesDetail
	{
		[JsonProperty("total_market_cap")]
		public double TotalMarketCap { get; set; }
		[JsonProperty("total_volume_24h")]
		public double TotalVolume24h { get; set; }
		[JsonProperty("last_updated")]
		public DateTime LastUpdated { get; set; }
	}

}
