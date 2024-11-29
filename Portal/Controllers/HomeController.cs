using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GRPC.Patient;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5035");
            var client = new PatientService.PatientServiceClient(channel);
            var response = await client.ListPatientsAsync(new GRPC.Patient.Empty());

            List<PatientViewModel> result = new List<PatientViewModel>();

            foreach (var p in response.Patients) 
            {
                result.Add(p.ToDto());
            }

            await channel.ShutdownAsync();

            return View(result);
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
