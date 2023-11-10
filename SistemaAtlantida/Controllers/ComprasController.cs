using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaAtlantida.Models;
using System.Globalization;

namespace SistemaAtlantida.Controllers
{
    public class ComprasController : Controller
    {
        // GET: ComprasController
        public async Task<IActionResult> Index()
        {
            string numeroTarjeta ="4390930039010978";

            List<CompraModel> comprasResult = await GetCompras(numeroTarjeta);
            //List<CompraModel> comprasFiltradas = await FiltrarCompras(numeroTarjeta);

            return View(comprasResult);
        }

        public async Task<List<CompraModel>> FiltrarCompras(string numeroTarjeta)
        {
            List<CompraModel> comprasResult = await GetCompras(numeroTarjeta);

            List<CompraModel> comprasFiltrada = new List<CompraModel>();
            int mesActual = DateTime.Now.Month;
            string formatoFecha = "yyyy/MM/dd";

            try 
            {
                comprasFiltrada = comprasResult.Where(compra => compra.Fecha.Month == mesActual).ToList();
            }catch (Exception ex)
            {
                throw;
            }

            return comprasFiltrada;
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
