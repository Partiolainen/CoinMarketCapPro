using System;

namespace CoinMarketCapPro.Types
{
	public class CoinMarketCapException : Exception
	{
		public CoinMarketCapException()
		{ } 

		public CoinMarketCapException(string message) :base(message) { }
	}
}
