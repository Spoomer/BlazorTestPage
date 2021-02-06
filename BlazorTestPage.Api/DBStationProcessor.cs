using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorTestPage.Models;
using System.Text.Json;

namespace BlazorTestPage.Api
{
    public class DBStationProcessor
    {
        public Dictionary<int,DBStationModel> StationDic { get; set; } = new Dictionary<int, DBStationModel>();
        public List<DBStationModel> StationList { get; set; } =new List<DBStationModel>();
        
        public DBStationProcessor()
        {
            if (File.Exists("stations.json"))
            {
                var stationFile = File.ReadAllLines("stations.json");
                foreach (var json in stationFile)
                {
                    var station = JsonSerializer.Deserialize<DBStationModel>(json);
                    StationDic.Add(station.Id,station);
                    StationList.Add(station);
                }
            }
        }
        public async Task<List<DBStationModel>> GetStationData(string namefragment)
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
                    return new List<DBStationModel>();
                }
            }

        }

        public async Task<List<DepartureBoardModel>> GetDepatureBoard(int stationId)
        {
            var url =$"https://api.deutschebahn.com/freeplan/v1/departureBoard/{stationId}";
            using (HttpResponseMessage message = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (message.IsSuccessStatusCode == true)
                {
                    List<DepartureBoardModel> departureBoardList = await message.Content.ReadFromJsonAsync<List<DepartureBoardModel>>();
                    return departureBoardList;
                }
                else
                {
                    return new List<DepartureBoardModel>();
                }
            }
        }

        public void UpdateOrAddStation(DBStationModel dBStationModel)
        {
            if (StationDic is not null && StationDic.ContainsKey(dBStationModel.Id))
            {
                StationDic[dBStationModel.Id] = dBStationModel;
            }
            else
            {
                StationDic.Add(dBStationModel.Id,dBStationModel);
            }
        }

        public void SaveDataToJson()
        {
            StringBuilder jsonString = new();
            StationList.Clear();
            foreach (var station in StationDic)
            {
                jsonString.AppendLine(station.Value.ToString());
                StationList.Add(station.Value);
            }
            File.WriteAllText("stations.json",jsonString.ToString());
        }

    }
}