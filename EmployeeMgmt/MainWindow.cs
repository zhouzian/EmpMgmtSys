using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.Policies;
using System;
using System.Drawing;
using System.Windows.Forms;
using PersistenceAccess.Extensions;
using PersistenceAccess.Repositories;

namespace EmployeeMgmt
{
	public partial class MainWindow : Form
	{
        /// <summary>
        /// The initializationCompleted flag is used to block all handlers execution during the window initialization process.
        /// Without the flag, when initialization the checkboxes, the checkbox click handler will be triggered, causing unnecessary database access.
        /// </summary>
        private bool initializationCompleted = false;
        private EmployeeRepository empRepo;
        private ViewGeneratorHelper viewHelper;
		public MainWindow()
		{
            empRepo = new EmployeeRepository();
            viewHelper = new ViewGeneratorHelper(empRepo);
			InitializeComponent();
			InitializeState();
            initializationCompleted = true;
		}

		private void InitializeState()
		{
			// Populate test data in db. Remove before release.
			empRepo.SeedDB();

			// Render list view of all employees.
			this.showDev.Checked = true;
			this.showQa.Checked = true;
			this.showTpm.Checked = true;
			this.showUe.Checked = true;
			UpdateMainListing();

			// Display policy info
			this.GlobalReviewInfo.Text = "Incoming performance review date: " + GlobalPolicyContainer.AnnualPerformanceReviewPolicy.GetNextReviewDate().ToShortDateString();

			// Bind enum value to dropdowns
			this.gGender.RenderDatasource(typeof(Gender));
		}

		/// <summary>
		/// Populate employee general info when selected from the list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CurrentEmployeeSelectionChangedHandler(object sender, ListViewItemSelectionChangedEventArgs e)
		{
            if (initializationCompleted)
            {
                UnlockGeneralInfoSection();
                Guid id = (Guid)e.Item.Tag;
                EmployeeDC emp = empRepo.GetEmployee(id);
                PopulateGeneralInfoSection(emp);
                PopulateHistorySection(emp);
                DisableGeneralInfoBtns();
                UnlockHistory();
            }
		}

		private void PopulateGeneralInfoSection(EmployeeDC emp)
		{
			this.gFirstName.Text = emp.FirstName;
			this.gFirstName.Modified = false;
			this.gLastName.Text = emp.LastName;
			this.gLastName.Modified = false;
			this.gEmail.Text = emp.Email;
			this.gEmail.Modified = false;
			this.gGender.SelectedValue = emp.Gender;
			this.gOnboard.Value = emp.OnboardDate;
			this.gTitleDisplay.Text = emp.CurrentTitle.GetDisplayName();
			this.gLevelDisplay.Text = emp.CurrentLevel.GetDisplayName();
			this.gSalaryDisplay.Text = emp.CurrentSalary.ToString("C0");
			this.gManagerDisplay.Text = emp.ManagerName;
			this.YofEmpValue.Text = emp.YearOfEmployment.ToString();
			if (emp.ResignDate == null)
			{
				this.ReviewInfo.Text = '\u26a0' + " Next performance review on " + ((DateTime)emp.NextReviewDate).ToShortDateString();
				this.ReviewInfo.ForeColor = Color.Black;
			}
			else
			{
				this.ReviewInfo.Text = "Resigned on " + ((DateTime)emp.ResignDate).ToShortDateString();
				this.ReviewInfo.ForeColor = Color.Red;
			}
		}

		private void PopulateHistorySection(EmployeeDC emp)
		{
			this.historyListContainer.Items.Clear();
			this.historyListContainer.Items.AddRange(viewHelper.GetHistoryFromEmployeeView(emp));
			this.historyListContainer.Items[this.historyListContainer.Items.Count - 1].EnsureVisible();
		}

		/// <summary>
		/// Revert changes from general info section
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GeneralInfoRevertBtnClickedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                Guid id = (Guid)this.employeeListContainer.FocusedItem.Tag;
                EmployeeDC emp = empRepo.GetEmployee(id);
                PopulateGeneralInfoSection(emp);
                DisableGeneralInfoBtns();
            }
		}

		/// <summary>
		/// Save general info to db
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GeneralInfoSaveBtnClickedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                Guid id = (Guid)this.employeeListContainer.FocusedItem.Tag;
                Gender gender = (Gender)this.gGender.SelectedValue;
                empRepo.UpdateEmployeeGeneralInfo(id, this.gFirstName.Text, this.gLastName.Text, gender, this.gEmail.Text, this.gOnboard.Value);
                UpdateMainListing();
            }
		}

		private void UpdateMainListing()
		{
			var visibParam = new VisibilityParam()
			{
				showDev = this.showDev.Checked,
				showQa = this.showQa.Checked,
				showTpm = this.showTpm.Checked,
				showUe = this.showUe.Checked
			};

			if (this.employeeListContainer.FocusedItem != null)
			{
				int selectedIndex = this.employeeListContainer.FocusedItem.Index;
				Guid id = (Guid)this.employeeListContainer.FocusedItem.Tag;
				this.employeeListContainer.Items.Clear();
				this.employeeListContainer.Items.AddRange(viewHelper.GetMainListView(visibParam));
				if (selectedIndex <= this.employeeListContainer.Items.Count - 1 && (Guid)this.employeeListContainer.Items[selectedIndex].Tag == id)
				{
					// to make sure we are still focusing at the same item
					this.employeeListContainer.Items[selectedIndex].Focused = true;
					this.employeeListContainer.Items[selectedIndex].Selected = true;
					this.employeeListContainer.Items[selectedIndex].EnsureVisible();
					DisableGeneralInfoBtns();
				}
				else
				{
					// the original item wasn't there anymore
					LockGeneralInfoSection();
					DisableGeneralInfoBtns();
					LockHistory();
				}
			}
			else
			{
				this.employeeListContainer.Items.Clear();
				this.employeeListContainer.Items.AddRange(viewHelper.GetMainListView(visibParam));
				LockGeneralInfoSection();
				DisableGeneralInfoBtns();
				LockHistory();
			}
		}

		#region General Info section event handling

		private void EnableGeneralInfoBtns()
		{
			this.revertBtn.Enabled = true;
			this.saveBtn.Enabled = true;
		}

		private void DisableGeneralInfoBtns()
		{
			this.revertBtn.Enabled = false;
			this.saveBtn.Enabled = false;
		}

		private void LockGeneralInfoSection()
		{
			this.gFirstName.Text = string.Empty;
			this.gFirstName.Enabled = false;
			this.gLastName.Text = string.Empty;
			this.gLastName.Enabled = false;
			this.gGender.Enabled = false;
			this.gEmail.Text = string.Empty;
			this.gEmail.Enabled = false;
			this.gOnboard.Enabled = false;
			this.gManagerDisplay.Text = string.Empty;
			this.gSalaryDisplay.Text = string.Empty;
			this.gTitleDisplay.Text = string.Empty;
			this.gLevelDisplay.Text = string.Empty;
			this.ReviewInfo.Text = string.Empty;
			this.YofEmpValue.Text = string.Empty;
		}

		private void UnlockGeneralInfoSection()
		{
			this.gFirstName.Enabled = true;
			this.gLastName.Enabled = true;
			this.gGender.Enabled = true;
			this.gEmail.Enabled = true;
			this.gOnboard.Enabled = true;
		}

		private void LockHistory()
		{
			this.createHistoryBtn.Enabled = false;
			this.historyListContainer.Items.Clear();
		}

		private void UnlockHistory()
		{
			this.createHistoryBtn.Enabled = true;
		}

		private void FirstNameModifiedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                EnableGeneralInfoBtns();
            }
		}

		private void LastNameModifiedHander(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                EnableGeneralInfoBtns();
            }
		}

		private void EmailModifiedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                EnableGeneralInfoBtns();
            }
		}

		private void GenderModifiedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                EnableGeneralInfoBtns();
            }
		}

		private void OnboardDateModifiedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                EnableGeneralInfoBtns();
            }
		}

		#endregion

		/// <summary>
		/// Opens dialog to create new employee
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NewEmployeeBtnClickedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                using (var newEmpDlg = new NewEmployeeWindow())
                {
                    if (newEmpDlg.ShowDialog() == DialogResult.OK)
                    {
                        EnsureChecked(newEmpDlg.newEmployeeTitle);
                        UpdateMainListing();
                        Guid tmp = newEmpDlg.newEmployeeId;
                        SelectEmployee(tmp.ToString());
                    }
                }
            }
		}

		private void SelectEmployee(string id)
		{
			var newItem = this.employeeListContainer.Items.Find(id, false)[0];
			newItem.Selected = true;
			newItem.Focused = true;
			newItem.EnsureVisible();
		}

		private void CreateHistoryBtnClickedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                Guid id = (Guid)this.employeeListContainer.FocusedItem.Tag;
                EmployeeDC emp = empRepo.GetEmployee((Guid)id);
                using (var newHistoryDlg = new NewHistoryWindow(emp))
                {
                    if (newHistoryDlg.ShowDialog() == DialogResult.OK)
                    {
                        EnsureChecked(newHistoryDlg.currentEmployeeTitle);
                        UpdateMainListing();
                        Guid tmp = newHistoryDlg.currentEmployeeId;
                        SelectEmployee(tmp.ToString());
                    }
                }
            }
		}

		private void AnalyticsBtnClickedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                using (var analyticsDlg = new AnalyticsWindow())
                {
                    analyticsDlg.ShowDialog();
                }
            }
		}

		private void CatelogChangedHandler(object sender, EventArgs e)
		{
            if (initializationCompleted)
            {
                UpdateMainListing();
            }
		}

		private void EnsureChecked(Title title)
		{
			switch (title)
			{
				case Title.SOFTWARE_ENGINEER:
					this.showDev.Checked = true;
					break;
				case Title.SOFTWARE_ENGINEER_IN_TEST:
					this.showQa.Checked = true;
					break;
				case Title.SOFTWARE_TEST_ENGINEER:
					this.showQa.Checked = true;
					break;
				case Title.TECHNICAL_PRODUCT_MANAGER:
					this.showTpm.Checked = true;
					break;
				case Title.TECHNICAL_WRITER:
					this.showUe.Checked = true;
					break;
			}
		}
	}
}
