using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Helpers
{
    public static class IDGenerationHelper
    {
        internal static List<IDGeneration> GetGeneratedIDs(int id = 0)
        {
            List<IDGeneration> listOfIDs = new List<IDGeneration>();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/AdminService/GetGeneratedIDs/" + id + "").Result;
            if (response.IsSuccessStatusCode)
            {
                listOfIDs = JsonConvert.DeserializeObject<List<IDGeneration>>(response.Content.ReadAsStringAsync().Result);
            }
            return listOfIDs;
        }

        internal static bool SaveGeneratedID(IDGeneration iDGenerationEntity, bool saveStatus)
        {
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/AdminService/CreateIDs", iDGenerationEntity).Result;
            if (response.IsSuccessStatusCode)
            {
                saveStatus = JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
            }

            return saveStatus;
        }
    }
}