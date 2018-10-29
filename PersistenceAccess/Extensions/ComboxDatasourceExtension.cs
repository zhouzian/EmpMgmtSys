using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersistenceAccess.Extensions
{
	public static class ComboxDatasourceExtension
	{
		public static void RenderDatasource(this ComboBox comboBox, Type data)
		{
			IList<object> ds = new List<object>();
			foreach(Enum item in Enum.GetValues(data))
			{
				ds.Add(new { dName = item.GetDisplayName(), Value = item });
			}
			comboBox.DataSource = ds;
			comboBox.DisplayMember = "dName";
			comboBox.ValueMember = "Value";
		}
	}
}
