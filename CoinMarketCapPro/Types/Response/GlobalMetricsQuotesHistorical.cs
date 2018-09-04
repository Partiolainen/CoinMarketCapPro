using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
	public class GlobalMetricsQuotesHistorical
	{
		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }
		[JsonProperty("data")]
		public GlobalMetricsQuotesHistoricalData Data { get; set; }
	}
	
	public class GlobalMetricsQuotesHistoricalData
	{
		[JsonProperty("quotes")]
		public List<GlobalMetricsQuotesHistoricalQuote> Quotes { get; set; }
	}
	public class GlobalMetricsQuotesHistoricalQuote
	{
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }
		[JsonProperty("btc_dominance")]
		public double BtcDominance { get; set; }
		[JsonProperty("quote")]
		public Dictionary<string, GlobalMetricsQuotesHistoricalDetail> Quote { get; set; }
	}
	
	public class GlobalMetricsQuotesHistoricalDetail
	{
		[JsonProperty("total_market_cap")]
		public double TotalMarketCap { get; set; }
		[JsonProperty("total_volume_24h")]
		public double TotalVolume24h { get; set; }
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }
	}

}
