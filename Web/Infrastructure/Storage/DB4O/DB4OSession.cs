using Db4objects.Db4o;
using System.Linq;
using Db4objects.Db4o.Linq;
using System.Web;
using System.IO;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Web.Infrastructure.Storage {

    public class Db4oSession : IDisposable, ISession {
        
        private IObjectContainer db;
        public Db4oSession(INoSqlServer server) {
            db = server.DB;
            
        }
        /// <summary>
        /// Returns all T records in the repository
        /// </summary>
        public IQueryable<T> All<T>() where T : class, new() {
            return (from T items in db
                    select items).AsQueryable();
        }

        /// <summary>
        /// Finds an item using a passed-in expression lambda
        /// </summary>
        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new() {
            return All<T>().SingleOrDefault(expression);
        }

        /// <summary>
        /// Inserts an item in the database
        /// </summary>
        /// <param name="item"></param>
        public void Add<T>(T item) where T : class, new() {
            db.Store(item);
        }

        /// <summary>
        /// Inserts an item in the database
        /// </summary>
        /// <param name="item"></param>
        public void Add<T>(IEnumerable<T> items) where T : class, new() {
            foreach (var item in items) {
                db.Store(item);
            }
        }

        /// <summary>
        /// Updates an item in the database
        /// </summary>
        /// <param name="item"></param>
        public void Update<T>(T item) where T : class, new() {
            db.Store(item);
        }


        /// <summary>
        /// Deletes an item from the database
        /// </summary>
        /// <param name="item"></param>
        public void Delete<T>(T item) where T : class, new() {
            db.Delete(item);
        }

        /// <summary>
        /// Deletes subset of objects
        /// </summary>
        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class, new() {
            var items = All<T>().Where(expression).ToList();
            items.ForEach(x => db.Delete(x));
        }

        /// <summary>
        /// Deletes all T objects
        /// </summary>
        public void DeleteAll<T>() where T : class, new() {
            var items = All<T>().ToList();
            items.ForEach(x => db.Delete(x));
        }


        /// <summary>
        /// Commits changes to disk
        /// </summary>
        public void CommitChanges() {
            //commit the changes
            db.Commit();

        }
        public void Dispose() {
            //explicitly close
            db.Close();
            //dispose 'em
            db.Dispose();
        }
    }
}