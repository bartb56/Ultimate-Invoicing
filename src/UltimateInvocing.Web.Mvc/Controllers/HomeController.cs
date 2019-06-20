using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using UltimateInvocing.Controllers;
using UltimateInvocing.Factories.Home;
using System.Threading.Tasks;

namespace UltimateInvocing.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : UltimateInvocingControllerBase
    {
        private readonly IHomeFactory _homeFactory;

        public HomeController(IHomeFactory homeFactory)
        {
            _homeFactory = homeFactory;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _homeFactory.PrepareModel();
            return View(model);
        }
	}
}
