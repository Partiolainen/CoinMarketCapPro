using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
	public class CurrencyMarketPairs
	{
		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }
		[JsonProperty("data")]
		public ResponseMarketPairsData Data { get; set; }
	}
	public class ResponseMarketPairsData
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("symbol")]
		public string Symbol { get; set; }
		[JsonProperty("num_market_pairs")]
		public int NumMarketPairs { get; set; }
		[JsonProperty("market_pairs")]
		public List<ResponseMarketPairsMarketPairs> MarketPairs { get; set; }
	}
	public class ResponseMarketPairsMarketPairs
	{
		[JsonProperty("exchange")]
		public ResponseMarketPairsExchange Exchange { get; set; }
		[JsonProperty("market_pair")]
		public string MarketPair { get; set; }
		[JsonProperty("market_pair_base")]
		public ResponseMarketPairsMarketPairBase MarketPairBase { get; set; }
		[JsonProperty("market_pair_quote")]
		public ResponseMarketPairsMarketPairQuote MarketPairQuote { get; set; }
		[JsonProperty("quote")]
		public Dictionary<string,ResponseMarketPairsQuote> Quote { get; set; }
	}
	public class ResponseMarketPairsExchange
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
	}
	public class ResponseMarketPairsMarketPairBase
	{
		[JsonProperty("currency_id")]
		public int CurrencyId { get; set; }
		[JsonProperty("currency_symbol")]
		public string CurrencySymbol { get; set; }
		[JsonProperty("currency_type")]
		public string CurrencyType { get; set; }
	}
	public class ResponseMarketPairsMarketPairQuote
	{
		[JsonProperty("currency_id")]
		public int CurrencyId { get; set; }
		[JsonProperty("currency_symbol")]
		public string CurrencySymbol { get; set; }
		[JsonProperty("currency_type")]
		public string CurrencyType { get; set; }
	}
	public class ResponseMarketPairsQuote
	{
		[JsonProperty("price")]
		public double? Price { get; set; }
		[JsonProperty("volume_24h_base")]
		public double? Volume24hBase { get; set; }
		[JsonProperty("volume_24h_quote")]
		public double? Volume24hQuote { get; set; }
		[JsonProperty("volume_24h")]
		public double? Volume24h { get; set; }
		[JsonProperty("last_updated")]
		public DateTime? LastUpdated { get; set; }
	}
}
