using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Extensions;
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
	public partial class NewEmployeeWindow : Form
	{
		public NewEmployeeWindow()
		{
			InitializeComponent();
			InitializeState();
		}

		public Guid newEmployeeId;
		public Title newEmployeeTitle;

		private void InitializeState()
		{
			// Bind enum value to dropdowns
			this.gender.RenderDatasource(typeof(Gender));
			this.title.RenderDatasource(typeof(Title));
			this.level.RenderDatasource(typeof(Level));
			this.manager.DataSource = AppView.GetManagerList();
			this.manager.DisplayMember = "Name";
			this.manager.ValueMember = "Id";
			this.createBtn.Enabled = false;
		}

		/// <summary>
		/// Exit
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelBtnClickedHandler(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Create new employee
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CreateBtnClickedHandler(object sender, EventArgs e)
		{
			Gender newGender = (Gender)this.gender.SelectedValue;
			Title newTitle = (Title)this.title.SelectedValue;
			Level newLevel = (Level)this.level.SelectedValue;
			EmployeeDC newEmployee = AppView.CreateEmployee((Guid)this.manager.SelectedValue, this.frstName.Text, this.lastName.Text, newGender, this.email.Text, newTitle, newLevel, this.salary.Value, this.bonus.Value, this.onboard.Value);
			newEmployeeId = newEmployee.Id;
			newEmployeeTitle = newEmployee.CurrentTitle;
			this.Close();
		}

		private void InputValidationEvtHandler(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(this.frstName.Text) || string.IsNullOrWhiteSpace(this.lastName.Text) || string.IsNullOrWhiteSpace(this.email.Text))
			{
				this.createBtn.Enabled = false;
			}
			else
			{
				this.createBtn.Enabled = true;
			}
		}
	}
}
