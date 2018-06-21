using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeMgmt
{
	public partial class NewHistoryWindow : Form
	{
		public Guid currentEmployeeId;
		public Title currentEmployeeTitle;
		

		public NewHistoryWindow(EmployeeDC emp)
		{
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
			this.action.DataSource = Enum.GetValues(typeof(ActionType));
			this.title.DataSource = Enum.GetValues(typeof(Title));
			this.level.DataSource = Enum.GetValues(typeof(Level));
			this.title.DataSource = Enum.GetValues(typeof(Title));
			this.manager.DataSource = AppView.GetManagerList();
			this.manager.DisplayMember = "Name";
			this.manager.ValueMember = "Id";
			this.action.SelectedItem = ActionType.ANNUAL_PERFORMANCE_REVIEW;
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void createBtn_Click(object sender, EventArgs e)
		{
			ActionType newAction;
			Enum.TryParse<ActionType>(this.action.SelectedValue.ToString(), out newAction);
			Title newTitle;
			Enum.TryParse<Title>(this.title.SelectedValue.ToString(), out newTitle);
			Level newLevel;
			Enum.TryParse<Level>(this.level.SelectedValue.ToString(), out newLevel);
			AppView.CreateEmployeeHistory(this.currentEmployeeId, (Guid)this.manager.SelectedValue, newTitle, newLevel, this.salary.Value, this.bonus.Value, newAction, this.date.Value);
			this.currentEmployeeTitle = newTitle;
			this.Close();
		}
	}
}
