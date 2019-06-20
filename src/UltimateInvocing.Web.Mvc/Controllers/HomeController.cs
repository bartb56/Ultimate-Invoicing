using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using UltimateInvocing.Controllers;

namespace UltimateInvocing.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : UltimateInvocingControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
