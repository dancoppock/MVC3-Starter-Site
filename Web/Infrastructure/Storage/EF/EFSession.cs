using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.Metadata.Edm;

namespace Web.Infrastructure.Storage {
    public class EFSession:ISession {
        ObjectContext _context;
        public EFSession(ObjectContext context) {
            _context = context;
        }

        
        public void CommitChanges() {
            _context.SaveChanges();
        }

        string GetSetName<T>() {

            //If you get an error here it's because your namespace
            //for your EDM doesn't match the partial model class
            //to change - open the properties for the EDM FILE and change "Custom Tool Namespace"
            //Not - this IS NOT the Namespace setting in the EDM designer - that's for something
            //else entirely. This is for the EDMX file itself (r-click, properties)

            var entitySetProperty =
            _context.GetType().GetProperties()
               .Single(p => p.PropertyType.IsGenericType && typeof(IQueryable<>)
               .MakeGenericType(typeof(T)).IsAssignableFrom(p.PropertyType));

            return entitySetProperty.Name;
        }
        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new() {

            var query = All<T>().Where(expression);
            foreach (var item in query) {
                Delete(item);
            }
        }

        public void Delete<T>(T item) where T: class, new() {
            _context.DeleteObject(item);
        }

        public void DeleteAll<T>() where T: class, new() {
            var query = All<T>();
            foreach (var item in query) {
                Delete(item);
            }
        }

        public void Dispose() {
            _context.Dispose();
        }

        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new() {
            return All<T>().FirstOrDefault(expression);
        }

        public IQueryable<T> All<T>() where T: class, new() {
            return _context.CreateQuery<T>(GetSetName<T>()).AsQueryable();
        }

        public void Add<T>(T item) where T: class, new() {
            _context.AddObject(GetSetName<T>(),item);
        }
        public void Add<T>(IEnumerable<T> items) where T: class, new() {
            foreach (var item in items) {
                Add(item);
            }
        }
        public void Update<T>(T item) where T: class, new() {
            //nothing needed here
        }
    }
}