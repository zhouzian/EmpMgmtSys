using LiteDB;
using PersistenceAccess.DataContracts;
using PersistenceAccess.Factories;
using PersistenceAccess.Policies;
using PersistenceAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersistenceAccess.Entities
{
    public partial class Employee
    {
        public EmployeeDC ConvertToDataContract(EmployeeRepository empRepo)
        {
            var ret = new EmployeeDC();

            // Safe check since the conversion relies on info in DB
            if (Id == Guid.Empty)
            {
                throw new Exception("Employee must be already persisted in db.");
            }

            ret.Id = Id;
            ret.FirstName = FirstName;
            ret.LastName = LastName;
            ret.Gender = Gender;
            ret.Email = Email;
            ret.OnboardDate = OnboardDate;

            IEnumerable<StatusChangeHistory> histories = empRepo.GetEmployeeHistoryRaw(Id);
            var HistoryList = new List<StatusChangeHistoryDC>();
            foreach (var his in histories)
            {
                HistoryList.Add(his.ConvertToDataContract(empRepo));
            }
            ret.History = HistoryList;

            Guid managerId = ret.History.OrderBy(his => his.Date).Last().ManagerId;
            ret.CurrentManager = managerId == Guid.Empty ? new Employee() { Id = Guid.Empty } : empRepo.GetEmployeeRaw(managerId);
            ret.CurrentTitle = ret.History.OrderBy(his => his.Date).Last().Title;
            ret.CurrentLevel = ret.History.OrderBy(his => his.Date).Last().Level;
            ret.CurrentSalary = ret.History.OrderBy(his => his.Date).Last().Salary;
            ret.ResignDate = ret.History.LastOrDefault(his => his.Action == ActionType.RESIGN)?.Date;

            ret.NextReviewDate = GlobalPolicyContainer.AnnualPerformanceReviewPolicy.GetMyNextReviewDate(ret);
            if (ret.ResignDate == null)
            {
                ret.YearOfEmployment = (int)(DateTime.Now - this.OnboardDate).TotalDays / 365 + 1;
            }
            else
            {
                ret.YearOfEmployment = (int)((DateTime)ret.ResignDate - this.OnboardDate).TotalDays / 365 + 1;
            }

            return ret;
        }
    }
}
