using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersistenceAccess.Repositories
{
    public class AnalyticsRepository
    {
        public AnalyticsDC GetAnaltyics(EmployeeRepository empRepo)
        {
            IEnumerable<Employee> employees = PersistenceStore.Current.GetEmployeeStore().FindAll();
            List<EmployeeDC> source = new List<EmployeeDC>();
            foreach (var emp in employees)
            {
                EmployeeDC DC = emp.ConvertToDataContract(empRepo);
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

        private LevelStatisticDC GetStatisticByTitle(string title, List<EmployeeDC> source)
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
    }
}
