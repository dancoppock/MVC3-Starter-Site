using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using SubSonic.Extensions;

namespace Web.Infrastructure.Storage {
    public class LinqToSqlSession:ISession {
        protected DataContext _db;
        protected LinqToSqlSession(DataContext dc) {
            _db = dc;
        }

        public void CommitChanges() {
            _db.SubmitChanges();
        }
        /// <summary>
        /// Gets the table provided by the type T and returns for querying
        /// </summary>
        private Table<T> GetTable<T>() where T:class {
            //if you get an error here RE "can't find the table name"
            //it's because your Linq to SQL namespace needs to match 
            //the namespace of your model
            
            return _db.GetTable<T>();
        }
        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new(){

            var query = All<T>().Where(expression);
            GetTable<T>().DeleteAllOnSubmit(query);
        }

        public void Delete<T>(T item) where T: class, new() {
            GetTable<T>().DeleteOnSubmit(item);
        }

        public void DeleteAll<T>() where T: class, new() {
            var query = All<T>();
            GetTable<T>().DeleteAllOnSubmit(query);
        }

        public void Dispose() {
            _db.Dispose();
        }

        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T:class, new() {
            return GetTable<T>().SingleOrDefault(expression);
        }

        public IQueryable<T> All<T>() where T: class, new() {
            return GetTable<T>().AsQueryable();
        }

        public void Add<T>(T item) where T: class, new() {
            GetTable<T>().InsertOnSubmit(item);
        }
        public void Add<T>(IEnumerable<T> items) where T: class, new() {
            GetTable<T>().InsertAllOnSubmit(items);
        }
        public void Update<T>(T item) where T: class, new() {
            //nothing needed here
        }

    }
}
