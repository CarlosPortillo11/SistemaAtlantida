using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaAtlantida.Models
{
    public class CuentaModel
    {

        [DisplayName("Número de tarjeta")]
        public string NumeroTarjeta { get; set; }
        [DisplayName("Nombre del titular")]
        public string NombreTitular { get; set; }
        [DisplayName("Saldo Actual")]
        public decimal SaldoActual { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal InteresBonificable { get; set; }
        public decimal CuotaMinima { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoPagoIntereses { get; set; }
    }
}
