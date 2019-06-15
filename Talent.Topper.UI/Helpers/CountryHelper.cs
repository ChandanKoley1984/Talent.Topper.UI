using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Helpers
{
    public class CountryHelper
    {
        internal static List<CountryMasterEntity> GetCountryData(int Countryid = 0)
        {
            List<CountryMasterEntity> listOfCountry = new List<CountryMasterEntity>();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/getCountryList").Result;
            if (response.IsSuccessStatusCode)
            {
                listOfCountry = JsonConvert.DeserializeObject<List<CountryMasterEntity>>(response.Content.ReadAsStringAsync().Result);
            }
            return listOfCountry;
        }
    }
}