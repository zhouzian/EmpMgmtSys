using LiteDB;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceAccess.Entities
{
	public class StatusChangeHistory
	{
		[BsonId]
		[BsonField("id")]
		public Guid Id { get; set; }

		[BsonField("employee_id")]
		public Guid EmployeeId { get; set; }

		[BsonField("date")]
		public DateTime Date { get; set; }

		[BsonField("manager_id")]
		public Guid ManagerId { get; set; }

		[BsonField("title")]
		public Title Title { get; set; }

		[BsonField("level")]
		public Level Level { get; set; }

		[BsonField("salary")]
		public Decimal Salary { get; set; }

		[BsonField("bonus")]
		public Decimal Bonus { get; set; }

		[BsonField("action")]
		public ActionType Action { get; set; }
	}

	public enum Title
	{
		[Display(Name = "Software Engineer")]
		SOFTWARE_ENGINEER = 0,

		[Display(Name = "Software Engineer in Test")]
		SOFTWARE_ENGINEER_IN_TEST = 1,

		[Display(Name = "Software Test Engineer")]
		SOFTWARE_TEST_ENGINEER = 2,

		[Display(Name = "Technical Product Manager")]
		TECHNICAL_PRODUCT_MANAGER = 3,

		[Display(Name = "Technical Writer")]
		TECHNICAL_WRITER = 4
	}

	public enum Level
	{
		[Display(Name = "N/A")]
		NONE = 0,

		[Display(Name = "I")]
		I = 1,

		[Display(Name = "II")]
		II = 2,

		[Display(Name = "III")]
		III = 3,

		[Display(Name = "Senior")]
		SENIOR = 4,

		[Display(Name = "Staff")]
		STAFF = 5,

		[Display(Name = "Principle")]
		PRINCIPLE = 6
	}

	public enum ActionType
	{
		[Display(Name = "Resign")]
		RESIGN = 0,

		[Display(Name = "Onboard")]
		ONBOARD = 1,

		[Display(Name = "Annual performance review")]
		ANNUAL_PERFORMANCE_REVIEW = 2,

		[Display(Name = "3 month performance review")]
		THREE_MONTH_REVIEW = 3,

		[Display(Name = "6 month performance review")]
		SIX_MONTH_REVIEW = 4,

		[Display(Name = "Manager change")]
		MANAGER_CHANGE = 5,

		[Display(Name = "Title change")]
		TITLE_CHANGE = 6,

		[Display(Name = "Compensation change")]
		COMPENSATION_CHANGE = 7
	}
}
