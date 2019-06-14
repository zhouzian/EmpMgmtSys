using LiteDB;
using PersistenceAccess.Entities;
using PersistenceAccess.Extensions;
using PersistenceAccess.Factories;
using PersistenceAccess.Policies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersistenceAccess.DataContracts
{
	public class EmployeeDC : Employee
	{
		public Employee CurrentManager { get; set; }

		public Title CurrentTitle { get; set; }

		public Level CurrentLevel { get; set; }

		public Decimal CurrentSalary { get; set; }

		public DateTime? ResignDate { get; set; }

		public IEnumerable<StatusChangeHistoryDC> History { get; set; }

		public string ManagerName {
			get
			{
				if (CurrentManager.Id == Guid.Empty)
				{
					return string.Empty;
				}
				else
				{
					return CurrentManager.FirstName + " " + CurrentManager.LastName;
				}
			}
		}

		public string FullName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}

        public string Position
        {
            get
            {
                if (CurrentLevel == Level.NONE || CurrentLevel == Level.I || CurrentLevel == Level.II || CurrentLevel == Level.III)
                {
                    return CurrentTitle.GetDisplayName() + " " + CurrentLevel.GetDisplayName();
                }
                else
                {
                    return CurrentLevel.GetDisplayName() + " " + CurrentTitle.GetDisplayName();
                }
            }
        }

		/// <summary>
		/// Returns the next annual performance review date. The date is populated in the constructor when an Employee object is passed in.
		/// </summary>
		public DateTime? NextReviewDate { get; set; }

		public int YearOfEmployment { get; set; }
	}
}
