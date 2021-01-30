using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTestPage.Models;

namespace BlazorTestPage.Api
{
    public class DBStationProcessor
    {

        public async Task<List<DBStationModel>> GetStationDataOrDefault(string namefragment)
        {
            var url =$"https://api.deutschebahn.com/freeplan/v1/location/{namefragment}";
            using (HttpResponseMessage message = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (message.IsSuccessStatusCode == true)
                {
                    List<DBStationModel> dBStationModel = await message.Content.ReadFromJsonAsync<List<DBStationModel>>();
                    return dBStationModel;
                }
                else
                {
                    return default(List<DBStationModel>);
                }
            }

        }
    }
}