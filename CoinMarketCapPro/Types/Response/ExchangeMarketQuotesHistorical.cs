using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
	public class ExchangeMarketQuotesHistorical
	{
		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }
		[JsonProperty("data")]
		public ExchangeMarketQuotesHistoricalData ExchangeMarketQuotesHistoricalData { get; set; }
	}
	
	public class ExchangeMarketQuotesHistoricalData
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("quotes")]
		public List<ExchangeMarketQuotesHistoricalQuote> Quotes { get; set; }
	}
	public class ExchangeMarketQuotesHistoricalQuote
	{
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }
		[JsonProperty("quote")]
		public Dictionary<string, ExchangeMarketQuotesHistoricalDetail> Quote { get; set; }
		[JsonProperty("num_market_pairs")]
		public int NumMarketPairs { get; set; }
	}
	
	public class ExchangeMarketQuotesHistoricalDetail
	{
		[JsonProperty("volume_24h")]
		public int Volume24h { get; set; }
		[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; }
	}

}
