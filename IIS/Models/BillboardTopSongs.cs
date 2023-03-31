using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace IIS.Models
{


    public partial class BillboardTopSongs
    {
        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("data")]
        public List<Datum>? Data { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("song")]
        public string? Song { get; set; }

        [JsonProperty("artist")]
        public string? Artist { get; set; }

        [JsonProperty("this_week")]
        public string? ThisWeek { get; set; }

        [JsonProperty("last_week")]
        public string? LastWeek { get; set; }

        [JsonProperty("peak_position")]
        public string? PeakPosition { get; set; }

        [JsonProperty("weeks_on_chart")]
        public string? WeeksOnChart { get; set; }
    }

    public partial class BillboardTopSongs
    {
        public static BillboardTopSongs FromJson(string json) => JsonConvert.DeserializeObject<BillboardTopSongs>(json);
    }

    public static class SerializeTops
    {
        public static string ToJson(this BillboardTopSongs self) => JsonConvert.SerializeObject(self);
    }


}


