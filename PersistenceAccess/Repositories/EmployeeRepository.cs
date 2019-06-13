using LiteDB;
using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceAccess.Repositories
{
    public class EmployeeRepository : IDisposable
    {
        private readonly LiteDatabase db;

        public EmployeeRepository()
        {
            this.db = new LiteDatabase(Constants.DB_NAME);
        }

        public EmployeeRepository(LiteDatabase db)
        {
            this.db = db;
        }

        public IEnumerable<EmployeeDC> GetAllEmployees(bool includeResigned = true)
        {
            IEnumerable<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME).FindAll().OrderBy(emp => emp.OnboardDate);
            var ret = new List<EmployeeDC>();
            foreach(Employee emp in employees)
            {
                var empDC = new EmployeeDC(emp, db);
                ret.Add(empDC);
            }
            if (!includeResigned)
            {
                ret = ret.Where(emp => emp.ResignDate != null).ToList();
            }
            return ret;
        }

        public IEnumerable<Employee> GetAllEmployeesRaw()
        {
            return db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME).FindAll();
        }

        public EmployeeDC GetEmployee(Guid id)
        {
            LiteCollection<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
            return new EmployeeDC(employees.FindById(id), db);
        }

        public EmployeeDC CreateEmployee(Guid managerId, string firstName, string lastName, Gender gender, string email, Title title, Level level, decimal salary, decimal bonus, DateTime onboardDate)
        {
            LiteCollection<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
            var manager = managerId == Guid.Empty ? new Employee() { Id = Guid.Empty } : employees.FindById(managerId);
            return new EmployeeDC(EmployeeFactory.CreateEmployee(db, firstName, lastName, gender, email, manager, title, level, salary, bonus, onboardDate), db);
        }

        public void CreateEmployeeHistory(Guid employeeId, Guid managerId, Title title, Level level, Decimal salary, Decimal bonus, ActionType action, DateTime date)
        {
            LiteCollection<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
            var employee = employees.FindById(employeeId);
            var manager = managerId == Guid.Empty ? new Employee() { Id = Guid.Empty } : employees.FindById(managerId);
            HistoryFactory.CreateHistory(db, employee, manager, title, level, salary, bonus, action, date);
        }

        public void UpdateEmployeeGeneralInfo(Guid id, string firstName, string lastName, Gender gender, string email, DateTime onboard)
        {
            LiteCollection<Employee> employees = db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
            EmployeeFactory.UpdateEmployeeInfo(db, employees.FindById(id), firstName, lastName, gender, email, onboard);
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

                //setup test data
                Employee nextMgr = new Employee() { Id = Guid.Empty };
                for (int i = 0; i < 99; i++)
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EmployeeRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
