using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceAccess.Policies
{
	/// <summary>
	/// Global configuration for various policies. Each policy instance is shared and only being created here.
	/// </summary>
	public static class GlobalPolicyContainer
	{
		public static IPerformancReviewPolicy AnnualPerformanceReviewPolicy = new QuarterBasedPerformanceReviewPolicy();
	}
}
