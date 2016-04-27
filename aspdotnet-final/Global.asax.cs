using aspdotnet_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace aspdotnet_final
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static List<tBrand> GetBrands()
        {
            List<tBrand> brands = new List<tBrand>();

            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {

                var query = from brand in context.tBrands
                            //where
                            //brand.BrandID == 1
                            select brand;

                // Iterate through the collection of Contact items.
                foreach (tBrand result in query)
                {
                    brands.Add(result);
                }
            }

            return brands;
        }

        public static decimal GetTotalRevenueThisWeek()
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                DateTime today = DateTime.Today;
                DateTime startOfLastWeek = today.AddDays(-(int)today.DayOfWeek); // Sun
                DateTime endOfLastWeek = today.AddDays(-(int)today.DayOfWeek + 6); // Sat

                return (decimal)(from transaction in context.tTransactions
                                 join detail in context.tTransactionDetails on transaction.TransactionID equals detail.TransactionID
                                 where
                                 transaction.DateOfTransaction >= startOfLastWeek && transaction.DateOfTransaction <= endOfLastWeek
                                 select detail.TotalPrice).Sum();
            }
        }

        public static int GetTotalTransactionsThisWeek()
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                DateTime today = DateTime.Today;
                DateTime startOfLastWeek = today.AddDays(-(int)today.DayOfWeek); // Sun
                DateTime endOfLastWeek = today.AddDays(-(int)today.DayOfWeek + 6); // Sat

                return (from transaction in context.tTransactions
                        where
                        transaction.DateOfTransaction >= startOfLastWeek && transaction.DateOfTransaction <= endOfLastWeek
                        select transaction).Count();
            }
        }

        public static int GetTotalTransactionDetailsThisWeek()
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                DateTime today = DateTime.Today;
                DateTime startOfLastWeek = today.AddDays(-(int)today.DayOfWeek); // Sun
                DateTime endOfLastWeek = today.AddDays(-(int)today.DayOfWeek + 6); // Sat

                return (from transaction in context.tTransactions
                        join detail in context.tTransactionDetails on transaction.TransactionID equals detail.TransactionID
                        where
                        transaction.DateOfTransaction >= startOfLastWeek && transaction.DateOfTransaction <= endOfLastWeek
                        select detail).Count();
            }
        }

        public static decimal GetTotalRevenueLastWeek()
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                DateTime today = DateTime.Today;
                DateTime startOfLastWeek = today.AddDays(-(int)today.DayOfWeek - 7); // Sun
                DateTime endOfLastWeek = today.AddDays(-(int)today.DayOfWeek - 1); // Sat

                return (decimal)(from transaction in context.tTransactions
                                 join detail in context.tTransactionDetails on transaction.TransactionID equals detail.TransactionID
                                 where
                                 transaction.DateOfTransaction >= startOfLastWeek && transaction.DateOfTransaction <= endOfLastWeek
                                 select detail.TotalPrice).Sum();
            }
        }

        public static int GetTotalTransactionsLastWeek()
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                DateTime today = DateTime.Today;
                DateTime startOfLastWeek = today.AddDays(-(int)today.DayOfWeek - 7); // Sun
                DateTime endOfLastWeek = today.AddDays(-(int)today.DayOfWeek - 1); // Sat

                return (from transaction in context.tTransactions
                        where
                        transaction.DateOfTransaction >= startOfLastWeek && transaction.DateOfTransaction <= endOfLastWeek
                        select transaction).Count();
            }
        }

        public static int GetTotalTransactionDetailsLastWeek()
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                DateTime today = DateTime.Today;
                DateTime startOfLastWeek = today.AddDays(-(int)today.DayOfWeek - 7); // Sun
                DateTime endOfLastWeek = today.AddDays(-(int)today.DayOfWeek - 1); // Sat

                return (from transaction in context.tTransactions
                        join detail in context.tTransactionDetails on transaction.TransactionID equals detail.TransactionID
                        where
                        transaction.DateOfTransaction >= startOfLastWeek && transaction.DateOfTransaction <= endOfLastWeek
                        select detail).Count();
            }
        }

        public static List<string[]> GetTop10Products()
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                var products = (from product in context.vTop10ProductsByQtyOfProduct
                                select product);
                List<string[]> result = new List<string[]>();
                // Calculate total qty sold of top 10 products
                decimal totalQtySold = 0; // decimal to keep floating point for percentage calculations
                foreach (var product in products)
                    totalQtySold += (int)product.SumOfQtyOfProduct;

                foreach (var product in products)
                {
                    result.Add(new string[] {
                        product.Name,
                        product.SumOfQtyOfProduct.ToString(),
                        ((int)((product.SumOfQtyOfProduct / totalQtySold) * 100)).ToString()
                    });
                }

                return result;
            }
        }

        public class BrandMarketShare
        {
            public string BrandName { get; set; }
            public int QuantitySold { get; set; }
            public int PercentOfShare { get; set; }
        }

        public static List<string[]> GetBrandsMarketShare()
        {
            using (SimGroceryEntities context =
                new SimGroceryEntities())
            {
                BrandMarketShare[] brands = (from detail in context.tTransactionDetails
                             join product in context.tProducts on detail.ProductID equals product.ProductID
                             join brand in context.tBrands on product.BrandID equals brand.BrandID
                             group new { brand, detail } by brand into g
                             select new BrandMarketShare
                             {
                                 BrandName = g.FirstOrDefault().brand.Brand,
                                 QuantitySold = (int)g.Sum(_ => _.detail.QtyOfProduct)
                             }).OrderByDescending(_ => _.QuantitySold).ToArray();
                List<string[]> result = new List<string[]>();
                // Calculate total qty sold of top 10 products
                decimal totalQtySold = 0; // decimal to keep floating point for percentage calculations
                foreach (BrandMarketShare brand in brands)
                    totalQtySold += (int)brand.QuantitySold;

                foreach (BrandMarketShare brand in brands)
                {
                    result.Add(new string[] {
                        brand.BrandName,
                        brand.QuantitySold.ToString(),
                        ((int)((brand.QuantitySold / totalQtySold) * 100)).ToString()
                    });
                }

                return result;
            }
        }

        public static string SearchTransactions(string keyword)
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
                             group new { transaction, detail, loyalty, productname } by transaction into g
                             select new
                             {
                                 transaction = g.FirstOrDefault().transaction,
                                 loyalty = g.FirstOrDefault().loyalty,
                                 productname = g.FirstOrDefault().productname,
                                 Amount = g.Sum(_ => _.detail.TotalPrice)
                             })
                            .Where(
                                _ => keywords.Contains(_.loyalty.LoyaltyNumber)
                                || keywords.Contains(_.productname.Name)
                                || keywords.Contains(((DateTime)_.transaction.DateOfTransaction).Day
                                + "/" + ((DateTime)_.transaction.DateOfTransaction).Month
                                + "/" + ((DateTime)_.transaction.DateOfTransaction).Year)
                                || keywords.Contains(((DateTime)_.transaction.DateOfTransaction).Day
                                + "-" + ((DateTime)_.transaction.DateOfTransaction).Month
                                + "-" + ((DateTime)_.transaction.DateOfTransaction).Year)
                            ).Take(50);
                string result = "";

                bool pointer = true;
                foreach (var item in items)
                {
                    result += "<tr class=\"" + (pointer ? "even" : "odd") + " pointer\">"
                    + "<td class=\" \">" + ((DateTime)item.transaction.DateOfTransaction).ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'") + "</td>"
                    + "<td class=\" \">" + item.transaction.Comment + "</td>"
                    + "<td class=\" \">" + item.loyalty.LoyaltyNumber + "</td>"
                    + "<td class=\" \">Paid</td>"
                    + "<td class=\"a-right a-right \">$ " + item.Amount + "</td>"
                    + "<td class=\" last\">"
                        + "<a href=\"#\">View</a>"
                    + "</td>"
                    + "</tr>";

                    pointer = !pointer;
                }

                return result;
            }
        }
    }
}
