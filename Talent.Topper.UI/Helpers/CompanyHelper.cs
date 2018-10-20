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
            List<CompanyEntity> listOfCompany = new List<CompanyEntity>();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/AdminService/GetCompany/" + companyid + "").Result;
            if (response.IsSuccessStatusCode)
            {
                listOfCompany = JsonConvert.DeserializeObject<List<CompanyEntity>>(response.Content.ReadAsStringAsync().Result);                
            }
            return listOfCompany;
        }
        internal static bool SaveCompanyData(CompanyEntity companyEntity, bool saveStatus)
        {
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/AdminService/CreateCompany", companyEntity).Result;
            if (response.IsSuccessStatusCode)
            {
                saveStatus = JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
            }

            return saveStatus;
        }
    }
}