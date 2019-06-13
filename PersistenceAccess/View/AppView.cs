using LiteDB;
using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Extensions;
using PersistenceAccess.Factories;
using PersistenceAccess.Policies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PersistenceAccess.View
{
	public class AppView
	{
		#region Test data
		private static Random random = new Random();
		private static Array genders = Enum.GetValues(typeof(Gender));
		private static Array titles = Enum.GetValues(typeof(Title));
		private static Array levels = Enum.GetValues(typeof(Level));
		private static Array firstNames = new string[] { "Tom", "Peter", "Michael", "Jared", "Robert", "William", "Greg", "Edward", "Karl", "Andrew", "David", "James", "Eveline", "Chris", "John", "Mary" };
		private static Array lastNames = new string[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Lopez", "Hernandez", "Wilson", "Anderson", "Thomas", "Lee", "Perez", "White", "Clark", "Sanchez" };
		public static void SeedDB()
		{
			using (var db = new LiteDatabase(Constants.DB_NAME))
			{
				//clean up
				IEnumerable<string> collectionNames = db.GetCollectionNames().ToList();
				foreach (string collectionName in collectionNames)
				{
					db.DropCollection(collectionName);
				}
				
				//setup test data
				Employee nextMgr = new Employee() { Id = Guid.Empty };
				for(int i = 0; i < 99; i++)
				{
					FakeName fname = GetAName();
					Employee theNextMgr = EmployeeFactory.CreateEmployee(db, fname.FirstName, fname.LastName, (Gender)GetValue(genders), fname.Email, nextMgr, (Title)GetValue(titles), (Level)GetValue(levels), random.Next(50000, 200000), random.Next(0, 10000), DateTime.Now.AddMonths(-3));
					HistoryFactory.CreateHistory(db, theNextMgr, nextMgr, (Title)GetValue(titles), (Level)GetValue(levels), random.Next(50000, 200000), random.Next(0, 10000), ActionType.ANNUAL_PERFORMANCE_REVIEW, DateTime.Now);
					nextMgr = theNextMgr;
				}
				//validation
			}
		}

		private struct FakeName
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Email
			{
				get
				{
					return FirstName.ToLower() + "." + LastName.ToLower() + "@fakeemail.com";
				}
			}
		}

		private static FakeName GetAName()
		{
			string firstName = (string)firstNames.GetValue(random.Next(firstNames.Length));
			string lastName = (string)lastNames.GetValue(random.Next(lastNames.Length));
			return new FakeName() { FirstName = firstName, LastName = lastName };
		}

		private static object GetValue(Array enumArray)
		{
			return enumArray.GetValue(random.Next(enumArray.Length));
		}

		#endregion

		public static ListViewItem[] GetMainListView(VisibilityParam visibParam)
		{
			using (var db = new LiteDatabase(Constants.DB_NAME))
			{
				IEnumerable<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME).FindAll().OrderBy(emp => emp.OnboardDate);
				List<ListViewItem> ret = new List<ListViewItem>();
				foreach(var emp in employees)
				{
					var empDC = new EmployeeDC(emp, db);
					var subItems = new string[] { empDC.SelfName, empDC.Email, empDC.OnboardDate.ToShortDateString(), empDC.NextReviewDate?.ToShortDateString() };
					if (empDC.ResignDate != null)
					{
						subItems[0] = subItems[0] + " (Resigned)";
					}
					else if (empDC.NextReviewDate == GlobalPolicyContainer.AnnualPerformanceReviewPolicy.GetNextReviewDate())
					{
						subItems[3] = '\u26a0' + " " + subItems[3];
					}
					var item = new ListViewItem(subItems);
					if (empDC.ResignDate != null)
					{
						item.ForeColor = Color.Red;
						item.Font = new Font(item.Font, FontStyle.Strikeout);
					}
					item.Tag = emp.Id;
					item.Name = emp.Id.ToString();
					if ((empDC.CurrentTitle == Title.SOFTWARE_ENGINEER && visibParam.showDev) ||
						((empDC.CurrentTitle == Title.SOFTWARE_ENGINEER_IN_TEST || empDC.CurrentTitle == Title.SOFTWARE_TEST_ENGINEER) && visibParam.showQa) ||
						(empDC.CurrentTitle == Title.TECHNICAL_PRODUCT_MANAGER && visibParam.showTpm) ||
						(empDC.CurrentTitle == Title.TECHNICAL_WRITER && visibParam.showUe))
					ret.Add(item);
				}
				return ret.ToArray();
			}
		}

		public struct VisibilityParam
		{
			public bool showDev;
			public bool showQa;
			public bool showTpm;
			public bool showUe;
		}

		public static ListViewItem[] GetHistoryFromEmployeeView(EmployeeDC emp)
		{
			List<ListViewItem> ret = new List<ListViewItem>();
			foreach(var his in emp.History)
			{
				string title = his.Title.GetDisplayName();
				string level = his.Level.GetDisplayName();
				string salary = his.Salary.ToString("C0");
				string bonus = his.Bonus.ToString("C0");
				string manager = his.ManagerName;
				var item = new ListViewItem(new string[] { his.Date.ToShortDateString(), title, level, salary, bonus, manager, his.Action.GetDisplayName() });
				item.Tag = his.Id;
				ret.Add(item);
			}
			return ret.ToArray();
		}

		public static EmployeeDC GetEmployee(Guid id)
		{
			using (var db = new LiteDatabase(Constants.DB_NAME))
			{
				LiteCollection<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
				return new EmployeeDC(employees.FindById(id), db);
			}
		}

		public static void UpdateEmployeeGeneralInfo(Guid id, string firstName, string lastName, Gender gender, string email, DateTime onboard)
		{
			using (var db = new LiteDatabase(Constants.DB_NAME))
			{
				LiteCollection<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
				EmployeeFactory.UpdateEmployeeInfo(db, employees.FindById(id), firstName, lastName, gender, email, onboard);
			}
		}

		public static List<ManagerView> GetManagerList()
		{
			using (var db = new LiteDatabase(Constants.DB_NAME))
			{
				IEnumerable<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME).FindAll();
				var ret = new List<ManagerView>();
				ret.Add(new ManagerView() { Name = string.Empty, Id = Guid.Empty });
				foreach (var emp in employees)
				{
					var manager = new ManagerView() { Name = emp.FirstName + " " + emp.LastName, Id = emp.Id };
					ret.Add(manager);
				}
				return ret;
			}
		}

		public static EmployeeDC CreateEmployee(Guid managerId, string firstName, string lastName, Gender gender, string email, Title title, Level level, decimal salary, decimal bonus, DateTime onboardDate)
		{
			using (var db = new LiteDatabase(Constants.DB_NAME))
			{
				LiteCollection<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
				var manager = managerId == Guid.Empty ? new Employee() { Id = Guid.Empty } : employees.FindById(managerId);
				return new EmployeeDC(EmployeeFactory.CreateEmployee(db, firstName, lastName, gender, email, manager, title, level, salary, bonus, onboardDate), db);
			}
		}

		public static void CreateEmployeeHistory(Guid employeeId, Guid managerId, Title title, Level level, Decimal salary, Decimal bonus, ActionType action, DateTime date)
		{
			using (var db = new LiteDatabase(Constants.DB_NAME))
			{
				LiteCollection<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
				var employee = employees.FindById(employeeId);
				var manager = managerId == Guid.Empty ? new Employee() { Id = Guid.Empty } : employees.FindById(managerId);
				HistoryFactory.CreateHistory(db, employee, manager, title, level, salary, bonus, action, date);
			}
		}

		public static AnalyticsDC GetAnaltyics()
		{
			using (var db = new LiteDatabase(Constants.DB_NAME))
			{
				IEnumerable<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME).FindAll();
				List<EmployeeDC> source = new List<EmployeeDC>();
				foreach(var emp in employees)
				{
					var DC = new EmployeeDC(emp, db);
					if (DC.ResignDate == null)
					{
						source.Add(DC);
					}
				}
				AnalyticsDC ret = new AnalyticsDC();

				ret.TotalActiveEmployeeStatistic = (StatisticDC)GetStatisticByTitle(null, source);
				ret.DEVStatistic = GetStatisticByTitle("DEV", source);
				ret.QAStatistic = GetStatisticByTitle("QA", source);
				ret.TPMStatistic = GetStatisticByTitle("TPM", source);
				ret.UEStatistic = GetStatisticByTitle("UE", source);

				return ret;
			}
		}

		private static LevelStatisticDC GetStatisticByTitle(string title, List<EmployeeDC> source)
		{
			var ret = new LevelStatisticDC();
			Func<EmployeeDC, bool> condition = null;
			switch (title)
			{
				case "DEV":
					condition = emp => emp.CurrentTitle == Title.SOFTWARE_ENGINEER;
					break;
				case "QA":
					condition = emp => emp.CurrentTitle == Title.SOFTWARE_ENGINEER_IN_TEST || emp.CurrentTitle == Title.SOFTWARE_TEST_ENGINEER;
					break;
				case "TPM":
					condition = emp => emp.CurrentTitle == Title.TECHNICAL_PRODUCT_MANAGER;
					break;
				case "UE":
					condition = emp => emp.CurrentTitle == Title.TECHNICAL_WRITER;
					break;
				default:
					condition = emp => true;
					break;
			}
			ret.Count = source.Where(condition).Count();
			if (ret.Count != 0)
			{
				ret.Total = (decimal)source.Where(condition).Sum(s => s.CurrentSalary);
				ret.Average = (decimal)source.Where(condition).Average(s => s.CurrentSalary);
				ret.Max = (decimal)source.Where(condition).Max(s => s.CurrentSalary);
				ret.Min = (decimal)source.Where(condition).Min(s => s.CurrentSalary);
			}
			ret.None_Count = source.Where(condition).Where(s => s.CurrentLevel == Level.NONE).Count();
			ret.I_Count = source.Where(condition).Where(s => s.CurrentLevel == Level.I).Count();
			ret.II_Count = source.Where(condition).Where(s => s.CurrentLevel == Level.II).Count();
			ret.III_Count = source.Where(condition).Where(s => s.CurrentLevel == Level.III).Count();
			ret.Senior_Count = source.Where(condition).Where(s => s.CurrentLevel == Level.SENIOR).Count();
			ret.Staff_Count = source.Where(condition).Where(s => s.CurrentLevel == Level.STAFF).Count();
            ret.Senior_Staff_Count = source.Where(condition).Where(s => s.CurrentLevel == Level.SENIOR_STAFF).Count();
            ret.Principle_Count = source.Where(condition).Where(s => s.CurrentLevel == Level.PRINCIPLE).Count();

			return ret;
		}

		public class ManagerView
		{
			public string Name { get; set; }
			public Guid Id { get; set; }
		}
	}
}
