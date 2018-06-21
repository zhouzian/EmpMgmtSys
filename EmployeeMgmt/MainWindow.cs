using PersistenceAccess.DataContracts;
using PersistenceAccess.Entities;
using PersistenceAccess.View;
using System;
using System.Windows.Forms;

namespace EmployeeMgmt
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			InitializeState();
		}

		private void InitializeState()
		{
			// Populate test data in db. Remove before release.
			AppView.SeedDB();

			// Render list view of all employees.
			this.showDev.Checked = true;
			this.showQa.Checked = true;
			this.showTpm.Checked = true;
			updateMainListing();

			// Bind enum value to dropdowns
			this.gGender.DataSource = Enum.GetValues(typeof(Gender));

		}

		/// <summary>
		/// Populate employee general info when selected from the list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void employeeListContainer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			unlockGeneralInfoSection();
			Guid id = (Guid)e.Item.Tag;
			EmployeeDC emp = AppView.GetEmployee((Guid)id);
			populateGeneralInfoSection(emp);
			populateHistorySection(emp);
			disableGeneralInfoBtns();
			unlockHistory();
		}

		private void populateGeneralInfoSection(EmployeeDC emp)
		{
			this.gFirstName.Text = emp.FirstName;
			this.gFirstName.Modified = false;
			this.gLastName.Text = emp.LastName;
			this.gLastName.Modified = false;
			this.gEmail.Text = emp.Email;
			this.gEmail.Modified = false;
			this.gGender.SelectedItem = emp.Gender;
			this.gOnboard.Value = emp.OnboardDate;
			this.gTitleDisplay.Text = emp.CurrentTitle.ToString();
			this.gLevelDisplay.Text = emp.CurrentLevel.ToString();
			this.gSalaryDisplay.Text = emp.CurrentSalary.ToString("C0");
			this.gManagerDisplay.Text = emp.ManagerName;
			if (emp.ResignDate == null)
			{
				this.resignInfo.Text = string.Empty;
			}
			else
			{
				this.resignInfo.Text = "Resigned on " + ((DateTime)emp.ResignDate).ToShortDateString();
			}
		}

		private void populateHistorySection(EmployeeDC emp)
		{
			this.historyListContainer.Items.Clear();
			this.historyListContainer.Items.AddRange(AppView.GetHistoryFromEmployeeView(emp));
			this.historyListContainer.Items[this.historyListContainer.Items.Count - 1].EnsureVisible();
		}

		/// <summary>
		/// Revert changes from general info section
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void revertBtn_Click(object sender, EventArgs e)
		{
			Guid id = (Guid)this.employeeListContainer.FocusedItem.Tag;
			EmployeeDC emp = AppView.GetEmployee(id);
			populateGeneralInfoSection(emp);
			disableGeneralInfoBtns();
		}

		/// <summary>
		/// Save general info to db
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveBtn_Click(object sender, EventArgs e)
		{
			Guid id = (Guid)this.employeeListContainer.FocusedItem.Tag;
			Gender gender;
			Enum.TryParse<Gender>(this.gGender.SelectedValue.ToString(), out gender);
			AppView.UpdateEmployeeGeneralInfo(id, this.gFirstName.Text, this.gLastName.Text, gender, this.gEmail.Text, this.gOnboard.Value);
			updateMainListing();
		}

		private void updateMainListing()
		{
			bool showDev = this.showDev.Checked;
			bool showQa = this.showQa.Checked;
			bool showTpm = this.showTpm.Checked;

			if (this.employeeListContainer.FocusedItem != null)
			{
				int selectedIndex = this.employeeListContainer.FocusedItem.Index;
				Guid id = (Guid)this.employeeListContainer.FocusedItem.Tag;
				this.employeeListContainer.Items.Clear();
				this.employeeListContainer.Items.AddRange(AppView.GetMainListView(showDev, showQa, showTpm));
				if (selectedIndex <= this.employeeListContainer.Items.Count - 1 && (Guid)this.employeeListContainer.Items[selectedIndex].Tag == id)
				{
					// to make sure we are still focusing at the same item
					this.employeeListContainer.Items[selectedIndex].Focused = true;
					this.employeeListContainer.Items[selectedIndex].Selected = true;
					this.employeeListContainer.Items[selectedIndex].EnsureVisible();
					disableGeneralInfoBtns();
				}
				else
				{
					// the original item wasn't there anymore
					lockGeneralInfoSection();
					disableGeneralInfoBtns();
					lockHistory();
				}
			}
			else
			{
				this.employeeListContainer.Items.Clear();
				this.employeeListContainer.Items.AddRange(AppView.GetMainListView(showDev, showQa, showTpm));
				lockGeneralInfoSection();
				disableGeneralInfoBtns();
				lockHistory();
			}
		}

		#region General Info section event handling

		private void enableGeneralInfoBtns()
		{
			this.revertBtn.Enabled = true;
			this.saveBtn.Enabled = true;
		}

		private void disableGeneralInfoBtns()
		{
			this.revertBtn.Enabled = false;
			this.saveBtn.Enabled = false;
		}

		private void lockGeneralInfoSection()
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
			this.resignInfo.Text = string.Empty;
		}

		private void unlockGeneralInfoSection()
		{
			this.gFirstName.Enabled = true;
			this.gLastName.Enabled = true;
			this.gGender.Enabled = true;
			this.gEmail.Enabled = true;
			this.gOnboard.Enabled = true;
		}

		private void lockHistory()
		{
			this.createHistoryBtn.Enabled = false;
			this.historyListContainer.Items.Clear();
		}

		private void unlockHistory()
		{
			this.createHistoryBtn.Enabled = true;
		}

		private void gFirstName_ModifiedChanged(object sender, EventArgs e)
		{
			enableGeneralInfoBtns();
		}

		private void gLastName_ModifiedChanged(object sender, EventArgs e)
		{
			enableGeneralInfoBtns();
		}

		private void gEmail_ModifiedChanged(object sender, EventArgs e)
		{
			enableGeneralInfoBtns();
		}

		private void gGender_SelectionChangeCommitted(object sender, EventArgs e)
		{
			enableGeneralInfoBtns();
		}

		private void gOnboard_ValueChanged(object sender, EventArgs e)
		{
			enableGeneralInfoBtns();
		}

		#endregion

		/// <summary>
		/// Opens dialog to create new employee
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void newEmpBtn_Click(object sender, EventArgs e)
		{
			using (var newEmpDlg = new NewEmployeeWindow())
			{
				if (newEmpDlg.ShowDialog() == DialogResult.OK)
				{
					ensureChecked(newEmpDlg.newEmployeeTitle);
					updateMainListing();
					Guid tmp = newEmpDlg.newEmployeeId;
					selectEmployee(tmp.ToString());
				}
			}
		}

		private void selectEmployee(string id)
		{
			var newItem = this.employeeListContainer.Items.Find(id, false)[0];
			newItem.Selected = true;
			newItem.Focused = true;
			newItem.EnsureVisible();
		}

		private void createHistoryBtn_Click(object sender, EventArgs e)
		{
			Guid id = (Guid)this.employeeListContainer.FocusedItem.Tag;
			EmployeeDC emp = AppView.GetEmployee((Guid)id);
			using (var newHistoryDlg = new NewHistoryWindow(emp))
			{
				if (newHistoryDlg.ShowDialog() == DialogResult.OK)
				{
					ensureChecked(newHistoryDlg.currentEmployeeTitle);
					updateMainListing();
					Guid tmp = newHistoryDlg.currentEmployeeId;
					selectEmployee(tmp.ToString());
				}
			}
		}

		private void accessAnalyticsBtn_Click(object sender, EventArgs e)
		{
			using (var analyticsDlg = new AnalyticsWindow())
			{
				analyticsDlg.ShowDialog();
			}
		}

		private void showDev_CheckedChanged(object sender, EventArgs e)
		{
			updateMainListing();
		}

		private void ensureChecked(Title title)
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
			}
		}
	}
}
