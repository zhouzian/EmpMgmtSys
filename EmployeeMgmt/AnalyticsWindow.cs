using PersistenceAccess.DataContracts;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace EmployeeMgmt
{
	public partial class AnalyticsWindow : Form
	{
		public AnalyticsWindow()
		{
			InitializeComponent();
			PopulateDate();
		}

		private void PopulateDate()
		{
			AnalyticsDC result = AppView.GetAnaltyics();
			PopulateOverallSection(result);
			PopulateDEVSection(result);
			PopulateQASection(result);
			PopulateTPMSection(result);
			PopulateUESection(result);
		}

		private void PopulateOverallSection(AnalyticsDC result)
		{
			this.allCountValue.Text = result.TotalActiveEmployeeStatistic.Count.ToString();
			this.allAverageValue.Text = result.TotalActiveEmployeeStatistic.Average.ToString("C0");
			this.allTotalValue.Text = result.TotalActiveEmployeeStatistic.Total.ToString("C0");
			this.allMaxValue.Text = result.TotalActiveEmployeeStatistic.Max.ToString("C0");
			this.allMinValue.Text = result.TotalActiveEmployeeStatistic.Min.ToString("C0");
		}

		private void PopulateDEVSection(AnalyticsDC result)
		{
			string[] x = new string[] { "None: " + result.DEVStatistic.None_Count,
				"I: " + result.DEVStatistic.I_Count,
				"II: " + result.DEVStatistic.II_Count,
				"III: " + result.DEVStatistic.III_Count,
				"Senior: " + result.DEVStatistic.Senior_Count,
				"Staff: " + result.DEVStatistic.Staff_Count,
				"Principle: " + result.DEVStatistic.Principle_Count };
			int[] y = new int[] { result.DEVStatistic.None_Count, result.DEVStatistic.I_Count, result.DEVStatistic.II_Count, result.DEVStatistic.III_Count, result.DEVStatistic.Senior_Count, result.DEVStatistic.Staff_Count, result.DEVStatistic.Principle_Count };
			this.devPie.Series[0].Points.DataBindXY(x, y);
			this.devPie.Series[0]["PieLabelStyle"] = "Disabled";

			this.devCountValue.Text = result.DEVStatistic.Count.ToString();
			this.devAverageValue.Text = result.DEVStatistic.Average.ToString("C0");
			this.devTotalValue.Text = result.DEVStatistic.Total.ToString("C0");
			this.devMaxValue.Text = result.DEVStatistic.Max.ToString("C0");
			this.devMinValue.Text = result.DEVStatistic.Min.ToString("C0");
		}

		private void PopulateQASection(AnalyticsDC result)
		{
			string[] x = new string[] { "None: " + result.QAStatistic.None_Count,
				"I: " + result.QAStatistic.I_Count,
				"II: " + result.QAStatistic.II_Count,
				"III: " + result.QAStatistic.III_Count,
				"Senior: " + result.QAStatistic.Senior_Count,
				"Staff: " + result.QAStatistic.Staff_Count,
				"Principle: " + result.QAStatistic.Principle_Count };
			int[] y = new int[] { result.QAStatistic.None_Count, result.QAStatistic.I_Count, result.QAStatistic.II_Count, result.QAStatistic.III_Count, result.QAStatistic.Senior_Count, result.QAStatistic.Staff_Count, result.QAStatistic.Principle_Count };
			this.qaPie.Series[0].Points.DataBindXY(x, y);
			this.qaPie.Series[0]["PieLabelStyle"] = "Disabled";

			this.qaCountValue.Text = result.QAStatistic.Count.ToString();
			this.qaAverageValue.Text = result.QAStatistic.Average.ToString("C0");
			this.qaTotalValue.Text = result.QAStatistic.Total.ToString("C0");
			this.qaMaxValue.Text = result.QAStatistic.Max.ToString("C0");
			this.qaMinValue.Text = result.QAStatistic.Min.ToString("C0");
		}

		private void PopulateTPMSection(AnalyticsDC result)
		{
			string[] x = new string[] { "None: " + result.TPMStatistic.None_Count,
				"I: " + result.TPMStatistic.I_Count,
				"II: " + result.TPMStatistic.II_Count,
				"III: " + result.TPMStatistic.III_Count,
				"Senior: " + result.TPMStatistic.Senior_Count,
				"Staff: " + result.TPMStatistic.Staff_Count,
				"Principle: " + result.TPMStatistic.Principle_Count };
			int[] y = new int[] { result.TPMStatistic.None_Count, result.TPMStatistic.I_Count, result.TPMStatistic.II_Count, result.TPMStatistic.III_Count, result.TPMStatistic.Senior_Count, result.TPMStatistic.Staff_Count, result.TPMStatistic.Principle_Count };
			this.tpmPie.Series[0].Points.DataBindXY(x, y);
			this.tpmPie.Series[0]["PieLabelStyle"] = "Disabled";

			this.tpmCountValue.Text = result.TPMStatistic.Count.ToString();
			this.tpmAverageValue.Text = result.TPMStatistic.Average.ToString("C0");
			this.tpmTotalValue.Text = result.TPMStatistic.Total.ToString("C0");
			this.tpmMaxValue.Text = result.TPMStatistic.Max.ToString("C0");
			this.tpmMinValue.Text = result.TPMStatistic.Min.ToString("C0");
		}

		private void PopulateUESection(AnalyticsDC result)
		{
			string[] x = new string[] { "None: " + result.UEStatistic.None_Count,
				"I: " + result.UEStatistic.I_Count,
				"II: " + result.UEStatistic.II_Count,
				"III: " + result.UEStatistic.III_Count,
				"Senior: " + result.UEStatistic.Senior_Count,
				"Staff: " + result.UEStatistic.Staff_Count,
				"Principle: " + result.UEStatistic.Principle_Count };
			int[] y = new int[] { result.UEStatistic.None_Count, result.UEStatistic.I_Count, result.UEStatistic.II_Count, result.UEStatistic.III_Count, result.UEStatistic.Senior_Count, result.UEStatistic.Staff_Count, result.UEStatistic.Principle_Count };
			this.uePie.Series[0].Points.DataBindXY(x, y);
			this.uePie.Series[0]["PieLabelStyle"] = "Disabled";

			this.ueCountValue.Text = result.UEStatistic.Count.ToString();
			this.ueAverageValue.Text = result.UEStatistic.Average.ToString("C0");
			this.ueTotalValue.Text = result.UEStatistic.Total.ToString("C0");
			this.ueMaxValue.Text = result.UEStatistic.Max.ToString("C0");
			this.ueMinValue.Text = result.UEStatistic.Min.ToString("C0");
		}
	}
}
