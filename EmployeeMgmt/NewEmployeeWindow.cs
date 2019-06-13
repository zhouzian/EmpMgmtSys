using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Extensions;
using PersistenceAccess.Repositories;
using System;
using System.Windows.Forms;

namespace EmployeeMgmt
{
	public partial class NewEmployeeWindow : Form
	{
        private EmployeeRepository empRepo;
        private ViewGeneratorHelper viewHelper;

		public NewEmployeeWindow()
		{
            empRepo = new EmployeeRepository();
            viewHelper = new ViewGeneratorHelper(empRepo);
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
			this.manager.DataSource = viewHelper.GetManagerList();
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
			EmployeeDC newEmployee = empRepo.CreateEmployee((Guid)this.manager.SelectedValue, this.frstName.Text, this.lastName.Text, newGender, this.email.Text, newTitle, newLevel, this.salary.Value, this.bonus.Value, this.onboard.Value);
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
