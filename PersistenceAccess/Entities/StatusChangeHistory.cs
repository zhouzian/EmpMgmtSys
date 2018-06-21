using LiteDB;
using System;

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
		SOFTWARE_ENGINEER = 0,
		SOFTWARE_ENGINEER_IN_TEST = 1,
		SOFTWARE_TEST_ENGINEER = 2,
		TECHNICAL_PRODUCT_MANAGER = 3,
		TECHNICAL_WRITER = 4
	}

	public enum Level
	{
		NONE = 0,
		I = 1,
		II = 2,
		III = 3,
		SENIOR = 4,
		STAFF = 5,
		PRINCIPLE = 6
	}

	public enum ActionType
	{
		RESIGN = 0,
		ONBOARD = 1,
		ANNUAL_PERFORMANCE_REVIEW = 2,
		THREE_MONTH_REVIEW = 3,
		SIX_MONTH_REVIEW = 4,
		MANAGER_CHANGE = 5,
		TITLE_CHANGE = 6
	}
}
