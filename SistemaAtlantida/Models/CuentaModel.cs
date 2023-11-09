using System.ComponentModel.DataAnnotations;

namespace SistemaAtlantida.Models
{
    public class CuentaModel
    {
        public string? NombreTitular { get; set; }
        //[Key]
        public string? NumeroTarjeta { get; set; }
        public int PinTarjeta { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal MontoCompras { get; set; }
        public decimal InteresBonificable { get; set; }
        public decimal CuotaMinima { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoPagoIntereses { get; set; }
    }
}
