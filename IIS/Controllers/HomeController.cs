using IIS.Models;
using IIS.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Serialization;

namespace IIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult XsdValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult XsdValidation(IFormFile fileInput)
        {
            XmlSerializerService.SaveXmlInput(fileInput);
            var response = XsdValidationService.Validate();
            ViewBag.Response = response;
            return View();
        }

        [HttpGet]
        public IActionResult RngValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RngValidation(IFormFile fileInput)
        {
            XmlSerializerService.SaveXmlInput(fileInput);
            var response = RngValidationService.Validate(); //add rng validation here
            ViewBag.Response = response;
            return View();
        }


        [Route("/Home/SoapApi")]
        [Route("/Home/SoapApi/{searchValue}/{searchType}")]
        public IActionResult SoapApi(string? searchValue, string? searchType)
        {
            if (searchType != null && searchValue != null)
            {
                var service = new BillboardService();
                var recent = service.GetTops();
                XmlSerializerService.CreateXmlFile(recent);

                var nodesList = XPathService.Search(searchType, searchValue);
                ViewBag.Nodes = nodesList;
            }
            

            return View();
        }

        public IActionResult DhmzApi()
        {
            ViewBag.Data = DhmzService.GetWeatherData();
            return View();
        }



        [Route("/Home/BillboardApi")]
        [Route("/Home/BillboardApi/{rangeTo}/{datetime}")]
        public IActionResult BillboardApi(int? rangeTo, DateTime? datetime)
        {

            if (rangeTo != null && datetime != null && rangeTo <= 100)
            {
                var service = new BillboardService();
                var rank = service.GetRank(rangeTo, datetime);
                ViewBag.Rank = rank;
            }

            return View();
        }

    }
}