using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenceAccess.DataContracts;

namespace PersistenceAccess.Policies
{
	/// <summary>
	/// Quarter based performance review policy
	/// There is a performance review in the first month of each quater. Depending on the onboard date of the employee, each employee
	/// joins one of the performance review (among totally 4 every year) as the annual performance reivew. The policy enforce the annual
	/// performance review to be conducted in the next quater after the initial onboard date.
	/// Example:
	/// John's onboard date id Jan 12 2017. His onboard date falls in Q1 2017. Hence his next annual performance review will happen in
	/// April 2018.
	/// The specific performance review policy does not enformce the actual date of review, as long as the review is conducted during that
	/// month.
	/// </summary>
	public class QuarterBasedPerformanceReviewPolicy : IPerformancReviewPolicy
	{
		/// <summary>
		/// It takes the baseline from the onboard date or the previous review date, to calculate the next review date based on the policy.
		/// </summary>
		/// <param name="emp"></param>
		/// <returns></returns>
		public DateTime? GetMyNextReviewDate(EmployeeDC emp)
		{
			if (emp.ResignDate != null)
			{
				return null;
			}
			StatusChangeHistoryDC lastPerformanceReview = emp.History.LastOrDefault(his => his.Action == Entities.ActionType.ANNUAL_PERFORMANCE_REVIEW);
			if (lastPerformanceReview == null)
			{
				// New employee
				int reviewMonth = 1;
				int reviewYear = emp.OnboardDate.Year + 1;
				switch (emp.OnboardDate.Month)
				{
					case 1:
					case 2:
					case 3:
						reviewMonth = 4;
						break;
					case 4:
					case 5:
					case 6:
						reviewMonth = 7;
						break;
					case 7:
					case 8:
					case 9:
						reviewMonth = 10;
						break;
					case 10:
					case 11:
					case 12:
						reviewMonth = 1;
						reviewYear++;
						break;
				}
				return new DateTime(reviewYear, reviewMonth, 1);
			}
			else
			{
				// Employee with at least one previous annual performance review.
				if (new int[] { 1, 4, 7, 10 }.Contains(lastPerformanceReview.Date.Month))
				{
					// The review was conducted on time last year
					return new DateTime(lastPerformanceReview.Date.Year + 1, lastPerformanceReview.Date.Month, 1);
				}
				else
				{
					// The review wasn't on time, so that we have to calculate the next review based on onboard date.
					int reviewMonth = 1;
					int reviewYear = lastPerformanceReview.Date.Year + 1;
					switch (emp.OnboardDate.Month)
					{
						case 1:
						case 2:
						case 3:
							reviewMonth = 4;
							break;
						case 4:
						case 5:
						case 6:
							reviewMonth = 7;
							break;
						case 7:
						case 8:
						case 9:
							reviewMonth = 10;
							break;
						case 10:
						case 11:
						case 12:
							reviewMonth = 1;
							break;
					}
					return new DateTime(reviewYear, reviewMonth, 1);
				}
			}
		}

		/// <summary>
		/// Based on Datetime.Now:
		/// From Feb 1st to Apr 30th, the next review date is Apr 1st.
		/// From May 1st to July 31st, the next review date is july 1st.
		/// From Aug 1st to Oct 31st, the next review date is Oct 1st.
		/// From Nov 1st to next year Jan 31st, the next review date is Jan 1st.
		/// All salary, bonus changes will be effective at the end of the review month.
		/// </summary>
		/// <returns></returns>
		public DateTime GetNextReviewDate()
		{
			int year = DateTime.Now.Year;
			int month = DateTime.Now.Month;

			int reviewYear = year;
			int reviewMonth = month;

			switch (month)
			{
				case 2:
				case 3:
				case 4:
					reviewMonth = 4;
					break;
				case 5:
				case 6:
				case 7:
					reviewMonth = 7;
					break;
				case 8:
				case 9:
				case 10:
					reviewMonth = 10;
					break;
				case 11:
				case 12:
					reviewMonth = 1;
					reviewYear = year + 1;
					break;
				case 1:
					reviewMonth = 1;
					break;
			}

			return new DateTime(reviewYear, reviewMonth, 1);
		}
	}
}
