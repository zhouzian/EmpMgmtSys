using LiteDB;
using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersistenceAccess.Repositories
{
    public class EmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployeesRaw()
        {
            return PersistenceStore.Current.GetEmployeeStore().FindAll();
        }

        public IEnumerable<EmployeeDC> GetAllEmployees()
        {
            IEnumerable<Employee> employees = GetAllEmployeesRaw();
            var ret = new List<EmployeeDC>();
            foreach (Employee emp in employees)
            {
                ret.Add(emp.ConvertToDataContract(this));
            }
            return ret.OrderBy(emp => emp.NextReviewDate).ThenBy(emp => emp.OnboardDate);
        }

        public Employee GetEmployeeRaw(Guid id)
        {
            return PersistenceStore.Current.GetEmployeeStore().FindById(id);
        }

        public EmployeeDC GetEmployee(Guid id)
        {
            return GetEmployeeRaw(id).ConvertToDataContract(this);
        }

        public IEnumerable<StatusChangeHistory> GetEmployeeHistoryRaw(Guid id)
        {
            return PersistenceStore.Current.GetHistoryStore().Find(Query.EQ("employee_id", id)).OrderBy(his => his.Date);
        }

        public EmployeeDC CreateEmployee(Guid managerId, string firstName, string lastName, Gender gender, string email, Title title, Level level, decimal salary, decimal bonus, DateTime onboardDate)
        {
            var manager = managerId == Guid.Empty ? new Employee() { Id = Guid.Empty } : PersistenceStore.Current.GetEmployeeStore().FindById(managerId);
            return EmployeeFactory.CreateEmployee(firstName, lastName, gender, email, manager, title, level, salary, bonus, onboardDate).ConvertToDataContract(this);
        }

        public void CreateEmployeeHistory(Guid employeeId, Guid managerId, Title title, Level level, Decimal salary, Decimal bonus, ActionType action, DateTime date)
        {
            LiteCollection<Employee> employees = PersistenceStore.Current.GetEmployeeStore();
            var employee = employees.FindById(employeeId);
            var manager = managerId == Guid.Empty ? new Employee() { Id = Guid.Empty } : employees.FindById(managerId);
            HistoryFactory.CreateHistory(employee, manager, title, level, salary, bonus, action, date);
        }

        public void UpdateEmployeeGeneralInfo(Guid id, string firstName, string lastName, Gender gender, string email, DateTime onboard)
        {
            LiteCollection<Employee> employees = PersistenceStore.Current.GetEmployeeStore();
            EmployeeFactory.UpdateEmployeeInfo(employees.FindById(id), firstName, lastName, gender, email, onboard);
        }

        #region Test data
        private static Random random = new Random();
        private static Array genders = Enum.GetValues(typeof(Gender));
        private static Array titles = Enum.GetValues(typeof(Title));
        private static Array levels = Enum.GetValues(typeof(Level));
        private static Array firstNames = new string[] { "Tom", "Peter", "Michael", "Jared", "Robert", "William", "Greg", "Edward", "Karl", "Andrew", "David", "James", "Eveline", "Chris", "John", "Mary" };
        private static Array lastNames = new string[] { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", "Lopez", "Hernandez", "Wilson", "Anderson", "Thomas", "Lee", "Perez", "White", "Clark", "Sanchez" };
        public void SeedDB()
        {
            using (var db = new LiteDatabase(Constants.DB_NAME))
            {
                //clean up
                IEnumerable<string> collectionNames = db.GetCollectionNames().ToList();
                foreach (string collectionName in collectionNames)
                {
                    db.DropCollection(collectionName);
                }
            }

            //setup test data
            Employee nextMgr = new Employee() { Id = Guid.Empty };
            for (int i = 0; i < 99; i++)
            {
                FakeName fname = GetAName();
                DateTime onboardDate = DateTime.Now.AddMonths(random.Next(-100, -12));
                DateTime recentPerfReviewDate = new DateTime(DateTime.Now.Year - 1, onboardDate.Month, 1);
                Employee theNextMgr = EmployeeFactory.CreateEmployee(fname.FirstName, fname.LastName, (Gender)GetValue(genders), fname.Email, nextMgr, (Title)GetValue(titles), (Level)GetValue(levels), random.Next(50000, 200000), random.Next(0, 10000), onboardDate);
                HistoryFactory.CreateHistory(theNextMgr, nextMgr, (Title)GetValue(titles), (Level)GetValue(levels), random.Next(50000, 200000), random.Next(0, 10000), ActionType.ANNUAL_PERFORMANCE_REVIEW, recentPerfReviewDate);
                nextMgr = theNextMgr;
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
    }
}
