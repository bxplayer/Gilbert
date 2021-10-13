using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gilbert.Controllers
{
    public class CompanyCustomController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserCR"] == null || (Boolean)Session["UserCR"] == false || (long)Session["IDCompany"] < 1 || (long)Session["IDUser"] < 1)
            {
                filterContext.Result = RedirectToAction("Index", "Home");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}