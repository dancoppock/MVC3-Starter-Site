using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.Repository;

namespace Web.Infrastructure.Storage {
    public class SubSonicSimple:ISession {

        SimpleRepository _repo;
        public SubSonicSimple() {
            //this is setup to run migrations during development
            //which means you can have your model generated into the DB for you
            //see http://subsonicproject.com/docs/Using_SimpleRepository
            var options = SimpleRepositoryOptions.Default;
            if (Web.MvcApplication.Environment == AppEnvironment.Development)
                options = SimpleRepositoryOptions.RunMigrations;
            _repo = new SimpleRepository(options);
        }
        
        public void CommitChanges() {
            //this just happens... there's no Unit of Work with Simple Repo
        }

        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new() {
            _repo.DeleteMany<T>(expression);
        }

        public void Delete<T>(T item) where T: class, new() {
            _repo.DeleteMany<T>(new T[]{item});
        }

        public void DeleteAll<T>() where T: class, new() {
            _repo.DeleteMany(_repo.All<T>());
        }

        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new() {
            return _repo.Single<T>(expression);
        }

        public IQueryable<T> All<T>() where T: class, new() {
            return _repo.All<T>();
        }

        public void Add<T>(T item) where T: class, new() {
            _repo.Add<T>(item);
        }

        public void Add<T>(IEnumerable<T> items) where T: class, new() {
            _repo.AddMany(items);
        }

        public void Update<T>(T item) where T: class, new() {
            _repo.Update(item);
        }

        public void Dispose() {
            _repo = null;
        }
    }
}