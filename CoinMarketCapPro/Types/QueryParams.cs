using System.Collections.Generic;

namespace CoinMarketCapPro.Types
{
	public class QueryParams : List<QueryParam>
	{
		public QueryParams()
		{
		}

		public QueryParams(QueryParam[] queryparams) : base(queryparams)
		{
		}

		public QueryParams(QueryParam queryparam) : base(new[] {queryparam})
		{
		}

		public QueryParams(QueryParam queryparam0, QueryParam queryparam1) : base(new[] {queryparam0, queryparam1})
		{
		}

		public QueryParams(QueryParam queryparam0, QueryParam queryparam1, QueryParam queryparam2) : base(new[]
			{queryparam0, queryparam1, queryparam2})
		{
		}

		public QueryParams(QueryParam queryparam0, QueryParam queryparam1, QueryParam queryparam2, QueryParam queryparam3) :
			base(new[] {queryparam0, queryparam1, queryparam2, queryparam3})
		{
		}

		public QueryParams(QueryParam queryparam0, QueryParam queryparam1, QueryParam queryparam2, QueryParam queryparam3,
			QueryParam queryparam4) : base(new[] {queryparam0, queryparam1, queryparam2, queryparam3, queryparam4})
		{
		}

		public QueryParams(QueryParam queryparam0, QueryParam queryparam1, QueryParam queryparam2, QueryParam queryparam3,
			QueryParam queryparam4, QueryParam queryparam5) : base(new[]
			{queryparam0, queryparam1, queryparam2, queryparam3, queryparam4, queryparam5})
		{
		}

		public QueryParams(QueryParam queryparam0, QueryParam queryparam1, QueryParam queryparam2, QueryParam queryparam3,
			QueryParam queryparam4, QueryParam queryparam5, QueryParam queryparam6) : base(new[]
			{queryparam0, queryparam1, queryparam2, queryparam3, queryparam4, queryparam5, queryparam6})
		{
		}

		public QueryParams(QueryParam queryparam0, QueryParam queryparam1, QueryParam queryparam2, QueryParam queryparam3,
			QueryParam queryparam4, QueryParam queryparam5, QueryParam queryparam6, QueryParam queryparam7) : base(new[]
			{queryparam0, queryparam1, queryparam2, queryparam3, queryparam4, queryparam5, queryparam6, queryparam7})
		{
		}

		public QueryParams(QueryParam queryparam0, QueryParam queryparam1, QueryParam queryparam2, QueryParam queryparam3,
			QueryParam queryparam4, QueryParam queryparam5, QueryParam queryparam6, QueryParam queryparam7,
			QueryParam queryparam8) : base(new[]
		{
			queryparam0, queryparam1, queryparam2, queryparam3, queryparam4, queryparam5, queryparam6, queryparam7, queryparam8
		})
		{
		}
	}
}
