using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace prj666vc.App_Code
{
    public static class HtmlExtentions
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string activeClass, bool checkAction)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (string.Compare(controllerName, currentController, StringComparison.OrdinalIgnoreCase) == 0 && ((!checkAction) || string.Compare(actionName, currentAction, StringComparison.OrdinalIgnoreCase) == 0) || string.Compare(controllerName, currentController, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new { @class = "activeClass" });
            }

            return htmlHelper.ActionLink(linkText, actionName, controllerName);

        }

        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string activeClass)
        {
            return MenuLink(htmlHelper, linkText, actionName, controllerName, activeClass, true);
        }

        public static MvcHtmlString subMenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string activeClass, bool checkAction)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (string.Compare(controllerName, currentController, StringComparison.OrdinalIgnoreCase) == 0 && (  string.Compare(actionName, currentAction, StringComparison.OrdinalIgnoreCase) == 0) )
            {
                return htmlHelper.ActionLink(linkText, actionName, controllerName, null, new { @class = "activeClass2" });
            }

            return htmlHelper.ActionLink(linkText, actionName, controllerName);

        }

    }
}