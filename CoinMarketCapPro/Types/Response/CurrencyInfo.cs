using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoinMarketCapPro.Types.Response
{
	public class CurrencyInfo
	{
		[JsonProperty("data")]
		public Dictionary<string, ResponseInfoCoin> Data { get; set; }
		[JsonProperty("status")]
		public ResponseStatus Status { get; set; }
	}
	
	public class ResponseInfoCoin
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("symbol")]
		public string Symbol { get; set; }
		[JsonProperty("category")]
		public string Category { get; set; }
		[JsonProperty("slug")]
		public string Slug { get; set; }
		[JsonProperty("logo")]
		public string Logo { get; set; }
		[JsonProperty("tags")]
		public List<string> Tags { get; set; }
		[JsonProperty("urls")]
		public ResponseInfoCoinUrls Urls { get; set; }
	}
	public class ResponseInfoCoinUrls
	{
		[JsonProperty("website")]
		public List<string> Website { get; set; }
		[JsonProperty("explorer")]
		public List<string> Explorer { get; set; }
		[JsonProperty("source_code")]
		public List<string> SourceCode { get; set; }
		[JsonProperty("message_board")]
		public List<string> MessageBoard { get; set; }
		[JsonProperty("chat")]
		public List<object> Chat { get; set; }
		[JsonProperty("announcement")]
		public List<object> Announcement { get; set; }
		[JsonProperty("reddit")]
		public List<string> Reddit { get; set; }
		[JsonProperty("twitter")]
		public List<string> Twitter { get; set; }
	}
	

}
