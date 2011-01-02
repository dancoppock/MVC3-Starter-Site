using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Db4objects.Db4o;
using System.Configuration;
using System.IO;

namespace Web.Infrastructure.Storage {
    public class DB4OServer : Web.Infrastructure.Storage.INoSqlServer {
    
        IObjectServer _server;
        public DB4OServer() {
            if (_server == null) {
                Connect();
            }
        }
        public DB4OServer(string dbPath) {
            if (_server == null) {
                Connect(dbPath);
            }
        }
        void Connect() {

            if (_server == null) {
                if (ConfigurationManager.ConnectionStrings["ObjectStore"] == null) {
                    throw new InvalidOperationException("Can't find a connection string for the object store. Please be sure a connection exists called ObjectStore. You can set this to be |DataDirectory|MyStore.db4o");
                }

                string _dbPath = System.Configuration.ConfigurationManager
                    .ConnectionStrings["ObjectStore"].ConnectionString;

                //check to see if this is pointing to data directory
                //change as you need btw
                if (_dbPath.Contains("|DataDirectory|")) {

                    //we know, then, that this is a web project
                    //and HttpContext is hopefully not null...

                    _dbPath = _dbPath.Replace("|DataDirectory|", "");
                    string appDir = HttpContext.Current.Server.MapPath("~/App_Data/");
                    _dbPath = Path.Combine(appDir, _dbPath);
                }
                Connect(_dbPath);
            }
        }
        public void Connect(string dbPath) {
            _server = Db4oFactory.OpenServer(dbPath, 0);
            db =_server.OpenClient();
        }
        private IObjectContainer db;
        public IObjectContainer DB {
            get {
                return db;
            }
        }  
    
    }
}
