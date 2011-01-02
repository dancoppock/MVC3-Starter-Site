using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure.Storage {
    public class InMemorySession:ISession {

        IList<Object> _list;
        public InMemorySession() {
            _list = new List<Object>();
        }
        public void CommitChanges() {
            //nada
        }

        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new() {
            //cast it
            var items = All<T>().Where(expression);
            for (int i = 0; i < items.Count(); i++) {
                var item = _list[i];
                if (item.GetType() == typeof(T)) {
                    Delete(item);
                }
            }

        }

        public void Delete<T>(T item) where T: class, new() {
            _list.Remove(item);
        }

        public void DeleteAll<T>() where T: class, new() {

            for (int i = 0; i < _list.Count; i++)
			{
			    var item = _list[i];
                if (item.GetType() == typeof(T)) {
                    Delete(item);
                }
			}
        }

        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new() {
            return All<T>().Where(expression).SingleOrDefault();
        }

        public IQueryable<T> All<T>() where T: class, new() {
            var result = new List<T>();
            foreach (var item in _list) {
                if (item.GetType() == typeof(T)) {
                    result.Add(item as T);
                }
            }
            return result.AsQueryable();
        }

        public void Add<T>(T item) where T: class, new() {
            _list.Add(item);
        }

        public void Add<T>(IEnumerable<T> items) where T: class, new() {
            foreach (var item in items) {
                Add(item);
            }
        }

        public void Update<T>(T item) where T: class, new() {
            //don't need to do nada here
        }


        public void Dispose() {
            throw new NotImplementedException();
        }

    }
}