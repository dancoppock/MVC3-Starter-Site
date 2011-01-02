namespace System.Web.Mvc {
    public static class UrlHelpers {

        public static string SiteRoot(HttpContextBase context) {
            return SiteRoot(context, true);
        }

        public static string SiteRoot(HttpContextBase context, bool usePort) {
            var Port = context.Request.ServerVariables["SERVER_PORT"];
            if (usePort) {
                if (Port == null || Port == "80" || Port == "443")
                    Port = "";
                else
                    Port = ":" + Port;
            }
            var Protocol = context.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (Protocol == null || Protocol == "0")
                Protocol = "http://";
            else
                Protocol = "https://";

            var appPath = context.Request.ApplicationPath;
            if (appPath == "/")
                appPath = "";

            var sOut = Protocol + context.Request.ServerVariables["SERVER_NAME"] + Port + appPath;
            return sOut;

        }

        public static string SiteRoot(this UrlHelper url) {
            return SiteRoot(url.RequestContext.HttpContext);
        }


        public static string SiteRoot(this ViewPage pg) {
            return SiteRoot(pg.ViewContext.HttpContext);
        }

        public static string SiteRoot(this ViewUserControl pg) {
            var vpage = pg.Page as ViewPage;
            return SiteRoot(vpage.ViewContext.HttpContext);
        }

        public static string SiteRoot(this ViewMasterPage pg) {
            return SiteRoot(pg.ViewContext.HttpContext);
        }

        public static string GetReturnUrl(HttpContextBase context) {
            var returnUrl = "";

            if (context.Request.QueryString["ReturnUrl"] != null) {
                returnUrl = context.Request.QueryString["ReturnUrl"];
            }

            return returnUrl;
        }

        public static string GetReturnUrl(this UrlHelper helper) {
            return GetReturnUrl(helper.RequestContext.HttpContext);
        }

        public static string GetReturnUrl(this ViewPage pg) {
            return GetReturnUrl(pg.ViewContext.HttpContext);
        }

        public static string GetReturnUrl(this ViewMasterPage pg) {
            return GetReturnUrl(pg.Page as ViewPage);
        }

        public static string GetReturnUrl(this ViewUserControl pg) {
            return GetReturnUrl(pg.Page as ViewPage);
        }

    }
}
