using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
	public class CurrencyMap
	{
		[JsonProperty("data")]
		public List<ResponseMapDatum> Data { get; set; }

		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }
	}
	public class ResponseMapDatum
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }

		[JsonProperty("is_active")]
		public bool IsActive { get; set; }

		[JsonProperty("first_historical_data")]
		public DateTime? FirstHistoricalData { get; set; }

		[JsonProperty("last_historical_data")]
		public DateTime? LastHistoricalData { get; set; }
	}
	

}
