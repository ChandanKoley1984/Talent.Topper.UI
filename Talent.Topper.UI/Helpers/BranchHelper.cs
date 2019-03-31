using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Helpers
{
    public static class BranchHelper
    {
        internal static List<BranchMasterEntity> GetBranchData(string id = "GetAll")
        {
            List<BranchMasterEntity> listOfBranch = new List<BranchMasterEntity>();
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.GetAsync("api/AdminService/GetBranch/" + id + "").Result;
            if (response.IsSuccessStatusCode)
            {
                listOfBranch = JsonConvert.DeserializeObject<List<BranchMasterEntity>>(response.Content.ReadAsStringAsync().Result);
            }
            return listOfBranch;
        }

        internal static bool SaveBranchData(BranchMasterEntity branchEntity, bool saveStatus)
        {
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/AdminService/CreateBranch", branchEntity).Result;
            if (response.IsSuccessStatusCode)
            {
                saveStatus = JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
            }

            return saveStatus;
        }
        internal static bool EditBranchData(BranchMasterEntity branchEntity, bool saveStatus)
        {
            HttpClient client = Utility.NewClient();
            HttpResponseMessage response = client.PostAsJsonAsync("api/AdminService/EditBranch", branchEntity).Result;
            if (response.IsSuccessStatusCode)
            {
                saveStatus = JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
            }

            return saveStatus;
        }
    }
}