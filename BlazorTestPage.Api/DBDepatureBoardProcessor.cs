using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTestPage.Models;

namespace BlazorTestPage.Api
{
    public class DBDepatureBoardProcessor
    {
        public async Task<List<DepartureBoardModel>> GetDepatureBoardModels(int id)
        {
            var url =$"https://api.deutschebahn.com/freeplan/v1/departureBoard/{id}?date={DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm")}";
            using (HttpResponseMessage message = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (message.IsSuccessStatusCode == true)
                {
                    List<DepartureBoardModel> dBStationModel = await message.Content.ReadFromJsonAsync<List<DepartureBoardModel>>();
                    return dBStationModel;
                }
                else
                {
                    return new List<DepartureBoardModel>();
                }
            }
        }
    }
}