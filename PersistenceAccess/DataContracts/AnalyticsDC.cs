using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceAccess.DataContracts
{
	public class AnalyticsDC
	{
		public StatisticDC TotalActiveEmployeeStatistic { get; set; }

		public LevelStatisticDC DEVStatistic { get; set; }

		public LevelStatisticDC QAStatistic { get; set; }

		public LevelStatisticDC TPMStatistic { get; set; }

		public LevelStatisticDC UEStatistic { get; set; }
	}

	public class StatisticDC
	{
		public int Count { get; set; }

		public decimal Total { get; set; }

		public decimal Average { get; set; }

		public decimal Max { get; set; }

		public decimal Min { get; set; }
	}

	public class LevelStatisticDC : StatisticDC
	{
		public int None_Count { get; set; }

		public int I_Count { get; set; }

		public int II_Count { get; set; }

		public int III_Count { get; set; }

		public int Senior_Count { get; set; }

		public int Staff_Count { get; set; }

        public int Senior_Staff_Count { get; set; }

		public int Principle_Count { get; set; }
	}
}
