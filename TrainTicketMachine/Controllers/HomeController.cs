using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainTicketMachine.Models;
using TrainTicketMachineBusiness;

namespace TrainTicketMachine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketMachine _ticketMachine;
        public HomeController(ITicketMachine ticketMachine)
        {
            _ticketMachine = ticketMachine;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetResultData(string input)
        {
            string filepath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Data", "world-cities_csv.csv");
            var dataList = _ticketMachine.GetAllDataObjectStartedWithInput(input, filepath);
            return Json(dataList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
