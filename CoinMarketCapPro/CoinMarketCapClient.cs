using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro.Types;
using CoinMarketCapPro.Types.QueryParamTypes;
using CoinMarketCapPro.Types.Response;
using Flurl;
using Flurl.Http;

namespace CoinMarketCapPro
{
	public class CoinMarketCapClient
	{
		public CoinMarketCapClient(ApiSchema apischema, string apikey)
		{
			if (string.IsNullOrEmpty(apikey)) throw new CoinMarketCapException("Wrong API key");
			this.apikey = apikey;
			baseurl = $"https://{(apischema == ApiSchema.Pro ? "pro" : "sandbox")}-api.coinmarketcap.com/v1/";
		}

		private readonly string apikey;
		private readonly string baseurl;

		private async Task<T> Request<T>(string path, QueryParam param)
		{
			var query = baseurl.AppendPathSegment(path)
				.WithHeader("X-CMC_PRO_API_KEY", apikey).WithHeader("Accept", "application/json")
				.WithHeader("Accept-Encoding", "deflate, gzip");

			query.SetQueryParam(param.Name, param.Value);

			var response = await query.GetJsonAsync<T>();

			return response;
		}

		private async Task<T> Request<T>(string path, QueryParams paramlist)
		{
			var query = baseurl.AppendPathSegment(path)
				.WithHeader("X-CMC_PRO_API_KEY", apikey).WithHeader("Accept", "application/json")
				.WithHeader("Accept-Encoding", "deflate, gzip");

			foreach (var param in paramlist)
			{
				query.SetQueryParam(param.Name, param.Value);
			}

			var response = await query.GetJsonAsync<T>();

			return response;
		}

		public async Task<CurrencyInfo> GetCurrencyInfoAsync(List<int> ids = null)
		{
			return await GetCurrencyInfoBase(ids);
		}

		public async Task<CurrencyInfo> GetCurrencyInfoAsync(int id)
		{
			return await GetCurrencyInfoBase(new List<int> {id});
		}

		public async Task<CurrencyInfo> GetCurrencyInfoAsync(List<string> symbols = null)
		{
			return await GetCurrencyInfoBase(null, symbols);
		}

		public async Task<CurrencyInfo> GetCurrencyInfoAsync(string symbol = null)
		{
			return await GetCurrencyInfoBase(null, new List<string> {symbol});
		}

		private async Task<CurrencyInfo> GetCurrencyInfoBase(List<int> ids = null, List<string> symbols = null)
		{
			if (ids == null && symbols == null)
				throw new CoinMarketCapException("At least one \"id\" or \"symbol\" is required");

			var response = await Request<CurrencyInfo>("cryptocurrency/info",
				new QueryParams(ids.ToQueryParam("id"), symbols.ToQueryParam("symbol")).FirstNotNullParameter());

			return response;
		}

		public async Task<CurrencyMap> GetCurrencyMapAsync(ParamListingStatus listingstatus = ParamListingStatus.Active,
			int? start = 1, int? limit = null, string symbol = null)
		{
			return await GetCurrencyMapAsync(symbol == null ? null : new List<string> {symbol}, listingstatus, start, limit);
		}


		public async Task<CurrencyMap> GetCurrencyMapAsync(List<string> symbols, ParamListingStatus listingstatus = ParamListingStatus.Active,
			int? start = 1, int? limit = null)
		{
			var response = await Request<CurrencyMap>("cryptocurrency/map",
				new QueryParams(listingstatus.ToQueryParam("listing_status"),
					start.ToQueryParam("start"),
					limit.ToQueryParam("limit"),
					symbols.ToQueryParam("symbol")));

			return response;
		}

		//  public async Task<CurrencyListings> GetCurrencyListingsHistoricalAsync(string timestamp, int start = 1, int limit = 100,
		//   List<string> convert = null, SortBy sort = SortBy.Market_Cap, SortDirection sort_dir = SortDirection.Desc,
		//   CryptocurrencyType cryptocurrency_type = CryptocurrencyType.All)
		//  {

		//throw new CoinMarketCapException("Not implemented by CoinMarketCap");

		//   //var response = await Request<CurrencyListings>("cryptocurrency/listings/historical",
		//   // new QueryParams(timestamp.ToQueryParam("timestamp"), start.ToQueryParam("start"), limit.ToQueryParam("limit"),
		//	  //  convert.ToQueryParam("convert"), sort.ToQueryParam("sort"),
		//	  //  sort_dir.ToQueryParam("sort_dir"), cryptocurrency_type.ToQueryParam("cryptocurrency_type")));

		//   //return response;
		//  }

		public async Task<CurrencyListings> GetCurrencyListingsAsync(int start = 1, int limit = 100,
			List<string> convert = null, SortBy sort = SortBy.Market_Cap, SortDirection sort_dir = SortDirection.Desc,
			CryptocurrencyType cryptocurrency_type = CryptocurrencyType.All)
		{
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<CurrencyListings>("cryptocurrency/listings/latest",
				new QueryParams(start.ToQueryParam("start"), limit.ToQueryParam("limit"), convert.ToQueryParam("convert"),
					sort.ToQueryParam("sort"), sort_dir.ToQueryParam("sort_dir"),
					cryptocurrency_type.ToQueryParam("cryptocurrency_type")));

			return response;
		}


		public async Task<CurrencyMarketPairs> GetCurrencyMarketPairsAsync(int id, List<string> convert, int start = 1,
			int limit = 100)
		{
			return await GetCurrencyMarketPairsBase(id, null, start, limit, convert);
		}

		public async Task<CurrencyMarketPairs> GetCurrencyMarketPairsAsync(string symbol, List<string> convert, int start = 1,
			int limit = 100)
		{
			return await GetCurrencyMarketPairsBase(null, symbol, start, limit, convert);
		}

		public async Task<CurrencyMarketPairs> GetCurrencyMarketPairsAsync(int id, int start = 1, int limit = 100,
			string convert = null)
		{
			return await GetCurrencyMarketPairsBase(id, null, start, limit, convert==null ? null : new List<string> {convert});
		}

		public async Task<CurrencyMarketPairs> GetCurrencyMarketPairsAsync(string symbol, int start = 1, int limit = 100,
			string convert = null)
		{
			return await GetCurrencyMarketPairsBase(null, symbol, start, limit, convert==null ? null : new List<string> {convert});
		}

		private async Task<CurrencyMarketPairs> GetCurrencyMarketPairsBase(int? id = null, string symbol = null,
			int start = 1,
			int limit = 100,
			List<string> convert = null)
		{
			if (id == null && symbol == null)
				throw new CoinMarketCapException("At least one \"id\" or \"symbol\" is required");

			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<CurrencyMarketPairs>("cryptocurrency/market-pairs/latest",
				new QueryParams(new QueryParams(id.ToQueryParam("id"), symbol.ToQueryParam("symbol")).FirstNotNullParameter(),
					start.ToQueryParam("start"), limit.ToQueryParam("limit"), convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<CurrencyOHLCV> GetCurrencyMarketOHLCVHistoricalAsync(int id, string time_period = "daily",
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.Daily,
			List<string> convert = null)
		{
			return await GetCurrencyMarketOHLCVHistoricalBase(id, null, time_period, time_start, time_end, count, interval,
				convert);
		}

		public async Task<CurrencyOHLCV> GetCurrencyMarketOHLCVHistoricalAsync(string symbol, string time_period = "daily",
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.Daily,
			List<string> convert = null)
		{
			return await GetCurrencyMarketOHLCVHistoricalBase(null, symbol, time_period, time_start, time_end, count,
				interval, convert);
		}

		public async Task<CurrencyOHLCV> GetCurrencyMarketOHLCVHistoricalAsync(int id, string time_period = "daily",
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.Daily,
			string convert = null)
		{
			return await GetCurrencyMarketOHLCVHistoricalBase(id, null, time_period, time_start, time_end, count, interval,
				convert==null ? null : new List<string> {convert});
		}

		public async Task<CurrencyOHLCV> GetCurrencyMarketOHLCVHistoricalAsync(string symbol, string time_period = "daily",
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.Daily,
			string convert = null)
		{
			return await GetCurrencyMarketOHLCVHistoricalBase(null, symbol, time_period, time_start, time_end, count,
				interval, convert==null ? null : new List<string> {convert});
		}

		private async Task<CurrencyOHLCV> GetCurrencyMarketOHLCVHistoricalBase(int? id = null, string symbol = null,
			string time_period = "daily", string time_start = null, string time_end = null, int count = 10,
			string interval = ParamInterval.Daily, List<string> convert = null)
		{
			if (id == null && symbol == null)
				throw new CoinMarketCapException("At least one \"id\" or \"symbol\" is required");
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<CurrencyOHLCV>("cryptocurrency/ohlcv/historical",
				new QueryParams(new QueryParams(id.ToQueryParam("id"), symbol.ToQueryParam("symbol")).FirstNotNullParameter(),
					time_period.ToQueryParam("time_period"), time_start.ToQueryParam("time_start"),
					time_end.ToQueryParam("time_end"), count.ToQueryParam("count"), interval.ToQueryParam("interval"),
					convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<CurrencyMarketQuotesHistorical> GetCurrencyMarketQuotesHistoricalAsync(int id, List<string> convert,
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.M5)
		{
			return await GetCurrencyMarketQuotesHistoricalBase(id, null, time_start, time_end, count, interval, convert);
		}

		public async Task<CurrencyMarketQuotesHistorical> GetCurrencyMarketQuotesHistoricalAsync(string symbol,
			List<string> convert,
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.M5
		)
		{
			return await GetCurrencyMarketQuotesHistoricalBase(null, symbol, time_start, time_end, count, interval, convert);
		}

		public async Task<CurrencyMarketQuotesHistorical> GetCurrencyMarketQuotesHistoricalAsync(int id,
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.M5,
			string convert = null)
		{
			return await GetCurrencyMarketQuotesHistoricalBase(id, null, time_start, time_end, count, interval,
				convert==null ? null : new List<string> {convert});
		}

		public async Task<CurrencyMarketQuotesHistorical> GetCurrencyMarketQuotesHistoricalAsync(string symbol,
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.M5,
			string convert = null)
		{
			return await GetCurrencyMarketQuotesHistoricalBase(null, symbol, time_start, time_end, count, interval,
				convert==null ? null : new List<string> {convert});
		}

		private async Task<CurrencyMarketQuotesHistorical> GetCurrencyMarketQuotesHistoricalBase(int? id = null,
			string symbol = null, string time_start = null, string time_end = null, int count = 10,
			string interval = ParamInterval.M5, List<string> convert = null)
		{
			if (id == null && symbol == null)
				throw new CoinMarketCapException("At least one \"id\" or \"symbol\" is required");
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<CurrencyMarketQuotesHistorical>("cryptocurrency/quotes/historical",
				new QueryParams(new QueryParams(id.ToQueryParam("id"), symbol.ToQueryParam("symbol")).FirstNotNullParameter(),
					time_start.ToQueryParam("time_start"),
					time_end.ToQueryParam("time_end"), count.ToQueryParam("count"), interval.ToQueryParam("interval"),
					convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesAsync(List<int> ids, List<string> convert)
		{
			return await GetCurrencyMarketQuotesBase(ids, null, convert);
		}

		public async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesAsync(List<string> symbols, List<string> convert)
		{
			return await GetCurrencyMarketQuotesBase(null, symbols, convert);
		}

		public async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesAsync(int id, List<string> convert)
		{
			return await GetCurrencyMarketQuotesBase(new List<int> {id}, null, convert);
		}

		public async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesAsync(string symbol, List<string> convert)
		{
			return await GetCurrencyMarketQuotesBase(null, new List<string> {symbol}, convert);
		}


		public async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesAsync(List<int> ids, string convert = null)
		{
			return await GetCurrencyMarketQuotesBase(ids, null, convert==null ? null : new List<string> {convert});
		}

		public async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesAsync(List<string> symbols, string convert = null)
		{
			return await GetCurrencyMarketQuotesBase(null, symbols, convert==null ? null : new List<string> {convert});
		}

		public async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesAsync(int id, string convert = null)
		{
			return await GetCurrencyMarketQuotesBase(new List<int> {id}, null, convert==null ? null : new List<string> {convert});
		}

		public async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesAsync(string symbol, string convert = null)
		{
			return await GetCurrencyMarketQuotesBase(null, new List<string> {symbol}, convert==null ? null : new List<string> {convert});
		}

		private async Task<CurrencyMarketQuotes> GetCurrencyMarketQuotesBase(List<int> ids = null,
			List<string> symbols = null,
			List<string> convert = null)
		{
			if ((ids ?? new List<int>()).Count == 0 && (symbols ?? new List<string>()).Count == 0)
				throw new CoinMarketCapException("At least one \"id\" or \"symbol\" is required");
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<CurrencyMarketQuotes>("cryptocurrency/quotes/latest",
				new QueryParams(
					new QueryParams(ids.ToQueryParam("id"), symbols.ToQueryParam("symbol")).FirstNotNullParameter(),
					convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<ExchangeInfo> GetExchangeInfoAsync(int id)
		{
			return await GetExchangeInfoBase(new List<int> {id});
		}

		public async Task<ExchangeInfo> GetExchangeInfoAsync(string slug)
		{
			return await GetExchangeInfoBase(null, new List<string> {slug});
		}

		public async Task<ExchangeInfo> GetExchangeInfoAsync(List<int> ids)
		{
			return await GetExchangeInfoBase(ids);
		}

		public async Task<ExchangeInfo> GetExchangeInfoAsync(List<string> slugs)
		{
			return await GetExchangeInfoBase(null, slugs);
		}

		private async Task<ExchangeInfo> GetExchangeInfoBase(List<int> ids = null, List<string> slugs = null)
		{
			if ((ids ?? new List<int>()).Count == 0 && (slugs ?? new List<string>()).Count == 0)
				throw new CoinMarketCapException("At least one \"id\" or \"slug\" is required");
			var response = await Request<ExchangeInfo>("exchange/info",
				new QueryParams(ids.ToQueryParam("id"), slugs.ToQueryParam("slug")).FirstNotNullParameter());

			return response;
		}

		public async Task<ExchangeMap> GetExchangeMapAsync(ParamListingStatus listing_status = ParamListingStatus.Active,
			List<string> slugs = null, int start = 1, int limit = 100)
		{
			var response = await Request<ExchangeMap>("exchange/map",
				new QueryParams(listing_status.ToQueryParam("listing_status"), slugs.ToQueryParam("slug"),
					start.ToQueryParam("start"), limit.ToQueryParam("limit")));

			return response;
		}

		//   public async Task<object> GetExchangeListingsHistoriacalAsync(string timestamp, int start = 1, int limit = 100,
		//          SortBy sort = SortBy.Market_Cap, SortDirection sort_dir = SortDirection.Desc,
		//           MarketType market_type = MarketType.Fees, List<string> convert = null)
		//   {
		//    throw new CoinMarketCapException("Not implemented by CoinMarketCap");
		//	if (convert == null || convert.Count == 0) convert = new List<string>() { "USD" };
		//	var response = await Request<object>("exchange/listings/historical",
		//		new QueryParams(timestamp.ToQueryParam("timestamp"), start.ToQueryParam("start"), limit.ToQueryParam("limit"),
		//			sort.ToQueryParam("sort"), sort_dir.ToQueryParam("sort_dir"), market_type.ToQueryParam("market_type"),
		//			convert.ToQueryParam("convert")));

		//	return response;
		//}

		public async Task<ExchangeListings> GetExchangeListingsAsync(int start = 1, int limit = 100,
			SortBy sort = SortBy.Volume_24h, SortDirection sort_dir = SortDirection.Desc,
			MarketType market_type = MarketType.Fees, string convert = null)
		{
			return await GetExchangeListingsAsync(convert==null ? null : new List<string> {convert}, start, limit, sort, sort_dir, market_type);
		}


		public async Task<ExchangeListings> GetExchangeListingsAsync(List<string> convert, int start = 1, int limit = 100,
			SortBy sort = SortBy.Volume_24h, SortDirection sort_dir = SortDirection.Desc,
			MarketType market_type = MarketType.Fees)
		{
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<ExchangeListings>("exchange/listings/latest",
				new QueryParams(start.ToQueryParam("start"), limit.ToQueryParam("limit"), sort.ToQueryParam("sort"),
					sort_dir.ToQueryParam("sort_dir"), market_type.ToQueryParam("market_type"), convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<ExchangeMarketPairs> GetExchangeMarketPairsAsync(int id, List<string> convert, int start = 1,
			int limit = 100)
		{
			return await GetExchangeMarketPairsBase(id, null, start, limit, convert);
		}

		public async Task<ExchangeMarketPairs> GetExchangeMarketPairsAsync(string slug, List<string> convert, int start = 1,
			int limit = 100)
		{
			return await GetExchangeMarketPairsBase(null, slug, start, limit, convert);
		}

		public async Task<ExchangeMarketPairs> GetExchangeMarketPairsAsync(int id, int start = 1, int limit = 100,
			string convert = null)
		{
			return await GetExchangeMarketPairsBase(id, null, start, limit, convert==null ? null : new List<string> {convert});
		}

		public async Task<ExchangeMarketPairs> GetExchangeMarketPairsAsync(string slug, int start = 1, int limit = 100,
			string convert = null)
		{
			return await GetExchangeMarketPairsBase(null, slug, start, limit, convert==null ? null : new List<string> {convert});
		}

		private async Task<ExchangeMarketPairs> GetExchangeMarketPairsBase(int? id = null, string slug = null,
			int start = 1, int limit = 100, List<string> convert = null)
		{
			if (id == null && slug == null)
				throw new CoinMarketCapException("At least one \"id\" or \"slug\" is required");
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<ExchangeMarketPairs>("exchange/market-pairs/latest",
				new QueryParams(new QueryParams(id.ToQueryParam("id"), slug.ToQueryParam("slug")).FirstNotNullParameter(),
					start.ToQueryParam("start"), limit.ToQueryParam("limit"), convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<ExchangeMarketQuotesHistorical> ExchangeMarketQuotesHistoricalAsync(int id,
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.M5,
			string convert = null)
		{
			return await ExchangeMarketQuotesHistoricalBase(id, null, time_start, time_end, count, interval,
				convert==null ? null : new List<string> {convert});
		}

		public async Task<ExchangeMarketQuotesHistorical> ExchangeMarketQuotesHistoricalAsync(string slug,
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.M5,
			string convert = null)
		{
			return await ExchangeMarketQuotesHistoricalBase(null, slug, time_start, time_end, count, interval,
				convert==null ? null : new List<string> {convert});
		}

		public async Task<ExchangeMarketQuotesHistorical> ExchangeMarketQuotesHistoricalAsync(int id, List<string> convert,
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.M5)
		{
			return await ExchangeMarketQuotesHistoricalBase(id, null, time_start, time_end, count, interval, convert);
		}

		public async Task<ExchangeMarketQuotesHistorical> ExchangeMarketQuotesHistoricalAsync(string slug,
			List<string> convert,
			string time_start = null, string time_end = null, int count = 10, string interval = ParamInterval.M5)
		{
			return await ExchangeMarketQuotesHistoricalBase(null, slug, time_start, time_end, count, interval, convert);
		}

		private async Task<ExchangeMarketQuotesHistorical> ExchangeMarketQuotesHistoricalBase(int? id = null,
			string slug = null, string time_start = null, string time_end = null, int count = 10,
			string interval = ParamInterval.M5,
			List<string> convert = null)
		{
			if (id == null && slug == null)
				throw new CoinMarketCapException("At least one \"id\" or \"slug\" is required");
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<ExchangeMarketQuotesHistorical>("exchange/quotes/historical",
				new QueryParams(new QueryParams(id.ToQueryParam("id"), slug.ToQueryParam("slug")).FirstNotNullParameter(),
					time_start.ToQueryParam("time_start"), time_end.ToQueryParam("time_end"), count.ToQueryParam("count"),
					interval.ToQueryParam("interval"), convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<ExchangeMarketQuotes> ExchangeMarketQuotesAsync(int id, List<string> convert)
		{
			return await ExchangeMarketQuotesBase(new List<int> {id}, null, convert);
		}

		public async Task<ExchangeMarketQuotes> ExchangeMarketQuotesAsync(List<int> ids, List<string> convert)
		{
			return await ExchangeMarketQuotesBase(ids, null, convert);
		}

		public async Task<ExchangeMarketQuotes> ExchangeMarketQuotesAsync(string slug, List<string> convert)
		{
			return await ExchangeMarketQuotesBase(null, new List<string> {slug}, convert);
		}

		public async Task<ExchangeMarketQuotes> ExchangeMarketQuotesAsync(List<string> slugs, List<string> convert)
		{
			return await ExchangeMarketQuotesBase(null, slugs, convert);
		}

		public async Task<ExchangeMarketQuotes> ExchangeMarketQuotesAsync(int id, string convert = null)
		{
			return await ExchangeMarketQuotesBase(new List<int> {id}, null, convert==null ? null : new List<string> {convert});
		}

		public async Task<ExchangeMarketQuotes> ExchangeMarketQuotesAsync(List<int> ids, string convert = null)
		{
			return await ExchangeMarketQuotesBase(ids, null, convert==null ? null : new List<string> {convert});
		}

		public async Task<ExchangeMarketQuotes> ExchangeMarketQuotesAsync(string slug, string convert = null)
		{
			return await ExchangeMarketQuotesBase(null, new List<string> {slug}, convert==null ? null : new List<string> {convert});
		}

		public async Task<ExchangeMarketQuotes> ExchangeMarketQuotesAsync(List<string> slugs, string convert = null)
		{
			return await ExchangeMarketQuotesBase(null, slugs, convert==null ? null : new List<string> {convert});
		}

		private async Task<ExchangeMarketQuotes> ExchangeMarketQuotesBase(List<int> ids = null, List<string> slugs = null,
			List<string> convert = null)
		{
			if ((ids ?? new List<int>()).Count == 0 && (slugs ?? new List<string>()).Count == 0)
				throw new CoinMarketCapException("At least one \"id\" or \"slug\" is required");
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<ExchangeMarketQuotes>("exchange/quotes/latest",
				new QueryParams(new QueryParams(ids.ToQueryParam("id"), slugs.ToQueryParam("slug")).FirstNotNullParameter(),
					convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<GlobalMetricsQuotesHistorical> GlobalMetricsQuotesHistoricalAsync(string time_start = null,
			string time_end = null, int count = 10, string interval = ParamInterval.D1,
			List<string> convert = null)
		{
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<GlobalMetricsQuotesHistorical>("global-metrics/quotes/historical",
				new QueryParams(time_start.ToQueryParam("time_start"), time_end.ToQueryParam("time_end"),
					count.ToQueryParam("count"), interval.ToQueryParam("interval"), convert.ToQueryParam("convert")));

			return response;
		}

		public async Task<GlobalMetricsQuotes> GlobalMetricsQuotesAsync(List<string> convert = null)
		{
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<GlobalMetricsQuotes>("global-metrics/quotes/latest",
				convert.ToQueryParam("convert"));

			return response;
		}

		public async Task<ToolsPriceConversion> ToolsPriceConversionAsync(int id, double amount = 1.0, string time = null,
			List<string> convert = null)
		{
			return await ToolsPriceConversionBase(amount, id, null, time, convert);
		}

		public async Task<ToolsPriceConversion> ToolsPriceConversionAsync(string symbol, double amount = 1.0,
			string time = null, List<string> convert = null)
		{
			return await ToolsPriceConversionBase(amount, null, symbol, time, convert);
		}

		public async Task<ToolsPriceConversion> ToolsPriceConversionAsync(string symbol, double amount = 1.0,
			string time = null, string convert = null)
		{
			return await ToolsPriceConversionBase(amount, null, symbol, time, convert==null ? null : new List<string> {convert});
		}

		private async Task<ToolsPriceConversion> ToolsPriceConversionBase(double amount = 1.0, int? id = null,
			string symbol = null, string time = null, List<string> convert = null)
		{
			if (id == null && symbol == null)
				throw new CoinMarketCapException("At least one \"id\" or \"symbol\" is required");
			if (convert == null || convert.Count == 0) convert = new List<string> {"USD"};
			var response = await Request<ToolsPriceConversion>("tools/price-conversion",
				new QueryParams(amount.ToQueryParam("amount"),
					new QueryParams(id.ToQueryParam("id"), symbol.ToQueryParam("symbol")).FirstNotNullParameter(),
					time.ToQueryParam("time"), convert.ToQueryParam("convert")));

			return response;
		}
	}
}
