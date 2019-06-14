namespace EmployeeMgmt
{
	partial class NewEmployeeWindow
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
            base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label managerLabel;
			System.Windows.Forms.Label salaryLabel;
			System.Windows.Forms.Label levelLable;
			System.Windows.Forms.Label titleLable;
			System.Windows.Forms.Label onboardLabel;
			System.Windows.Forms.Label emailLabel;
			System.Windows.Forms.Label genderLabel;
			System.Windows.Forms.Label lastNameLabel;
			System.Windows.Forms.Label firstNameLabel;
			System.Windows.Forms.Label bonusLabel;
			this.cancelBtn = new System.Windows.Forms.Button();
			this.createBtn = new System.Windows.Forms.Button();
			this.onboard = new System.Windows.Forms.DateTimePicker();
			this.email = new System.Windows.Forms.TextBox();
			this.gender = new System.Windows.Forms.ComboBox();
			this.lastName = new System.Windows.Forms.TextBox();
			this.frstName = new System.Windows.Forms.TextBox();
			this.title = new System.Windows.Forms.ComboBox();
			this.level = new System.Windows.Forms.ComboBox();
			this.manager = new System.Windows.Forms.ComboBox();
			this.salary = new System.Windows.Forms.NumericUpDown();
			this.bonus = new System.Windows.Forms.NumericUpDown();
			managerLabel = new System.Windows.Forms.Label();
			salaryLabel = new System.Windows.Forms.Label();
			levelLable = new System.Windows.Forms.Label();
			titleLable = new System.Windows.Forms.Label();
			onboardLabel = new System.Windows.Forms.Label();
			emailLabel = new System.Windows.Forms.Label();
			genderLabel = new System.Windows.Forms.Label();
			lastNameLabel = new System.Windows.Forms.Label();
			firstNameLabel = new System.Windows.Forms.Label();
			bonusLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.salary)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bonus)).BeginInit();
			this.SuspendLayout();
			// 
			// managerLabel
			// 
			managerLabel.AutoSize = true;
			managerLabel.Location = new System.Drawing.Point(35, 215);
			managerLabel.Name = "managerLabel";
			managerLabel.Size = new System.Drawing.Size(52, 13);
			managerLabel.TabIndex = 35;
			managerLabel.Text = "Manager:";
			// 
			// salaryLabel
			// 
			salaryLabel.AutoSize = true;
			salaryLabel.Location = new System.Drawing.Point(17, 176);
			salaryLabel.Name = "salaryLabel";
			salaryLabel.Size = new System.Drawing.Size(70, 13);
			salaryLabel.TabIndex = 34;
			salaryLabel.Text = "Salary (CAD):";
			// 
			// levelLable
			// 
			levelLable.AutoSize = true;
			levelLable.Location = new System.Drawing.Point(433, 140);
			levelLable.Name = "levelLable";
			levelLable.Size = new System.Drawing.Size(36, 13);
			levelLable.TabIndex = 33;
			levelLable.Text = "Level:";
			// 
			// titleLable
			// 
			titleLable.AutoSize = true;
			titleLable.Location = new System.Drawing.Point(57, 140);
			titleLable.Name = "titleLable";
			titleLable.Size = new System.Drawing.Size(30, 13);
			titleLable.TabIndex = 32;
			titleLable.Text = "Title:";
			// 
			// onboardLabel
			// 
			onboardLabel.AutoSize = true;
			onboardLabel.Location = new System.Drawing.Point(36, 107);
			onboardLabel.Name = "onboardLabel";
			onboardLabel.Size = new System.Drawing.Size(51, 13);
			onboardLabel.TabIndex = 30;
			onboardLabel.Text = "Onboard:";
			// 
			// emailLabel
			// 
			emailLabel.AutoSize = true;
			emailLabel.Location = new System.Drawing.Point(52, 69);
			emailLabel.Name = "emailLabel";
			emailLabel.Size = new System.Drawing.Size(35, 13);
			emailLabel.TabIndex = 28;
			emailLabel.Text = "Email:";
			// 
			// genderLabel
			// 
			genderLabel.AutoSize = true;
			genderLabel.Location = new System.Drawing.Point(424, 35);
			genderLabel.Name = "genderLabel";
			genderLabel.Size = new System.Drawing.Size(45, 13);
			genderLabel.TabIndex = 26;
			genderLabel.Text = "Gender:";
			// 
			// lastNameLabel
			// 
			lastNameLabel.AutoSize = true;
			lastNameLabel.Location = new System.Drawing.Point(225, 36);
			lastNameLabel.Name = "lastNameLabel";
			lastNameLabel.Size = new System.Drawing.Size(61, 13);
			lastNameLabel.TabIndex = 24;
			lastNameLabel.Text = "Last Name:";
			// 
			// firstNameLabel
			// 
			firstNameLabel.AutoSize = true;
			firstNameLabel.Location = new System.Drawing.Point(27, 36);
			firstNameLabel.Name = "firstNameLabel";
			firstNameLabel.Size = new System.Drawing.Size(60, 13);
			firstNameLabel.TabIndex = 22;
			firstNameLabel.Text = "First Name:";
			// 
			// bonusLabel
			// 
			bonusLabel.AutoSize = true;
			bonusLabel.Location = new System.Drawing.Point(215, 176);
			bonusLabel.Name = "bonusLabel";
			bonusLabel.Size = new System.Drawing.Size(71, 13);
			bonusLabel.TabIndex = 40;
			bonusLabel.Text = "Bonus (CAD):";
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(497, 249);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 0;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.CancelBtnClickedHandler);
			// 
			// createBtn
			// 
			this.createBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.createBtn.Location = new System.Drawing.Point(416, 249);
			this.createBtn.Name = "createBtn";
			this.createBtn.Size = new System.Drawing.Size(75, 23);
			this.createBtn.TabIndex = 1;
			this.createBtn.Text = "Create";
			this.createBtn.UseVisualStyleBackColor = true;
			this.createBtn.Click += new System.EventHandler(this.CreateBtnClickedHandler);
			// 
			// onboard
			// 
			this.onboard.Location = new System.Drawing.Point(93, 101);
			this.onboard.Name = "onboard";
			this.onboard.Size = new System.Drawing.Size(299, 20);
			this.onboard.TabIndex = 31;
			// 
			// email
			// 
			this.email.Location = new System.Drawing.Point(93, 66);
			this.email.Name = "email";
			this.email.Size = new System.Drawing.Size(299, 20);
			this.email.TabIndex = 29;
			this.email.TextChanged += new System.EventHandler(this.InputValidationEvtHandler);
			// 
			// gender
			// 
			this.gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gender.FormattingEnabled = true;
			this.gender.Location = new System.Drawing.Point(475, 32);
			this.gender.Name = "gender";
			this.gender.Size = new System.Drawing.Size(97, 21);
			this.gender.TabIndex = 27;
			// 
			// lastName
			// 
			this.lastName.Location = new System.Drawing.Point(292, 33);
			this.lastName.Name = "lastName";
			this.lastName.Size = new System.Drawing.Size(100, 20);
			this.lastName.TabIndex = 25;
			this.lastName.TextChanged += new System.EventHandler(this.InputValidationEvtHandler);
			// 
			// frstName
			// 
			this.frstName.Location = new System.Drawing.Point(93, 33);
			this.frstName.Name = "frstName";
			this.frstName.Size = new System.Drawing.Size(100, 20);
			this.frstName.TabIndex = 23;
			this.frstName.TextChanged += new System.EventHandler(this.InputValidationEvtHandler);
			// 
			// title
			// 
			this.title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.title.FormattingEnabled = true;
			this.title.Location = new System.Drawing.Point(93, 137);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(299, 21);
			this.title.TabIndex = 36;
			// 
			// level
			// 
			this.level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.level.FormattingEnabled = true;
			this.level.Location = new System.Drawing.Point(475, 137);
			this.level.Name = "level";
			this.level.Size = new System.Drawing.Size(97, 21);
			this.level.TabIndex = 37;
			// 
			// manager
			// 
			this.manager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.manager.FormattingEnabled = true;
			this.manager.Location = new System.Drawing.Point(93, 212);
			this.manager.Name = "manager";
			this.manager.Size = new System.Drawing.Size(299, 21);
			this.manager.TabIndex = 38;
			// 
			// salary
			// 
			this.salary.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.salary.Location = new System.Drawing.Point(93, 174);
			this.salary.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.salary.Name = "salary";
			this.salary.Size = new System.Drawing.Size(115, 20);
			this.salary.TabIndex = 39;
			this.salary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.salary.ThousandsSeparator = true;
			// 
			// bonus
			// 
			this.bonus.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.bonus.Location = new System.Drawing.Point(292, 174);
			this.bonus.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.bonus.Name = "bonus";
			this.bonus.Size = new System.Drawing.Size(100, 20);
			this.bonus.TabIndex = 41;
			this.bonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.bonus.ThousandsSeparator = true;
			// 
			// NewEmployeeWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 284);
			this.Controls.Add(this.bonus);
			this.Controls.Add(bonusLabel);
			this.Controls.Add(this.salary);
			this.Controls.Add(this.manager);
			this.Controls.Add(this.level);
			this.Controls.Add(this.title);
			this.Controls.Add(managerLabel);
			this.Controls.Add(salaryLabel);
			this.Controls.Add(levelLable);
			this.Controls.Add(titleLable);
			this.Controls.Add(this.onboard);
			this.Controls.Add(onboardLabel);
			this.Controls.Add(this.email);
			this.Controls.Add(emailLabel);
			this.Controls.Add(this.gender);
			this.Controls.Add(genderLabel);
			this.Controls.Add(this.lastName);
			this.Controls.Add(lastNameLabel);
			this.Controls.Add(this.frstName);
			this.Controls.Add(firstNameLabel);
			this.Controls.Add(this.createBtn);
			this.Controls.Add(this.cancelBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewEmployeeWindow";
			this.Text = "Create Employee";
			((System.ComponentModel.ISupportInitialize)(this.salary)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bonus)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button createBtn;
		private System.Windows.Forms.DateTimePicker onboard;
		private System.Windows.Forms.TextBox email;
		private System.Windows.Forms.ComboBox gender;
		private System.Windows.Forms.TextBox lastName;
		private System.Windows.Forms.TextBox frstName;
		private System.Windows.Forms.ComboBox title;
		private System.Windows.Forms.ComboBox level;
		private System.Windows.Forms.ComboBox manager;
		private System.Windows.Forms.NumericUpDown salary;
		private System.Windows.Forms.NumericUpDown bonus;
	}
}