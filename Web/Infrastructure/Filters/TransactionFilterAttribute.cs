using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Infrastructure.Filters {
    public class TransactionFilterAttribute:ActionFilterAttribute {

        //Ninject will instantiate the session so there's no code to write here for that
        //also - Ninject will dispose, which is lovely.
        //The session is a property on Application - use that in your calling code.
        //If you move the Session stuff to a different project, expose the session
        //via Factory or some other method

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            //commit the ISession unit of work
            Web.MvcApplication.Session.CommitChanges();

        }

    }
}