using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult GetResultData(string input)
        {
            var model = _ticketMachine.GetAllDataObjectStartedWithInput(input,true);
            return Json(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
