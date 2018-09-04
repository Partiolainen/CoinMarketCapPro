using System.Collections.Generic;
using CoinMarketCapPro.Types.QueryParamTypes;

namespace CoinMarketCapPro.Types
{
	public class QueryParam
	{
		public QueryParam(string name, string value)
		{
			Name = name;
			Value = value;
		}
		public QueryParam(string name, int? value)
		{
			Name = name;
			Value = value==null ? null : value.ToString();
		}
		public QueryParam(string name, double? value)
		{
			Name = name;
			Value = value == null ? null : value.ToString();
		}
		public QueryParam(string name, List<string> value)
		{
			Name = name;
			Value = value == null ? null : string.Join(",", value);
		}
		public QueryParam(string name, List<int> value)
		{
			Name = name;
			Value = value == null ? null : string.Join(",", value);
		}

		public QueryParam(string name, ParamListingStatus value)
		{
			Name = name;
			Value = value.ToValue();
		}
		public QueryParam(string name, SortBy value)
		{
			Name = name;
			Value = value.ToValue();
		}
		public QueryParam(string name, SortDirection value)
		{
			Name = name;
			Value = value.ToValue();
		}
		public QueryParam(string name, CryptocurrencyType value)
		{
			Name = name;
			Value = value.ToValue();
		}
		public QueryParam(string name, MarketType value)
		{
			Name = name;
			Value = value.ToValue();
		}
		//public QueryParam(string name, object value)
		//{
		//	Name = name;
		//	Value = value.ToString();
		//}
		public string Name { get; set; }

		public string Value { get; set; }
	}
}
