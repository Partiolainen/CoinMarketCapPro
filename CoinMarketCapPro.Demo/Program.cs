using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCapPro.Types;
using CoinMarketCapPro.Types.QueryParamTypes;

namespace CoinMarketCapPro.Demo
{
	internal static class Program
	{
		private static async Task Main()
		{
			//var apikey = ""; // <-- Your API Key here   
			var apikey = System.IO.File.ReadAllLines($"{Environment.CurrentDirectory}\\ApiKey.txt")[0];

			var client = new CoinMarketCapClient(ApiSchema.Sandbox, apikey);

			var a = await client.GetCurrencyInfoAsync(new List<string> {"BTC", "ETH", "LTC"});
			$"Full names of BTC, ETH and LTC codes: {string.Join(", ", a.Data.Select(x => x.Value.Name))}".ToConsoleNotify();

			var b = await client.GetCurrencyInfoAsync(87);
			$"Name of currency with id #87: {b.Data.FirstOrDefault().Value.Name}".ToConsoleNotify();

			var c = await client.GetCurrencyMapAsync(ParamListingStatus.Active, 1, 20,
				new List<string> {"BTC", "ETH", "ETC", "ZEC"});
			$"Slug of BTC, ETH, ETC and ZEC: {string.Join(", ", c.Data.Select(x=>x.Slug))}".ToConsoleNotify();

			//Not implemented by CoinMarketCap
			//var d = await client.GetCurrencyListingsHistoricalAsync("2018-08-01");
			//$"Coin with rank #9 on 01/08/2018: {d.Data.FirstOrDefault(x => x.CmcRank == 9)?.Name}".ToConsoleNotify();

			var e = await client.GetCurrencyListingsAsync();
			$"Coin with rank #9 now: {e.Data.FirstOrDefault(x => x.CmcRank == 9)?.Name}".ToConsoleNotify();

			var f = await client.GetCurrencyMarketPairsAsync(2, limit: 5000);
			$"Count of market pairs with coin {f.Data.Name}: {f.Data.NumMarketPairs}".ToConsoleNotify();

			var g = await client.GetCurrencyMarketOHLCVHistoricalAsync(1, time_start: "2018-08-01", time_end: "2018-08-09",
				convert: new List<string> {Fiat.EUR.ToString()});
			$"BTC highest price in EUR between 01/08/2018 and 09/08/2018: {g.Data.Quotes.Select(z => z.Quote).Select(x => x.GetValueOrDefault("EUR")).Max(x => x.High)}".ToConsoleNotify();

			var h = await client.GetCurrencyMarketQuotesHistoricalAsync(1, time_start: "2018-08-01", time_end: "2018-08-09");
			$"BTC highest daily volume in USD between 01/08/2018 and 09/08/2018: {h.Data.Quotes.Select(z => z.Quote).Select(x => x.GetValueOrDefault("USD")).Max(x => x.Volume24h)}".ToConsoleNotify();

			var j = await client.GetCurrencyMarketQuotesAsync(new List<int> {1});
			$"BTC average price in USD: {j.Data.Values.Select(z=>z.Quote).Select(x=>x.GetValueOrDefault("USD")).FirstOrDefault()?.Price}".ToConsoleNotify();

			var i = await client.GetExchangeInfoAsync(new List<string> {"bittrex"});
			$"Bittrex twitter: {i.Data.Values.FirstOrDefault()?.Urls.Twitter.FirstOrDefault()}".ToConsoleNotify();

			var k = await client.GetExchangeMapAsync();
			$"Exchange with id #24: {k.Data.FirstOrDefault(x=>x.Id==24)?.Name}".ToConsoleNotify();

			//"Not implemented by CoinMarketCap
			//var l = await client.GetExchangeListingsHistoriacalAsync("2018-08-01", market_type: MarketType.All, limit:1);
			//$"Top volume exchange on 01/08/2018: {l.}".ToConsoleNotify();

			var m = await client.GetExchangeListingsAsync(limit: 100, market_type: MarketType.All);
			$"Top volume exchange now: {m.Data.FirstOrDefault()?.Name}".ToConsoleNotify();

			var n = await client.GetExchangeMarketPairsAsync(m.Data.First().Id);
			$"Top pair of top market: {n.Data.MarketPairs.OrderByDescending(z=>z.Quote.Values.FirstOrDefault()?.Volume24hBase).FirstOrDefault()?.MarketPair}".ToConsoleNotify();

			var o = await client.ExchangeMarketQuotesHistoricalAsync(270, "2018-08-01", "2018-08-09", interval: ParamInterval.D1);
			$"Binance average daily volume on period between 01/08/2018 and 09/08/2018: {o.ExchangeMarketQuotesHistoricalData.Quotes.Average(z => z.Quote.Values.FirstOrDefault()?.Volume24h)}"
				.ToConsoleNotify();

			var p = await client.ExchangeMarketQuotesAsync(new List<int> {270});
			$"Binance volume now: {p.Data.FirstOrDefault().Value.Quote.FirstOrDefault().Value.Volume24h}".ToConsoleNotify();

			var q = await client.GlobalMetricsQuotesHistoricalAsync("2018-08-01", "2018-08-09");
			$"Average BTC dominance on perid between 01/08/2018 and 09/08/2018: {q.Data.Quotes.Average(x=>x.BtcDominance)}".ToConsoleNotify();

			var r = await client.GlobalMetricsQuotesAsync();
			$"BTC dominance now: {r.Data.BtcDominance}".ToConsoleNotify();

			var s = await client.ToolsPriceConversionAsync("ZEC", 1, convert: new List<string> {"BTC"});
			$"1.0 ZEC = {s.Data.Quote.FirstOrDefault().Value.Price} BTC".ToConsoleNotify();

			Console.ReadKey();
		}

		private static void ToConsoleNotify(this string message)
		{
			Console.WriteLine($"[{DateTime.Now:G}] {message}");
		}
	}
}
