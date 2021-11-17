using Microsoft.AspNetCore.Mvc;
using Power.Models;
using Power.Utils;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using Tibber.Sdk;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Power.Controllers
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

            string fileName = "PowerReading.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            PowerModel model = JsonSerializer.Deserialize<PowerModel>(jsonString);

            var gridCost = model.consumption * 0.385M;
            model.cost += gridCost;
            return View(model);
        }

        public async Task<PowerModel> JSONGetPower()
        {
            string fileName = "PowerReading.json";
            string jsonString = System.IO.File.ReadAllText(fileName);
            PowerModel model = JsonSerializer.Deserialize<PowerModel>(jsonString);
            var gridCost = model.consumption * 0.385M;
            model.cost += gridCost;
            return model;   

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}