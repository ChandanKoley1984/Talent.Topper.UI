using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Helpers
{
    public class StateByCountryHelper
    {
        internal static List<StateByCountryEntity> GetStateByCountryData(string CountryId)
        {
            List<StateByCountryEntity> listOfStateByCountry = new List<StateByCountryEntity>();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/getStateList/" + CountryId + "").Result;
            if (response.IsSuccessStatusCode)
            {
                listOfStateByCountry = JsonConvert.DeserializeObject<List<StateByCountryEntity>>(response.Content.ReadAsStringAsync().Result);
            }
            return listOfStateByCountry;
        }
    }
}
 