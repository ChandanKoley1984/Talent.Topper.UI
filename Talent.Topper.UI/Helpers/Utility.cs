using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Talent.Topper.UI.Helpers
{
    public static class Utility
    {
        public static HttpClient NewClient()
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ServiceBaseAddress"].ToString());
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return _client;
        }           
    }
}