using LiteDB;
using PersistenceAccess.Entities;
using System;

namespace PersistenceAccess.Factories
{
	public class HistoryFactory
	{
		public static StatusChangeHistory CreateHistory(LiteDatabase db, Employee currentEmployee, Employee manager, Title title, Level level, Decimal salary, Decimal bonus, ActionType action, DateTime date)
		{
			if (currentEmployee.Id == Guid.Empty)
			{
				throw new Exception("History cannot exist without employee.");
			}
			StatusChangeHistory ret = null;
			try
			{
				var onboardHistory = new StatusChangeHistory()
				{
					EmployeeId = currentEmployee.Id,
					ManagerId = manager.Id,
					Date = date,
					Title = title,
					Level = level,
					Salary = salary,
					Bonus = bonus,
					Action = action
				};
				Persistence.GetHistoryStore(db).Insert(onboardHistory);
				ret = onboardHistory;
			}
			catch (Exception ex)
			{
				throw new Exception("Failed to create new history.", ex);
			}
			return ret;
		}
	}
}
