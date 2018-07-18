using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenceAccess.DataContracts;

namespace PersistenceAccess.Policies
{
	/// <summary>
	/// A very basic performance review policy that everyone is reviewed at the end of the year.
	/// If an employee joins after 6/30, the current year performance review is not applicable.
	/// </summary>
	public class BasicPerformanceReviewPolicy : IPerformancReviewPolicy
	{
		public DateTime? GetMyNextReviewDate(EmployeeDC emp)
		{
			if (emp.ResignDate != null)
			{
				return null;
			}
			StatusChangeHistoryDC lastPerformanceReview = emp.History.LastOrDefault(his => his.Action == Entities.ActionType.ANNUAL_PERFORMANCE_REVIEW);
			if (lastPerformanceReview == null)
			{
				if (emp.OnboardDate.Month <=6)
				{
					return GetNextReviewDate();
				}
				else
				{
					return GetNextReviewDate().AddYears(1);
				}
			}
			else
			{
				return GetNextReviewDate();
			}
		}

		public DateTime GetNextReviewDate()
		{
			return new DateTime(DateTime.Now.Year, 12, 31);
		}
	}
}
