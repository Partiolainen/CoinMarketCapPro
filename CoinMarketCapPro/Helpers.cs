using System.Collections.Generic;
using System.Linq;
using CoinMarketCapPro.Types;
using CoinMarketCapPro.Types.QueryParamTypes;

namespace CoinMarketCapPro
{
	public static class Helpers
	{
		public static QueryParam ToQueryParam(this List<string> value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this List<int> value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this int? value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this int value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this ParamListingStatus value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this string value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this double value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this SortBy value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this SortDirection value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this CryptocurrencyType value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		public static QueryParam ToQueryParam(this MarketType value, string param_name)
		{
			return new QueryParam(param_name, value);
		}
		//public static QueryParam ToQueryParam(this object value, string param_name)
		//{
		//	return new QueryParam(param_name, value);
		//}
		public static QueryParam FirstNotNullParameter(this QueryParams query_params)
		{
			return query_params.FirstOrDefault(x => x.Value != null);
		}
		public static string ToValue(this SortBy value)
		{
			return value.ToString().ToLower();
		}
		public static string ToValue(this SortDirection value)
		{
			return value.ToString().ToLower();
		}
		public static string ToValue(this ParamListingStatus value)
		{
			return value.ToString().ToLower();
		}
		public static string ToValue(this CryptocurrencyType value)
		{
			return value.ToString().ToLower();
		}
		public static string ToValue(this MarketType value)
		{
			return value.ToString().ToLower();
		}
	}
}
