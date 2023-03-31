using Newtonsoft.Json;

namespace IIS.Models
{
    public partial class BillboardRank
    {
        [JsonProperty("info")]
        public Info? Info { get; set; }

        [JsonProperty("content")]
        public Dictionary<int, Content>? Content { get; set; }

    }

    public partial class Content
    {
        [JsonProperty("rank")]
        public string? Rank { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("artist")]
        public string? Artist { get; set; }

        [JsonProperty("weeks at no.1", NullValueHandling = NullValueHandling.Ignore)]
        public string? WeeksAtNo1 { get; set; }

        [JsonProperty("last week")]
        public string? LastWeek { get; set; }

        [JsonProperty("peak position")]
        public string? PeakPosition { get; set; }

        [JsonProperty("weeks on chart")]
        public string? WeeksOnChart { get; set; }

        [JsonProperty("detail")]
        public string? Detail { get; set; }
    }

    public partial class Info
    {
        [JsonProperty("category")]
        public string? Category { get; set; }

        [JsonProperty("chart")]
        public string? Chart { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("source")]
        public string? Source { get; set; }
    }


    public partial class BillboardRank
    {
        public static BillboardRank FromJson(string json) => JsonConvert.DeserializeObject<BillboardRank>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this BillboardRank self) => JsonConvert.SerializeObject(self);
    }

}


