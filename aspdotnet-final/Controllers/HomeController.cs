using aspdotnet_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspdotnet_final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchEmployees()
        {
            return View();
        }

        public ActionResult SearchProducts()
        {
            return View();
        }

        public ActionResult SearchTransactions()
        {
            return View();
        }

        public ActionResult BrandMarketShare()
        {
            return View();
        }

        public ActionResult FinancialStatisticsOverview()
        {
            return View();
        }
    }
}