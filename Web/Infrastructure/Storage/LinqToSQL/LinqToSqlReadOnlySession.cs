using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Web.Infrastructure.Storage {
    public class LinqToSqlReadOnlySession:IReadOnlySession {
        DataContext _db;
        public LinqToSqlReadOnlySession(DataContext db) {
            _db = db;

            //no need for object tracking here - it's read only
            _db.ObjectTrackingEnabled = false;
        }

        /// <summary>
        /// Gets the table provided by the type T and returns for querying
        /// </summary>
        private Table<T> GetTable<T>() where T : class, new() {
            return _db.GetTable<T>();
        }


        public void Dispose() {
            _db.Dispose();
        }

        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new() {
            return GetTable<T>().SingleOrDefault(expression);
        }

        public IQueryable<T> All<T>() where T : class, new() {
            return GetTable<T>().AsQueryable();
        }


    }
}
