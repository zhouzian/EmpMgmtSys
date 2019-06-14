using PersistenceAccess.DataContracts;
using PersistenceAccess.Repositories;
using System.Windows.Forms;

namespace EmployeeMgmt
{
	public partial class AnalyticsWindow : Form
	{
        private EmployeeRepository empRepo;
        private AnalyticsRepository anaRepo;
        private ViewGeneratorHelper viewHelper;

        public AnalyticsWindow()
		{
            empRepo = new EmployeeRepository();
            anaRepo = new AnalyticsRepository();
            viewHelper = new ViewGeneratorHelper(empRepo);
            InitializeComponent();
			PopulateDate();
		}

		private void PopulateDate()
		{
			AnalyticsDC result = anaRepo.GetAnaltyics(empRepo);
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
            Legend legend = GenerateLegend(result.DEVStatistic);
            this.devPie.Series[0].Points.DataBindXY(legend.Items, legend.Values);
			this.devPie.Series[0]["PieLabelStyle"] = "Disabled";

			this.devCountValue.Text = result.DEVStatistic.Count.ToString();
			this.devAverageValue.Text = result.DEVStatistic.Average.ToString("C0");
			this.devTotalValue.Text = result.DEVStatistic.Total.ToString("C0");
			this.devMaxValue.Text = result.DEVStatistic.Max.ToString("C0");
			this.devMinValue.Text = result.DEVStatistic.Min.ToString("C0");
		}

		private void PopulateQASection(AnalyticsDC result)
		{
            Legend legend = GenerateLegend(result.QAStatistic);
            this.qaPie.Series[0].Points.DataBindXY(legend.Items, legend.Values);
			this.qaPie.Series[0]["PieLabelStyle"] = "Disabled";

			this.qaCountValue.Text = result.QAStatistic.Count.ToString();
			this.qaAverageValue.Text = result.QAStatistic.Average.ToString("C0");
			this.qaTotalValue.Text = result.QAStatistic.Total.ToString("C0");
			this.qaMaxValue.Text = result.QAStatistic.Max.ToString("C0");
			this.qaMinValue.Text = result.QAStatistic.Min.ToString("C0");
		}

		private void PopulateTPMSection(AnalyticsDC result)
		{
            Legend legend = GenerateLegend(result.TPMStatistic);
            this.tpmPie.Series[0].Points.DataBindXY(legend.Items, legend.Values);
			this.tpmPie.Series[0]["PieLabelStyle"] = "Disabled";

			this.tpmCountValue.Text = result.TPMStatistic.Count.ToString();
			this.tpmAverageValue.Text = result.TPMStatistic.Average.ToString("C0");
			this.tpmTotalValue.Text = result.TPMStatistic.Total.ToString("C0");
			this.tpmMaxValue.Text = result.TPMStatistic.Max.ToString("C0");
			this.tpmMinValue.Text = result.TPMStatistic.Min.ToString("C0");
		}

		private void PopulateUESection(AnalyticsDC result)
		{
            Legend legend = GenerateLegend(result.UEStatistic);
			this.uePie.Series[0].Points.DataBindXY(legend.Items, legend.Values);
			this.uePie.Series[0]["PieLabelStyle"] = "Disabled";

			this.ueCountValue.Text = result.UEStatistic.Count.ToString();
			this.ueAverageValue.Text = result.UEStatistic.Average.ToString("C0");
			this.ueTotalValue.Text = result.UEStatistic.Total.ToString("C0");
			this.ueMaxValue.Text = result.UEStatistic.Max.ToString("C0");
			this.ueMinValue.Text = result.UEStatistic.Min.ToString("C0");
		}

        private Legend GenerateLegend(LevelStatisticDC statistic)
        {
            return new Legend
            {
                Items = new string[] {
                    "None: " + statistic.None_Count,
                    "I: " + statistic.I_Count,
                    "II: " + statistic.II_Count,
                    "III: " + statistic.III_Count,
                    "Senior: " + statistic.Senior_Count,
                    "Staff: " + statistic.Staff_Count,
                    "Principle: " + statistic.Principle_Count
                },
                Values = new int[] {
                    statistic.None_Count,
                    statistic.I_Count,
                    statistic.II_Count,
                    statistic.III_Count,
                    statistic.Senior_Count,
                    statistic.Staff_Count,
                    statistic.Principle_Count
                }
            };
        }

        private struct Legend
        {
            public string[] Items;
            public int[] Values;
        }
    }
}
