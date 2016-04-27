using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace aspdotnet_final
{
    /// <summary>
    /// Summary description for DashboardService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DashboardService : System.Web.Services.WebService
    {
        [WebMethod]
        public decimal GetTotalRevenueThisWeek()
        {
            return MvcApplication.GetTotalRevenueThisWeek();
        }

        [WebMethod]
        public int GetTotalTransactionsThisWeek()
        {
            return MvcApplication.GetTotalTransactionsThisWeek();
        }

        [WebMethod]
        public int GetTotalTransactionDetailsThisWeek()
        {
            return MvcApplication.GetTotalTransactionDetailsThisWeek();
        }

        [WebMethod]
        public decimal GetTotalRevenueLastWeek()
        {
            return MvcApplication.GetTotalRevenueLastWeek();
        }

        [WebMethod]
        public int GetTotalTransactionsLastWeek()
        {
            return MvcApplication.GetTotalTransactionsLastWeek();
        }

        [WebMethod]
        public int GetTotalTransactionDetailsLastWeek()
        {
            return MvcApplication.GetTotalTransactionDetailsLastWeek();
        }

        // name / sumofqtysold / percentage of top
        [WebMethod]
        public List<string[]> GetTop10Products()
        {
            return MvcApplication.GetTop10Products();
        }

        // brand name / quantity sold / percentage of market
        [WebMethod]
        public List<string[]> GetBrandsMarketShare()
        {
            return MvcApplication.GetBrandsMarketShare();
        }
    }
}
