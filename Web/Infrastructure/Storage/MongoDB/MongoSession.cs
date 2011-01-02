using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Norm.Linq;
using Norm;
using Norm.Configuration;
using Norm.Responses;
using Norm.Collections;

namespace Web.Infrastructure.Storage {
    public class MongoSession : ISession{

        private MongoQueryProvider _provider;

        public MongoSession()
        {
            //this looks for a connection string in your Web.config - you can override this if you want
            _provider = new MongoQueryProvider(Mongo.Create("MongoDB"));
        }

        public void CommitChanges() {
            //mongo isn't transactional in this way... it's all firehosed
        }

        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new() {
            var items = All<T>().Where(expression);
            foreach (T item in items) {
                Delete(item);
            }
        }

        public void Delete<T>(T item) where T: class, new() {
            _provider.DB.GetCollection<T>().Delete(item);
        }

        public void DeleteAll<T>() where T: class, new() {
            _provider.DB.DropCollection(typeof(T).Name);

        }

        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T: class, new() {
            return new MongoQuery<T>(_provider).Where(expression).SingleOrDefault();
        }

        public IQueryable<T> All<T>() where T: class, new() {
            return new MongoQuery<T>(_provider);
        }

        public void Add<T>(T item) where T: class, new() {
            _provider.DB.GetCollection<T>().Insert(item);
        }

        public void Add<T>(IEnumerable<T> items) where T: class, new() {
            foreach (T item in items) {
                Add(item);
            }
        }

        public void Update<T>(T item) where T: class, new() {
            _provider.DB.GetCollection<T>().UpdateOne(item, item);
        }

        //this is just some sugar if you need it.
        public T MapReduce<T>(string map, string reduce) {
            T result = default(T);
            using (MapReduce mr = _provider.Server.CreateMapReduce()) {
                MapReduceResponse response =
                    mr.Execute(new MapReduceOptions(typeof(T).Name) {
                        Map = map,
                        Reduce = reduce
                    });
                MongoCollection<MapReduceResult<T>> coll = response.GetCollection<MapReduceResult<T>>();
                MapReduceResult<T> r = coll.Find().FirstOrDefault();
                result = r.Value;
            }
            return result;
        }

        public void Dispose() {
            _provider.Server.Dispose();
        }


    }
}