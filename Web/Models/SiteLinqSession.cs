using Web.Infrastructure.Storage;

namespace Web.Models {

    /// <summary>
    /// This is a data access alternative
    /// </summary>
    public class SiteLinqSession:LinqToSqlSession {
        public SiteLinqSession():base(new DB()) {}
    }
}