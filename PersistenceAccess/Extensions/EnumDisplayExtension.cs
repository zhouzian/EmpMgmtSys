using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PersistenceAccess.Extensions
{
	public static class EnumDisplayExtension
	{
		public static string GetDisplayName(this Enum enumValue)
		{
			return enumValue.GetType().GetMember(enumValue.ToString())
						   .First()
						   .GetCustomAttribute<DisplayAttribute>()
						   .Name;
		}
	}
}
