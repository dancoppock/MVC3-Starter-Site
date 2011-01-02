using System;
namespace Web.Infrastructure.Storage {
    public interface INoSqlServer {
        void Connect(string dbPath);
        Db4objects.Db4o.IObjectContainer DB { get; }
    }
}
