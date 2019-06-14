using LiteDB;
using PersistenceAccess.Entities;
using PersistenceAccess.Factories;
using System;

namespace PersistenceAccess.DataContracts
{
	public class StatusChangeHistoryDC : StatusChangeHistory
	{
		public string ManagerName { get; set; }
	}
}
