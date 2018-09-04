using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
	public class ExchangeListings
	{
		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }
		[JsonProperty("data")]
		public List<ExchangeListingsDatum> Data { get; set; }
	}
	
	public class ExchangeListingsDatum
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("num_market_pairs")]
		public int NumMarketPairs { get; set; }
		[JsonProperty("last_updated")]
		public DateTime LastUpdated { get; set; }
		[JsonProperty("quote")]
		public Dictionary<string, ExchangeListingsDetail> Quote { get; set; }
	}
	
	public class ExchangeListingsDetail
	{
		[JsonProperty("volume_24h")]
		public double Volume24h { get; set; }
	}

}
