using LiteDB;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersistenceAccess.Entities
{
	public class Employee
	{
		[BsonId]
		[BsonField("id")]
		public Guid Id { get; set; }

		[BsonField("first_name")]
		public string FirstName { get; set; }

		[BsonField("last_name")]
		public string LastName { get; set; }

		[BsonField("gender")]
		public Gender Gender { get; set; }

		[BsonField("email")]
		public string Email { get; set; }

		[BsonField("onboard_date")]
		public DateTime OnboardDate { get; set; }
	}

	public enum Gender
	{
		[Display(Name = "Male")]
		MALE = 0,

		[Display(Name = "Female")]
		FEMALE = 1
	}
}
