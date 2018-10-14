using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Helpers
{
    public static class CompanyHelper
    {
        internal static List<CompanyEntity> GetCompanyData(int companyid = 0)
        {
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/AdminService/GetCompany/" + companyid + "").Result;
            if (response.IsSuccessStatusCode)
            {
               // var cust = JsonConvert.DeserializeObject<CompanyEntity>(response.Content.);
            }
            return new List<CompanyEntity>();
        }
    }
}