using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaAtlantida.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SistemaAtlantida.Controllers
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
            string numeroTarjeta = "4390930039010978";

            CuentaModel apiResult = await GetUser(numeroTarjeta);
            decimal montoRecienteTotal = await GetComprasMonto(numeroTarjeta);

            ViewBag.MontoRecienteTotal = montoRecienteTotal;
            

            return View(apiResult);
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

        [HttpGet]
        public async Task<CuentaModel> GetUser(string numeroTarjeta) 
        {
            using (HttpClient client = new HttpClient()) 
            {
                CuentaModel usuario = new CuentaModel();
                string urlAPI = $"https://localhost:7238/api/cuentas/{numeroTarjeta}";

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(urlAPI);

                if(response.IsSuccessStatusCode) 
                {
                    string responseJSON = await response.Content.ReadAsStringAsync();

                    usuario = JsonConvert.DeserializeObject<CuentaModel>(responseJSON);
                }

                return usuario;
            }
        }


        [HttpGet]
        public async Task<decimal> GetComprasMonto(string numeroTarjeta) 
        {
            int mesActual = DateTime.Now.Month;
            int mesAnterior = DateTime.Now.AddMonths(-1).Month;

            string urlAPI = $"https://localhost:7238/api/compras/montoreciente/{numeroTarjeta}?mesanterior={mesAnterior}&mes={mesActual}";

            decimal montoRecienteTotal = 0;

            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage response = await client.GetAsync(urlAPI);

                if( response.IsSuccessStatusCode )
                {
                    string responseJSON = await response.Content.ReadAsStringAsync();
                    montoRecienteTotal = JsonConvert.DeserializeObject<decimal>(responseJSON);
                }

                return montoRecienteTotal;
            }
        }
    }
}