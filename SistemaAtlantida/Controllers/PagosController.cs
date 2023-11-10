using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAtlantida.Models;

namespace SistemaAtlantida.Controllers
{
    public class PagosController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PagoModel pagoModel) 
        {
            string urlAPI = $"https://localhost:7238/api/pagos";
            string numeroTarjeta = HttpContext.Session.GetString("numeroTarjeta");
            pagoModel.NumeroTarjeta = numeroTarjeta;

            using (HttpClient client = new HttpClient())
            {
                var response = client.PostAsJsonAsync<PagoModel>(urlAPI, pagoModel);
                response.Wait();

                ViewBag.Code = response.Result.StatusCode;

                if (response.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult ToHome() 
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
