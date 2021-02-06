using System.Text.Json.Serialization;
using System.Text.Json;
namespace BlazorTestPage.Models
{
    public class DBStationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<DBStationModel>(this);
        }
    }
}