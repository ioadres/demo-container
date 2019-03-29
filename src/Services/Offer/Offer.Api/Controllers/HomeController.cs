using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Services.Offer.API.Controllers
{

    public class HomeController : Controller
    {
        public HomeController(IOptionsSnapshot<OfferSetting> options)
        {
            this.OfferSetting = options.Value;
        }

        private readonly OfferSetting OfferSetting;

        public string GetConnection()
        {
            return OfferSetting.ConnectionString;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
