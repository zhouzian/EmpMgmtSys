using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Extensions;
using PersistenceAccess.Policies;
using PersistenceAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeMgmt
{
    internal class ViewGeneratorHelper : IDisposable
    {
        private EmployeeRepository empRepo;

        public ViewGeneratorHelper(EmployeeRepository empRepo)
        {
            this.empRepo = empRepo;
        }


        public ListViewItem[] GetMainListView(VisibilityParam visibParam)
        {
            IEnumerable<EmployeeDC> allEmp = null;
            allEmp = empRepo.GetAllEmployees();
            List<ListViewItem> ret = new List<ListViewItem>();
            foreach (var empDC in allEmp)
            {
                var subItems = new string[] { empDC.FullName, empDC.Position, empDC.NextReviewDate?.ToShortDateString(), empDC.OnboardDate.ToShortDateString() };
                if (empDC.ResignDate != null)
                {
                    subItems[0] = subItems[0] + " (Resigned)";
                }
                else if (empDC.NextReviewDate == GlobalPolicyContainer.AnnualPerformanceReviewPolicy.GetNextReviewDate())
                {
                    subItems[2] = subItems[2] + " " + '\u26a0';
                }
                var item = new ListViewItem(subItems);
                if (empDC.ResignDate != null)
                {
                    item.ForeColor = Color.Red;
                    item.Font = new Font(item.Font, FontStyle.Strikeout);
                }
                item.Tag = empDC.Id;
                item.Name = empDC.Id.ToString();
                if ((empDC.CurrentTitle == Title.SOFTWARE_ENGINEER && visibParam.showDev) ||
                    ((empDC.CurrentTitle == Title.SOFTWARE_ENGINEER_IN_TEST || empDC.CurrentTitle == Title.SOFTWARE_TEST_ENGINEER) && visibParam.showQa) ||
                    (empDC.CurrentTitle == Title.TECHNICAL_PRODUCT_MANAGER && visibParam.showTpm) ||
                    (empDC.CurrentTitle == Title.TECHNICAL_WRITER && visibParam.showUe))
                {
                    ret.Add(item);
                }
            }
            return ret.ToArray();
        }

        public ListViewItem[] GetHistoryFromEmployeeView(EmployeeDC emp)
        {
            List<ListViewItem> ret = new List<ListViewItem>();
            foreach (var his in emp.History)
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

        public List<ManagerView> GetManagerList()
        {
            IEnumerable<Employee> employees = empRepo.GetAllEmployeesRaw();
            var ret = new List<ManagerView>();
            ret.Add(new ManagerView() { Name = string.Empty, Id = Guid.Empty });
            foreach (var emp in employees)
            {
                var manager = new ManagerView() { Name = emp.FirstName + " " + emp.LastName, Id = emp.Id };
                ret.Add(manager);
            }
            return ret;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    empRepo.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ViewGeneratorHelper()
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
