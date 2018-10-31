using PersistenceAccess.DataContracts;
using System;

namespace PersistenceAccess.Policies
{
	public interface IPerformancReviewPolicy
	{
		/// <summary>
		/// Calculate the next performance review date for the specific employee per orgnization's review policy
		/// </summary>
		/// <param name="emp"></param>
		/// <returns>Returns null if the employee is already resigned/returns>
		DateTime? GetMyNextReviewDate(EmployeeDC emp);

		/// <summary>
		/// Returns the orgnization wide performance review date.
		/// </summary>
		/// <returns></returns>
		DateTime GetNextReviewDate();
	}
}
