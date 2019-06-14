using LiteDB;
using PersistenceAccess.Entities;
using System;

namespace PersistenceAccess.Factories
{
	public class PersistenceStore : IDisposable
    {
        private readonly LiteDatabase db;

        private static readonly Lazy<PersistenceStore> instance = new Lazy<PersistenceStore>(() => new PersistenceStore());

        private PersistenceStore()
        {
            db = new LiteDatabase(Constants.DB_NAME);
        }

        public static PersistenceStore Current {
            get
            {
                return instance.Value;
            }
        }

		public LiteCollection<Employee> GetEmployeeStore()
		{
			return db.GetCollection<Employee>(Constants.EMPLOYEE_COLLECTION_NAME);
		}

		public LiteCollection<StatusChangeHistory> GetHistoryStore()
		{
			db.GetCollection<StatusChangeHistory>(Constants.HISTORY_COLLECTION_NAME).EnsureIndex(his => his.EmployeeId);
			return db.GetCollection<StatusChangeHistory>(Constants.HISTORY_COLLECTION_NAME);
		}

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PersistenceStore()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
