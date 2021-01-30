using System.Net.Http;
using System.Net.Http.Headers;

namespace BlazorTestPage.Api
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void ConfigureApiClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        
    }
}