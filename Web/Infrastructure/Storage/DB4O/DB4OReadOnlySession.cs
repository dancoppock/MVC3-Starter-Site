using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace Web.Infrastructure.Storage {
    public class DB4OReadOnlySession:IReadOnlySession {
        
        private IObjectContainer db;
        
        public DB4OReadOnlySession(INoSqlServer server) {
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
    }
}
