using System;
using System.Text.Json.Serialization;
namespace BlazorTestPage.Models
{
    public class DepartureBoardModel
    {
        public string Name { get; set; }

        public string Type { get; set; }
        public int BoardId { get; set; }
        public int stopId { get; set; }
        [JsonPropertyName("datetime")]
        public DateTime DepartureTime { get; set; }
        public string Track { get; set; }
        public string DetailsId { get; set; }
    }
}