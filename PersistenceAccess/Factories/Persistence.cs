using LiteDB;
using PersistenceAccess.Entities;

namespace PersistenceAccess.Factories
{
	public class Persistence
	{
		public static LiteCollection<Employee> GetEmployeeStore(LiteDatabase db)
		{
			return db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
		}

		public static LiteCollection<StatusChangeHistory> GetHistoryStore(LiteDatabase db)
		{
			db.GetCollection<StatusChangeHistory>(Constants.HISTORY_COLLECTION_NAME).EnsureIndex(his => his.EmployeeId);
			return db.GetCollection<StatusChangeHistory>(Constants.HISTORY_COLLECTION_NAME);
		}
	}
}
