using LiteDB;
using PersistenceAccess.Entities;
using PersistenceAccess.Factories;
using System;

namespace PersistenceAccess.DataContracts
{
	public class StatusChangeHistoryDC : StatusChangeHistory
	{
		private StatusChangeHistoryDC() { }

		public StatusChangeHistoryDC(StatusChangeHistory his, LiteDatabase db)
		{
			this.Id = his.Id;
			this.EmployeeId = his.EmployeeId;
			this.Date = his.Date;
			this.ManagerId = his.ManagerId;
			this.Title = his.Title;
			this.Level = his.Level;
			this.Salary = his.Salary;
			this.Bonus = his.Bonus;
			this.Action = his.Action;
			if (his.ManagerId != Guid.Empty)
			{
				Employee manager = PersistenceStore.GetEmployeeStore(db).FindById(his.ManagerId);
				ManagerName = manager.FirstName + " " + manager.LastName;
			}
			else
			{
				ManagerName = string.Empty;
			}
		}
		public string ManagerName { get; private set; }
	}
}
