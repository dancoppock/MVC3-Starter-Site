using System.Text;

namespace System.Web.Mvc {
    public static class HtmlHelpers {
        const string pubDir="/public";
        const string cssDir="css";
        const string imageDir="images";
        const string scriptDir="javascript";

        public static IHtmlString DatePickerEnable(this HtmlHelper helper) {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("<script type='text/javascript'>$(document).ready(function() {$('.date-selector').datepicker();});</script>\n");
            return MvcHtmlString.Create(sb.ToString());
        }

        public static IHtmlString Friendly(this HtmlHelper helper)
        {
            if ( (helper.ViewContext.HttpContext.Request != null) && (helper.ViewContext.HttpContext.Request.Cookies["friendly"] != null) )
            {
                var friendlyString = helper.h(helper.ViewContext.HttpContext.Request.Cookies["friendly"].Value);
                return MvcHtmlString.Create(friendlyString);
            }
            return MvcHtmlString.Create("");
        }

        public static IHtmlString Script(this HtmlHelper helper, string fileName) {
            if (!fileName.EndsWith(".js"))
                fileName += ".js";
            var jsPath = string.Format("<script src='{0}/{1}/{2}' ></script>\n", pubDir, scriptDir, helper.AttributeEncode(fileName));
            return MvcHtmlString.Create(jsPath);
        }

        public static IHtmlString CSS(this HtmlHelper helper, string fileName) {
            return CSS(helper, fileName, "screen");
        }

        public static IHtmlString CSS(this HtmlHelper helper, string fileName, string media) {
            if (!fileName.EndsWith(".css"))
                fileName += ".css";
            var jsPath = string.Format("<link rel='stylesheet' type='text/css' href='{0}/{1}/{2}'  media='" + media + "'/>\n", pubDir, cssDir, helper.AttributeEncode(fileName));
            return MvcHtmlString.Create(jsPath);
        }

        public static IHtmlString Image(this HtmlHelper helper, string fileName) {
            return Image(helper, fileName, "");
        }

        public static IHtmlString Image(this HtmlHelper helper, string fileName, string attributes) {
            fileName = string.Format("{0}/{1}/{2}", pubDir, imageDir, fileName);
            var imageTag = string.Format("<img src='{0}' '{1}' />", helper.AttributeEncode(fileName), helper.AttributeEncode(attributes));
            return MvcHtmlString.Create(imageTag);
        }
    }
}
