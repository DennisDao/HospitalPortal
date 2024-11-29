using Grpc.Net.Client;
using GRPC.Patient;
using Microsoft.AspNetCore.Mvc;
using Portal.Connectors;
using Portal.Models;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PatientConnector _connector;

        public HomeController(ILogger<HomeController> logger, PatientConnector connector)
        {
            _logger = logger;
            _connector = connector;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _connector.ListPatientsAsync();
            return View(data);
        }

        public IActionResult New()
        {
            var patient = new PatientViewModel();
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientViewModel patient)
        {
            var response = await _connector.AddPatient(patient);
            return Redirect("/home/index");
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
