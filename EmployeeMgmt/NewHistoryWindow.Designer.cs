namespace EmployeeMgmt
{
	partial class NewHistoryWindow
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
			System.Windows.Forms.Label bonusLabel;
			System.Windows.Forms.Label managerLabel;
			System.Windows.Forms.Label salaryLabel;
			System.Windows.Forms.Label levelLable;
			System.Windows.Forms.Label titleLable;
			System.Windows.Forms.Label dateLabel;
			System.Windows.Forms.Label actionLabel;
			this.bonus = new System.Windows.Forms.NumericUpDown();
			this.salary = new System.Windows.Forms.NumericUpDown();
			this.manager = new System.Windows.Forms.ComboBox();
			this.level = new System.Windows.Forms.ComboBox();
			this.title = new System.Windows.Forms.ComboBox();
			this.date = new System.Windows.Forms.DateTimePicker();
			this.createBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.action = new System.Windows.Forms.ComboBox();
			bonusLabel = new System.Windows.Forms.Label();
			managerLabel = new System.Windows.Forms.Label();
			salaryLabel = new System.Windows.Forms.Label();
			levelLable = new System.Windows.Forms.Label();
			titleLable = new System.Windows.Forms.Label();
			dateLabel = new System.Windows.Forms.Label();
			actionLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.bonus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.salary)).BeginInit();
			this.SuspendLayout();
			// 
			// bonusLabel
			// 
			bonusLabel.AutoSize = true;
			bonusLabel.Location = new System.Drawing.Point(324, 95);
			bonusLabel.Name = "bonusLabel";
			bonusLabel.Size = new System.Drawing.Size(71, 13);
			bonusLabel.TabIndex = 54;
			bonusLabel.Text = "Bonus (CAD):";
			// 
			// managerLabel
			// 
			managerLabel.AutoSize = true;
			managerLabel.Location = new System.Drawing.Point(35, 136);
			managerLabel.Name = "managerLabel";
			managerLabel.Size = new System.Drawing.Size(52, 13);
			managerLabel.TabIndex = 49;
			managerLabel.Text = "Manager:";
			// 
			// salaryLabel
			// 
			salaryLabel.AutoSize = true;
			salaryLabel.Location = new System.Drawing.Point(17, 95);
			salaryLabel.Name = "salaryLabel";
			salaryLabel.Size = new System.Drawing.Size(70, 13);
			salaryLabel.TabIndex = 48;
			salaryLabel.Text = "Salary (CAD):";
			// 
			// levelLable
			// 
			levelLable.AutoSize = true;
			levelLable.Location = new System.Drawing.Point(359, 59);
			levelLable.Name = "levelLable";
			levelLable.Size = new System.Drawing.Size(36, 13);
			levelLable.TabIndex = 47;
			levelLable.Text = "Level:";
			// 
			// titleLable
			// 
			titleLable.AutoSize = true;
			titleLable.Location = new System.Drawing.Point(57, 59);
			titleLable.Name = "titleLable";
			titleLable.Size = new System.Drawing.Size(30, 13);
			titleLable.TabIndex = 46;
			titleLable.Text = "Title:";
			// 
			// dateLabel
			// 
			dateLabel.AutoSize = true;
			dateLabel.Location = new System.Drawing.Point(54, 26);
			dateLabel.Name = "dateLabel";
			dateLabel.Size = new System.Drawing.Size(33, 13);
			dateLabel.TabIndex = 44;
			dateLabel.Text = "Date:";
			// 
			// actionLabel
			// 
			actionLabel.AutoSize = true;
			actionLabel.Location = new System.Drawing.Point(47, 176);
			actionLabel.Name = "actionLabel";
			actionLabel.Size = new System.Drawing.Size(40, 13);
			actionLabel.TabIndex = 56;
			actionLabel.Text = "Action:";
			// 
			// bonus
			// 
			this.bonus.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.bonus.Location = new System.Drawing.Point(401, 93);
			this.bonus.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.bonus.Name = "bonus";
			this.bonus.Size = new System.Drawing.Size(154, 20);
			this.bonus.TabIndex = 55;
			this.bonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.bonus.ThousandsSeparator = true;
			// 
			// salary
			// 
			this.salary.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.salary.Location = new System.Drawing.Point(93, 93);
			this.salary.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.salary.Name = "salary";
			this.salary.Size = new System.Drawing.Size(225, 20);
			this.salary.TabIndex = 53;
			this.salary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.salary.ThousandsSeparator = true;
			// 
			// manager
			// 
			this.manager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.manager.FormattingEnabled = true;
			this.manager.Location = new System.Drawing.Point(93, 133);
			this.manager.Name = "manager";
			this.manager.Size = new System.Drawing.Size(225, 21);
			this.manager.TabIndex = 52;
			// 
			// level
			// 
			this.level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.level.FormattingEnabled = true;
			this.level.Location = new System.Drawing.Point(401, 56);
			this.level.Name = "level";
			this.level.Size = new System.Drawing.Size(154, 21);
			this.level.TabIndex = 51;
			// 
			// title
			// 
			this.title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.title.FormattingEnabled = true;
			this.title.Location = new System.Drawing.Point(93, 56);
			this.title.Name = "title";
			this.title.Size = new System.Drawing.Size(225, 21);
			this.title.TabIndex = 50;
			// 
			// date
			// 
			this.date.Location = new System.Drawing.Point(93, 20);
			this.date.Name = "date";
			this.date.Size = new System.Drawing.Size(225, 20);
			this.date.TabIndex = 45;
			// 
			// createBtn
			// 
			this.createBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.createBtn.Location = new System.Drawing.Point(407, 205);
			this.createBtn.Name = "createBtn";
			this.createBtn.Size = new System.Drawing.Size(75, 23);
			this.createBtn.TabIndex = 43;
			this.createBtn.Text = "Create";
			this.createBtn.UseVisualStyleBackColor = true;
			this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(488, 205);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 42;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// action
			// 
			this.action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.action.FormattingEnabled = true;
			this.action.Location = new System.Drawing.Point(93, 171);
			this.action.Name = "action";
			this.action.Size = new System.Drawing.Size(225, 21);
			this.action.TabIndex = 57;
			// 
			// NewHistoryWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(575, 240);
			this.Controls.Add(this.action);
			this.Controls.Add(actionLabel);
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
			this.Controls.Add(this.date);
			this.Controls.Add(dateLabel);
			this.Controls.Add(this.createBtn);
			this.Controls.Add(this.cancelBtn);
			this.Name = "NewHistoryWindow";
			this.Text = "Create History";
			((System.ComponentModel.ISupportInitialize)(this.bonus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.salary)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown bonus;
		private System.Windows.Forms.NumericUpDown salary;
		private System.Windows.Forms.ComboBox manager;
		private System.Windows.Forms.ComboBox level;
		private System.Windows.Forms.ComboBox title;
		private System.Windows.Forms.DateTimePicker date;
		private System.Windows.Forms.Button createBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.ComboBox action;
	}
}