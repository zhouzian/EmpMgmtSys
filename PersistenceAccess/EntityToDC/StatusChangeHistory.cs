using PersistenceAccess.DataContracts;
using PersistenceAccess.Factories;
using PersistenceAccess.Repositories;
using System;

namespace PersistenceAccess.Entities
{
    public partial class StatusChangeHistory
    {
        public StatusChangeHistoryDC ConvertToDataContract(EmployeeRepository empRepo)
        {
            var ret = new StatusChangeHistoryDC();

            ret.Id = Id;
            ret.EmployeeId = EmployeeId;
            ret.Date = Date;
            ret.ManagerId = ManagerId;
            ret.Title = Title;
            ret.Level = Level;
            ret.Salary = Salary;
            ret.Bonus = Bonus;
            ret.Action = Action;

            if (ManagerId != Guid.Empty)
            {
                Employee manager = empRepo.GetEmployeeRaw(ManagerId);
                ret.ManagerName = manager.FirstName + " " + manager.LastName;
            }

            return ret;
        }
    }
}
