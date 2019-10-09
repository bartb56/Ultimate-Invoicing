using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UltimateInvocing.Controllers;
using UltimateInvocing.Factories.EmailTemplates;

namespace UltimateInvocing.Web.Mvc.Controllers
{
    public class EmailTemplatesController : UltimateInvocingControllerBase
    {
        private readonly IEmailTemplateFactory _factory;

        public EmailTemplatesController(IEmailTemplateFactory factory)
        {
            _factory = factory;
        }

        [Route("EmailTemplates/")]
        public async Task<IActionResult> Index()
        {
            var model = await _factory.PrepareListModel();
            return View(model);
        }
    }
}