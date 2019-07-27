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
        internal static List<CompanyList> GetCompanyListData(int? ID = null)
        {
            List<CompanyList> listOfCompany = new List<CompanyList>();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/Company/GetCompanies/"+ ID).Result;
            if (response.IsSuccessStatusCode)
            {
                listOfCompany = JsonConvert.DeserializeObject<List<CompanyList>>(response.Content.ReadAsStringAsync().Result);                
            }
            return listOfCompany;
        }
        internal static List<CompanyEntity> GetCompanyEditData(int? ID = null)
        {
            List<CompanyEntity> listOfCompany = new List<CompanyEntity>();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/Company/GetCompaniesEdit/" + ID).Result;
            if (response.IsSuccessStatusCode)
            {
                listOfCompany = JsonConvert.DeserializeObject<List<CompanyEntity>>(response.Content.ReadAsStringAsync().Result);
            }
            return listOfCompany;
        }
        internal static CompanyEntity SaveCompanyData(CompanyEntity companyEntity, out bool saveStatus)
        {
            CompanyEntity _companyEntity = new CompanyEntity();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/Company/CreateCompany", companyEntity).Result;
            if (response.IsSuccessStatusCode)
            {
                _companyEntity = JsonConvert.DeserializeObject<CompanyEntity>(response.Content.ReadAsStringAsync().Result);
                saveStatus = true;
            }
            else
            {
                saveStatus = false;
            }

            return _companyEntity;
        }

        //search by name / email / website
        internal static List<CompanyEntity> SearchCompanyList(string name)
        {
            List<CompanyEntity> listOfCompany = new List<CompanyEntity>();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/AdminService/SearchCompanyList/" + name + "").Result;
            if (response.IsSuccessStatusCode)
            {
                listOfCompany = JsonConvert.DeserializeObject<List<CompanyEntity>>(response.Content.ReadAsStringAsync().Result);
            }
            return listOfCompany;
        }
    }
}