using LiteDB;
using PersistenceAccess.Entities;
using PersistenceAccess.Factories;
using PersistenceAccess.Policies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersistenceAccess.DataContracts
{
	public class EmployeeDC : Employee
	{
		private EmployeeDC() { }

		public EmployeeDC(Employee emp, LiteDatabase db)
		{
			if (emp.Id == Guid.Empty)
			{
				throw new Exception("Employee must be already persisted in db.");
			}

			// copy Employee properties
			Id = emp.Id;
			FirstName = emp.FirstName;
			LastName = emp.LastName;
			Gender = emp.Gender;
			Email = emp.Email;
			OnboardDate = emp.OnboardDate;

			// populate full history
			var histories = PersistenceStore.GetHistoryStore(db).Find(Query.EQ("employee_id", Id)).OrderBy(his => his.Date);
			var HistoryList = new List<StatusChangeHistoryDC>();
			foreach(var his in histories)
			{
				HistoryList.Add(new StatusChangeHistoryDC(his, db));
			}
			History = HistoryList;

			// find most recent properties including title, level, salary and manager
			Guid managerId = History.OrderBy(his => his.Date).Last().ManagerId;
			CurrentManager = managerId == Guid.Empty ?  new Employee() { Id = Guid.Empty } : PersistenceStore.GetEmployeeStore(db).FindById(managerId);
			CurrentTitle = History.OrderBy(his => his.Date).Last().Title;
			CurrentLevel = History.OrderBy(his => his.Date).Last().Level;
			CurrentSalary = History.OrderBy(his => his.Date).Last().Salary;
			ResignDate = History.LastOrDefault(his => his.Action == ActionType.RESIGN)?.Date;

			// populate performance review lated info
			NextReviewDate = GlobalPolicyContainer.AnnualPerformanceReviewPolicy.GetMyNextReviewDate(this);
			if (this.ResignDate == null)
			{
				YearOfEmployment = (int)(DateTime.Now - this.OnboardDate).TotalDays / 365 + 1;
			}
			else
			{
				YearOfEmployment = (int)((DateTime)this.ResignDate - this.OnboardDate).TotalDays / 365 + 1;
			}
		}

		public Employee CurrentManager { get; private set; }

		public Title CurrentTitle { get; private set; }

		public Level CurrentLevel { get; private set; }

		public Decimal CurrentSalary { get; private set; }

		public DateTime? ResignDate { get; private set; }

		public IEnumerable<StatusChangeHistoryDC> History { get; private set; }

		public string ManagerName {
			get
			{
				if (CurrentManager.Id == Guid.Empty)
				{
					return string.Empty;
				}
				else
				{
					return CurrentManager.FirstName + " " + CurrentManager.LastName;
				}
			}
		}

		public string SelfName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}

		/// <summary>
		/// Returns the next annual performance review date. The date is populated in the constructor when an Employee object is passed in.
		/// </summary>
		public DateTime? NextReviewDate { get; private set; }

		public int YearOfEmployment { get; private set; }
	}
}
