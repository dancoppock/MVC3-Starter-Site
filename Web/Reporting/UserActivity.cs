using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Infrastructure.Storage;

namespace Web.Reporting {
    public partial class UserActivity {

        ISession _session;
        public UserActivity(ISession session) {
            _session = session;
        }
        public void LogIt(string userName, string activity) {
            var log = new UserActivity();
            log.Activity = activity;
            log.CreatedOn = DateTime.Now;
            log.UserName = userName;
            _session.Add(log);
            _session.CommitChanges();
        }
    }
}
