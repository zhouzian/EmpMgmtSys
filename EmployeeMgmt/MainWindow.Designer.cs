using EmployeeMgmt.Properties;

namespace EmployeeMgmt
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
            if (empRepo != null)
            {
                empRepo.Dispose();
            }
            if (viewHelper != null)
            {
                viewHelper.Dispose();
            }
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.ColumnHeader Name;
            System.Windows.Forms.ColumnHeader Position;
            System.Windows.Forms.ColumnHeader Onboard;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label genderLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label onboardLabel;
            System.Windows.Forms.Label titleLable;
            System.Windows.Forms.Label levelLable;
            System.Windows.Forms.Label salaryLabel;
            System.Windows.Forms.Label managerLabel;
            System.Windows.Forms.Label label1;
            this.employeeListContainer = new System.Windows.Forms.ListView();
            this.NextReview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.generalInfoContainer = new System.Windows.Forms.GroupBox();
            this.YofEmpValue = new System.Windows.Forms.Label();
            this.ReviewInfo = new System.Windows.Forms.Label();
            this.gManagerDisplay = new System.Windows.Forms.Label();
            this.gSalaryDisplay = new System.Windows.Forms.Label();
            this.gLevelDisplay = new System.Windows.Forms.Label();
            this.gTitleDisplay = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.revertBtn = new System.Windows.Forms.Button();
            this.gOnboard = new System.Windows.Forms.DateTimePicker();
            this.gEmail = new System.Windows.Forms.TextBox();
            this.gGender = new System.Windows.Forms.ComboBox();
            this.gLastName = new System.Windows.Forms.TextBox();
            this.gFirstName = new System.Windows.Forms.TextBox();
            this.newEmpBtn = new System.Windows.Forms.Button();
            this.historyInfoContainer = new System.Windows.Forms.GroupBox();
            this.createHistoryBtn = new System.Windows.Forms.Button();
            this.historyListContainer = new System.Windows.Forms.ListView();
            this.h_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_salary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_bonus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_manager = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.h_action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.accessAnalyticsBtn = new System.Windows.Forms.Button();
            this.showDev = new System.Windows.Forms.CheckBox();
            this.showQa = new System.Windows.Forms.CheckBox();
            this.showTpm = new System.Windows.Forms.CheckBox();
            this.showUe = new System.Windows.Forms.CheckBox();
            this.GlobalReviewInfo = new System.Windows.Forms.Label();
            Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Position = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            Onboard = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            firstNameLabel = new System.Windows.Forms.Label();
            lastNameLabel = new System.Windows.Forms.Label();
            genderLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            onboardLabel = new System.Windows.Forms.Label();
            titleLable = new System.Windows.Forms.Label();
            levelLable = new System.Windows.Forms.Label();
            salaryLabel = new System.Windows.Forms.Label();
            managerLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.generalInfoContainer.SuspendLayout();
            this.historyInfoContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // Name
            // 
            Name.Text = "Name";
            Name.Width = 150;
            // 
            // Position
            // 
            Position.Text = "Position";
            Position.Width = 200;
            // 
            // Onboard
            // 
            Onboard.Text = "Onboard Date";
            Onboard.Width = 100;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new System.Drawing.Point(4, 24);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new System.Drawing.Size(60, 13);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new System.Drawing.Point(176, 24);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new System.Drawing.Size(61, 13);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name:";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new System.Drawing.Point(365, 23);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new System.Drawing.Size(45, 13);
            genderLabel.TabIndex = 4;
            genderLabel.Text = "Gender:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(29, 57);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "Email:";
            // 
            // onboardLabel
            // 
            onboardLabel.AutoSize = true;
            onboardLabel.Location = new System.Drawing.Point(519, 23);
            onboardLabel.Name = "onboardLabel";
            onboardLabel.Size = new System.Drawing.Size(51, 13);
            onboardLabel.TabIndex = 8;
            onboardLabel.Text = "Onboard:";
            // 
            // titleLable
            // 
            titleLable.AutoSize = true;
            titleLable.Location = new System.Drawing.Point(36, 93);
            titleLable.Name = "titleLable";
            titleLable.Size = new System.Drawing.Size(30, 13);
            titleLable.TabIndex = 10;
            titleLable.Text = "Title:";
            // 
            // levelLable
            // 
            levelLable.AutoSize = true;
            levelLable.Location = new System.Drawing.Point(374, 93);
            levelLable.Name = "levelLable";
            levelLable.Size = new System.Drawing.Size(36, 13);
            levelLable.TabIndex = 12;
            levelLable.Text = "Level:";
            // 
            // salaryLabel
            // 
            salaryLabel.AutoSize = true;
            salaryLabel.Location = new System.Drawing.Point(500, 93);
            salaryLabel.Name = "salaryLabel";
            salaryLabel.Size = new System.Drawing.Size(70, 13);
            salaryLabel.TabIndex = 14;
            salaryLabel.Text = "Salary (CAD):";
            // 
            // managerLabel
            // 
            managerLabel.AutoSize = true;
            managerLabel.Location = new System.Drawing.Point(358, 57);
            managerLabel.Name = "managerLabel";
            managerLabel.Size = new System.Drawing.Size(52, 13);
            managerLabel.TabIndex = 15;
            managerLabel.Text = "Manager:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(656, 57);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(109, 13);
            label1.TabIndex = 23;
            label1.Text = "Years of Employment:";
            // 
            // employeeListContainer
            // 
            this.employeeListContainer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Name,
            Position,
            this.NextReview,
            Onboard});
            this.employeeListContainer.FullRowSelect = true;
            this.employeeListContainer.HideSelection = false;
            this.employeeListContainer.LabelWrap = false;
            this.employeeListContainer.Location = new System.Drawing.Point(12, 36);
            this.employeeListContainer.MultiSelect = false;
            this.employeeListContainer.Name = "employeeListContainer";
            this.employeeListContainer.ShowGroups = false;
            this.employeeListContainer.Size = new System.Drawing.Size(479, 719);
            this.employeeListContainer.TabIndex = 0;
            this.employeeListContainer.UseCompatibleStateImageBehavior = false;
            this.employeeListContainer.View = System.Windows.Forms.View.Details;
            this.employeeListContainer.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.CurrentEmployeeSelectionChangedHandler);
            // 
            // NextReview
            // 
            this.NextReview.Text = "Next Review";
            this.NextReview.Width = 100;
            // 
            // generalInfoContainer
            // 
            this.generalInfoContainer.Controls.Add(this.YofEmpValue);
            this.generalInfoContainer.Controls.Add(label1);
            this.generalInfoContainer.Controls.Add(this.ReviewInfo);
            this.generalInfoContainer.Controls.Add(this.gManagerDisplay);
            this.generalInfoContainer.Controls.Add(this.gSalaryDisplay);
            this.generalInfoContainer.Controls.Add(this.gLevelDisplay);
            this.generalInfoContainer.Controls.Add(this.gTitleDisplay);
            this.generalInfoContainer.Controls.Add(this.saveBtn);
            this.generalInfoContainer.Controls.Add(this.revertBtn);
            this.generalInfoContainer.Controls.Add(managerLabel);
            this.generalInfoContainer.Controls.Add(salaryLabel);
            this.generalInfoContainer.Controls.Add(levelLable);
            this.generalInfoContainer.Controls.Add(titleLable);
            this.generalInfoContainer.Controls.Add(this.gOnboard);
            this.generalInfoContainer.Controls.Add(onboardLabel);
            this.generalInfoContainer.Controls.Add(this.gEmail);
            this.generalInfoContainer.Controls.Add(emailLabel);
            this.generalInfoContainer.Controls.Add(this.gGender);
            this.generalInfoContainer.Controls.Add(genderLabel);
            this.generalInfoContainer.Controls.Add(this.gLastName);
            this.generalInfoContainer.Controls.Add(lastNameLabel);
            this.generalInfoContainer.Controls.Add(this.gFirstName);
            this.generalInfoContainer.Controls.Add(firstNameLabel);
            this.generalInfoContainer.Location = new System.Drawing.Point(497, 36);
            this.generalInfoContainer.Name = "generalInfoContainer";
            this.generalInfoContainer.Padding = new System.Windows.Forms.Padding(0);
            this.generalInfoContainer.Size = new System.Drawing.Size(807, 155);
            this.generalInfoContainer.TabIndex = 1;
            this.generalInfoContainer.TabStop = false;
            this.generalInfoContainer.Text = "General Information";
            // 
            // YofEmpValue
            // 
            this.YofEmpValue.AutoSize = true;
            this.YofEmpValue.Location = new System.Drawing.Point(771, 57);
            this.YofEmpValue.Name = "YofEmpValue";
            this.YofEmpValue.Size = new System.Drawing.Size(0, 13);
            this.YofEmpValue.TabIndex = 24;
            // 
            // ReviewInfo
            // 
            this.ReviewInfo.AutoSize = true;
            this.ReviewInfo.ForeColor = System.Drawing.Color.Red;
            this.ReviewInfo.Location = new System.Drawing.Point(72, 126);
            this.ReviewInfo.Name = "ReviewInfo";
            this.ReviewInfo.Size = new System.Drawing.Size(61, 13);
            this.ReviewInfo.TabIndex = 22;
            this.ReviewInfo.Text = "ReviewInfo";
            // 
            // gManagerDisplay
            // 
            this.gManagerDisplay.AutoSize = true;
            this.gManagerDisplay.Location = new System.Drawing.Point(416, 57);
            this.gManagerDisplay.Name = "gManagerDisplay";
            this.gManagerDisplay.Size = new System.Drawing.Size(0, 13);
            this.gManagerDisplay.TabIndex = 21;
            // 
            // gSalaryDisplay
            // 
            this.gSalaryDisplay.AutoSize = true;
            this.gSalaryDisplay.Location = new System.Drawing.Point(576, 93);
            this.gSalaryDisplay.Name = "gSalaryDisplay";
            this.gSalaryDisplay.Size = new System.Drawing.Size(0, 13);
            this.gSalaryDisplay.TabIndex = 20;
            // 
            // gLevelDisplay
            // 
            this.gLevelDisplay.AutoSize = true;
            this.gLevelDisplay.Location = new System.Drawing.Point(416, 93);
            this.gLevelDisplay.Name = "gLevelDisplay";
            this.gLevelDisplay.Size = new System.Drawing.Size(0, 13);
            this.gLevelDisplay.TabIndex = 20;
            // 
            // gTitleDisplay
            // 
            this.gTitleDisplay.AutoSize = true;
            this.gTitleDisplay.Location = new System.Drawing.Point(72, 93);
            this.gTitleDisplay.Name = "gTitleDisplay";
            this.gTitleDisplay.Size = new System.Drawing.Size(0, 13);
            this.gTitleDisplay.TabIndex = 19;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(729, 126);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.GeneralInfoSaveBtnClickedHandler);
            // 
            // revertBtn
            // 
            this.revertBtn.Location = new System.Drawing.Point(648, 126);
            this.revertBtn.Name = "revertBtn";
            this.revertBtn.Size = new System.Drawing.Size(75, 23);
            this.revertBtn.TabIndex = 17;
            this.revertBtn.Text = "Cancel";
            this.revertBtn.UseVisualStyleBackColor = true;
            this.revertBtn.Click += new System.EventHandler(this.GeneralInfoRevertBtnClickedHandler);
            // 
            // gOnboard
            // 
            this.gOnboard.Location = new System.Drawing.Point(576, 18);
            this.gOnboard.Name = "gOnboard";
            this.gOnboard.Size = new System.Drawing.Size(228, 20);
            this.gOnboard.TabIndex = 9;
            this.gOnboard.ValueChanged += new System.EventHandler(this.OnboardDateModifiedHandler);
            // 
            // gEmail
            // 
            this.gEmail.Location = new System.Drawing.Point(70, 54);
            this.gEmail.Name = "gEmail";
            this.gEmail.Size = new System.Drawing.Size(273, 20);
            this.gEmail.TabIndex = 7;
            this.gEmail.ModifiedChanged += new System.EventHandler(this.EmailModifiedHandler);
            // 
            // gGender
            // 
            this.gGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gGender.FormattingEnabled = true;
            this.gGender.Location = new System.Drawing.Point(416, 20);
            this.gGender.Name = "gGender";
            this.gGender.Size = new System.Drawing.Size(80, 21);
            this.gGender.TabIndex = 5;
            this.gGender.SelectionChangeCommitted += new System.EventHandler(this.GenderModifiedHandler);
            // 
            // gLastName
            // 
            this.gLastName.Location = new System.Drawing.Point(243, 21);
            this.gLastName.Name = "gLastName";
            this.gLastName.Size = new System.Drawing.Size(100, 20);
            this.gLastName.TabIndex = 3;
            this.gLastName.ModifiedChanged += new System.EventHandler(this.LastNameModifiedHander);
            // 
            // gFirstName
            // 
            this.gFirstName.Location = new System.Drawing.Point(70, 21);
            this.gFirstName.Name = "gFirstName";
            this.gFirstName.Size = new System.Drawing.Size(100, 20);
            this.gFirstName.TabIndex = 1;
            this.gFirstName.ModifiedChanged += new System.EventHandler(this.FirstNameModifiedHandler);
            // 
            // newEmpBtn
            // 
            this.newEmpBtn.Location = new System.Drawing.Point(387, 6);
            this.newEmpBtn.Name = "newEmpBtn";
            this.newEmpBtn.Size = new System.Drawing.Size(104, 27);
            this.newEmpBtn.TabIndex = 2;
            this.newEmpBtn.Text = "+ New employee";
            this.newEmpBtn.UseVisualStyleBackColor = true;
            this.newEmpBtn.Click += new System.EventHandler(this.NewEmployeeBtnClickedHandler);
            // 
            // historyInfoContainer
            // 
            this.historyInfoContainer.Controls.Add(this.createHistoryBtn);
            this.historyInfoContainer.Controls.Add(this.historyListContainer);
            this.historyInfoContainer.Location = new System.Drawing.Point(497, 197);
            this.historyInfoContainer.Name = "historyInfoContainer";
            this.historyInfoContainer.Size = new System.Drawing.Size(807, 558);
            this.historyInfoContainer.TabIndex = 3;
            this.historyInfoContainer.TabStop = false;
            this.historyInfoContainer.Text = "History";
            // 
            // createHistoryBtn
            // 
            this.createHistoryBtn.Location = new System.Drawing.Point(697, 12);
            this.createHistoryBtn.Name = "createHistoryBtn";
            this.createHistoryBtn.Size = new System.Drawing.Size(104, 27);
            this.createHistoryBtn.TabIndex = 3;
            this.createHistoryBtn.Text = "+ New history";
            this.createHistoryBtn.UseVisualStyleBackColor = true;
            this.createHistoryBtn.Click += new System.EventHandler(this.CreateHistoryBtnClickedHandler);
            // 
            // historyListContainer
            // 
            this.historyListContainer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.h_date,
            this.h_title,
            this.h_level,
            this.h_salary,
            this.h_bonus,
            this.h_manager,
            this.h_action});
            this.historyListContainer.FullRowSelect = true;
            this.historyListContainer.HideSelection = false;
            this.historyListContainer.Location = new System.Drawing.Point(6, 45);
            this.historyListContainer.MultiSelect = false;
            this.historyListContainer.Name = "historyListContainer";
            this.historyListContainer.Size = new System.Drawing.Size(795, 507);
            this.historyListContainer.TabIndex = 0;
            this.historyListContainer.UseCompatibleStateImageBehavior = false;
            this.historyListContainer.View = System.Windows.Forms.View.Details;
            // 
            // h_date
            // 
            this.h_date.Text = "Date";
            this.h_date.Width = 100;
            // 
            // h_title
            // 
            this.h_title.Text = "Title";
            this.h_title.Width = 200;
            // 
            // h_level
            // 
            this.h_level.Text = "Level";
            this.h_level.Width = 100;
            // 
            // h_salary
            // 
            this.h_salary.Text = "Salary";
            this.h_salary.Width = 100;
            // 
            // h_bonus
            // 
            this.h_bonus.Text = "Bonus";
            this.h_bonus.Width = 100;
            // 
            // h_manager
            // 
            this.h_manager.Text = "Manager";
            this.h_manager.Width = 150;
            // 
            // h_action
            // 
            this.h_action.Text = "Action";
            this.h_action.Width = 200;
            // 
            // accessAnalyticsBtn
            // 
            this.accessAnalyticsBtn.Location = new System.Drawing.Point(12, 9);
            this.accessAnalyticsBtn.Name = "accessAnalyticsBtn";
            this.accessAnalyticsBtn.Size = new System.Drawing.Size(95, 23);
            this.accessAnalyticsBtn.TabIndex = 4;
            this.accessAnalyticsBtn.Text = "View Analytics";
            this.accessAnalyticsBtn.UseVisualStyleBackColor = true;
            this.accessAnalyticsBtn.Click += new System.EventHandler(this.AnalyticsBtnClickedHandler);
            // 
            // showDev
            // 
            this.showDev.AutoSize = true;
            this.showDev.Location = new System.Drawing.Point(114, 13);
            this.showDev.Name = "showDev";
            this.showDev.Size = new System.Drawing.Size(48, 17);
            this.showDev.TabIndex = 5;
            this.showDev.Text = "DEV";
            this.showDev.UseVisualStyleBackColor = true;
            this.showDev.CheckedChanged += new System.EventHandler(this.CatelogChangedHandler);
            // 
            // showQa
            // 
            this.showQa.AutoSize = true;
            this.showQa.Location = new System.Drawing.Point(169, 13);
            this.showQa.Name = "showQa";
            this.showQa.Size = new System.Drawing.Size(41, 17);
            this.showQa.TabIndex = 6;
            this.showQa.Text = "QA";
            this.showQa.UseVisualStyleBackColor = true;
            this.showQa.CheckedChanged += new System.EventHandler(this.CatelogChangedHandler);
            // 
            // showTpm
            // 
            this.showTpm.AutoSize = true;
            this.showTpm.Location = new System.Drawing.Point(217, 13);
            this.showTpm.Name = "showTpm";
            this.showTpm.Size = new System.Drawing.Size(49, 17);
            this.showTpm.TabIndex = 7;
            this.showTpm.Text = "TPM";
            this.showTpm.UseVisualStyleBackColor = true;
            this.showTpm.CheckedChanged += new System.EventHandler(this.CatelogChangedHandler);
            // 
            // showUe
            // 
            this.showUe.AutoSize = true;
            this.showUe.Location = new System.Drawing.Point(272, 13);
            this.showUe.Name = "showUe";
            this.showUe.Size = new System.Drawing.Size(41, 17);
            this.showUe.TabIndex = 8;
            this.showUe.Text = "UE";
            this.showUe.UseVisualStyleBackColor = true;
            this.showUe.CheckedChanged += new System.EventHandler(this.CatelogChangedHandler);
            // 
            // GlobalReviewInfo
            // 
            this.GlobalReviewInfo.AutoSize = true;
            this.GlobalReviewInfo.Location = new System.Drawing.Point(1070, 20);
            this.GlobalReviewInfo.Name = "GlobalReviewInfo";
            this.GlobalReviewInfo.Size = new System.Drawing.Size(141, 13);
            this.GlobalReviewInfo.TabIndex = 9;
            this.GlobalReviewInfo.Text = "Company Next Review Date";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 761);
            this.Controls.Add(this.GlobalReviewInfo);
            this.Controls.Add(this.showUe);
            this.Controls.Add(this.showTpm);
            this.Controls.Add(this.showQa);
            this.Controls.Add(this.showDev);
            this.Controls.Add(this.accessAnalyticsBtn);
            this.Controls.Add(this.historyInfoContainer);
            this.Controls.Add(this.newEmpBtn);
            this.Controls.Add(this.generalInfoContainer);
            this.Controls.Add(this.employeeListContainer);
            this.Name = "MainWindow";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Employee Management System";
            this.generalInfoContainer.ResumeLayout(false);
            this.generalInfoContainer.PerformLayout();
            this.historyInfoContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView employeeListContainer;
		private System.Windows.Forms.ComboBox gGender;
		private System.Windows.Forms.TextBox gLastName;
		private System.Windows.Forms.TextBox gFirstName;
		private System.Windows.Forms.TextBox gEmail;
		private System.Windows.Forms.DateTimePicker gOnboard;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button revertBtn;
		private System.Windows.Forms.Label gLevelDisplay;
		private System.Windows.Forms.Label gTitleDisplay;
		private System.Windows.Forms.GroupBox generalInfoContainer;
		private System.Windows.Forms.Label gManagerDisplay;
		private System.Windows.Forms.Label gSalaryDisplay;
		private System.Windows.Forms.Button newEmpBtn;
		private System.Windows.Forms.GroupBox historyInfoContainer;
		private System.Windows.Forms.Button createHistoryBtn;
		private System.Windows.Forms.ListView historyListContainer;
		private System.Windows.Forms.ColumnHeader h_date;
		private System.Windows.Forms.ColumnHeader h_title;
		private System.Windows.Forms.ColumnHeader h_level;
		private System.Windows.Forms.ColumnHeader h_salary;
		private System.Windows.Forms.ColumnHeader h_bonus;
		private System.Windows.Forms.ColumnHeader h_action;
		private System.Windows.Forms.ColumnHeader h_manager;
		private System.Windows.Forms.Label ReviewInfo;
		private System.Windows.Forms.Button accessAnalyticsBtn;
		private System.Windows.Forms.CheckBox showDev;
		private System.Windows.Forms.CheckBox showQa;
		private System.Windows.Forms.CheckBox showTpm;
		private System.Windows.Forms.CheckBox showUe;
		private System.Windows.Forms.ColumnHeader NextReview;
		private System.Windows.Forms.Label GlobalReviewInfo;
		private System.Windows.Forms.Label YofEmpValue;
	}
}

