using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infrastructure.Storage;

namespace Web.Infrastructure.Reporting {
    public class ReportingSession:LinqToSqlSession, IReporting {

        public ReportingSession() : base(new DB()) { }

    }
}
