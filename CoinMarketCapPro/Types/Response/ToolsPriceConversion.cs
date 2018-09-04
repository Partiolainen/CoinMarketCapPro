using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
	public class ToolsPriceConversion
	{
		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }
		[JsonProperty("data")]
		public ToolsPriceConversionData Data { get; set; }
	}
	
	public class ToolsPriceConversionData
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("symbol")]
		public string Symbol { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("amount")]
		public int Amount { get; set; }
		[JsonProperty("last_updated")]
		public DateTime LastUpdated { get; set; }
		[JsonProperty("quote")]
		public Dictionary<string, ToolsPriceConversionDetail> Quote { get; set; }
	}
	
	public class ToolsPriceConversionDetail
	{
		[JsonProperty("price")]
		public double Price { get; set; }
		[JsonProperty("last_updated")]
		public DateTime LastUpdated { get; set; }
	}

}
