using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaAtlantida.Models;
using SistemaAtlantida.Tools;
using System.Globalization;

namespace SistemaAtlantida.Controllers
{
    public class ComprasController : Controller
    {
        // GET: ComprasController
        public async Task<IActionResult> Index(int? pageNumber)
        {
            //string numeroTarjeta ="4390930039010978";
            string numPrueba = HttpContext.Session.GetString("numeroTarjeta");

            List<CompraModel> comprasResult = await GetCompras(numPrueba);
            int pageSize = 4;

            return View(await PaginatedList<CompraModel>.CreateAsync(comprasResult, pageNumber ?? 1, pageSize));
            //return View(comprasResult);
        }

        public ActionResult Create()
        {
            string numPrueba = HttpContext.Session.GetString("numeroTarjeta");
            ViewBag.numPrueba = numPrueba;

            return View();
        }

        [HttpPost]
        public ActionResult Create(CompraModel compraModel)
        {
            string urlAPI = $"https://localhost:7238/api/compras";
            string numeroTarjeta = HttpContext.Session.GetString("numeroTarjeta");
            compraModel.NumeroTarjeta = numeroTarjeta;

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsJsonAsync<CompraModel>(urlAPI, compraModel);
                response.Wait();

                if(response.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Compras");
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<List<CompraModel>> GetCompras(string numeroTarjeta) 
        {
            List<CompraModel> comprasResponse = new List<CompraModel>();
            int mesActual = DateTime.Now.Month;

            using(HttpClient client = new HttpClient()) 
            {
                string urlAPI = $"https://localhost:7238/api/compras/tarjeta/{numeroTarjeta}?mes={mesActual}";

                HttpResponseMessage response = await client.GetAsync(urlAPI);

                if(response.IsSuccessStatusCode)
                {
                    string responseJSON = await response.Content.ReadAsStringAsync();

                    comprasResponse = JsonConvert.DeserializeObject<List<CompraModel>>(responseJSON);
                }
            }

            return comprasResponse;
        }
    }
}
