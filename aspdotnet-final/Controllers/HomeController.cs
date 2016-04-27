using aspdotnet_final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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

        public PartialViewResult SearchTransactionsPartial(string keyword)
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                List<string> keywords = new List<string>();
                foreach (string word in keyword.Split(' '))
                    keywords.Add(word);
                var items = (from transaction in context.tTransactions
                             join detail in context.tTransactionDetails on transaction.TransactionID equals detail.TransactionID
                             join loyalty in context.tLoyalties on transaction.LoyaltyID equals loyalty.LoyaltyID
                             join product in context.tProducts on detail.ProductID equals product.ProductID
                             join productname in context.tNames on product.NameID equals productname.NameID
                             select new
                             {
                                 DateOfTransaction = transaction.DateOfTransaction,
                                 LoyaltyNumber = loyalty.LoyaltyNumber,
                                 ProductName = productname.Name
                             })
                            .Where(
                                _ => keywords.Contains(_.LoyaltyNumber)
                                || keywords.Contains(_.ProductName)
                                || keywords.Contains(((DateTime)_.DateOfTransaction).Day
                                + "/" + ((DateTime)_.DateOfTransaction).Month
                                + "/" + ((DateTime)_.DateOfTransaction).Year)
                                || keywords.Contains(((DateTime)_.DateOfTransaction).Day
                                + "-" + ((DateTime)_.DateOfTransaction).Month
                                + "-" + ((DateTime)_.DateOfTransaction).Year)
                            ).Take(50);
                List<string[]> result = new List<string[]>();

                foreach (var item in items)
                {
                    result.Add(new string[] {
                        ((DateTime)item.DateOfTransaction).ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'"),
                        item.LoyaltyNumber,
                        item.ProductName
                    });
                }

                return PartialView(result);
            }
        }
    }
}