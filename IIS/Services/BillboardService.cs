using IIS.Controllers;
using IIS.Models;
using Newtonsoft.Json;
using System.IO.Pipelines;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System;
using NuGet.ContentModel;

namespace IIS.Services
{


    public class BillboardService
    {

        private static HttpMethod method = HttpMethod.Get;
        private static string httpUriTemplate = "https://billboard-api2.p.rapidapi.com/hot-100?date={0}&range={1}-{2}";
        private static HttpClient httpClient;
        private static HttpRequestMessage httpRequest;
        private static string uri;
        private static string apiKeyName = "X-RapidAPI-Key";
        private static string apiKeyValue = "58119398d3mshc837bde735c686ap18d3ddjsn86e45f95afa9";
        private static string apiHostName = "X-RapidAPI-Host";
        private static string apiHostValue = "billboard-api2.p.rapidapi.com";
        private BillboardRank latestRank;

        public BillboardService()
        {

        }

        public BillboardRank GetRank(int? rangeTo, DateTime? date)
        {

            Execute(rangeTo, date).Wait();


            return latestRank;
        }

        public BillboardTopSongs GetTops()
        {
            var json = File.ReadAllText(@"..\IIS\Assets\billboardrecents.json");
            return BillboardTopSongs.FromJson(json);
        }



        private async Task<BillboardRank> Execute(int? rangeTo, DateTime? date)
        {
            httpClient = new HttpClient();
            if (rangeTo != null && date != null)
            {
                uri = string.Format(httpUriTemplate, date?.ToString("yyyy-MM-dd"), 1, rangeTo);
            }
            else
            {
                uri = string.Format(httpUriTemplate, DateTime.Now.ToString("yyyy-MM-dd"), 1, rangeTo);
            }

            httpRequest = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(uri),
                Headers =
                    {
                         { apiKeyName, apiKeyValue  },
                         { apiHostName, apiHostValue },
                    },
            };

            BillboardRank rank;
            using (var httpResponse = await httpClient.SendAsync(httpRequest))
            {
                httpResponse.EnsureSuccessStatusCode();
                rank = await httpResponse.Content.ReadFromJsonAsync<BillboardRank>();
            }

            latestRank = rank;
            return rank;
        }
    }
}
