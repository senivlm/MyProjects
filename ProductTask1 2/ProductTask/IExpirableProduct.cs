using System;

namespace ProductProject
{
    public interface IExpirableProduct
    {
		public DateTime TimeToExpire { get; }
		public bool IsExpired();
	}
}

