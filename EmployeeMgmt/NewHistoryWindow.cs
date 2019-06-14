using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Extensions;
using PersistenceAccess.Repositories;
using System;
using System.Windows.Forms;

namespace EmployeeMgmt
{
	public partial class NewHistoryWindow : Form
	{
		public Guid currentEmployeeId;
		public Title currentEmployeeTitle;
        private EmployeeRepository empRepo;
        private ViewGeneratorHelper viewHelper;


        public NewHistoryWindow(EmployeeDC emp)
		{
            empRepo = new EmployeeRepository();
            viewHelper = new ViewGeneratorHelper(empRepo);
            InitializeComponent();
			InitializeState();
			this.currentEmployeeId = emp.Id;
			this.title.SelectedItem = emp.CurrentTitle;
			this.level.SelectedItem = emp.CurrentLevel;
			this.salary.Value = emp.CurrentSalary;
			this.bonus.Value = 0;
			this.manager.SelectedValue = emp.CurrentManager.Id;

		}

		private void InitializeState()
		{
			this.action.RenderDatasource(typeof(ActionType));
			this.title.RenderDatasource(typeof(Title));
			this.level.RenderDatasource(typeof(Level));
			this.title.RenderDatasource(typeof(Title));
			this.manager.DataSource = viewHelper.GetManagerList();
			this.manager.DisplayMember = "Name";
			this.manager.ValueMember = "Id";
			this.action.SelectedValue = ActionType.ANNUAL_PERFORMANCE_REVIEW;
		}

		private void CancelBtnClickedHandler(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CreateBtnClickedHandler(object sender, EventArgs e)
		{
			ActionType newAction = (ActionType)this.action.SelectedValue;
			Title newTitle = (Title)this.title.SelectedValue;
			Level newLevel = (Level)this.level.SelectedValue;
			empRepo.CreateEmployeeHistory(this.currentEmployeeId, (Guid)this.manager.SelectedValue, newTitle, newLevel, this.salary.Value, this.bonus.Value, newAction, this.date.Value);
			this.currentEmployeeTitle = newTitle;
			this.Close();
		}
	}
}
