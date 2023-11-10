using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaAtlantida.Models
{
    public class PagoModel
    {
        [DisplayName("Numero de la Tarjeta")]
        [Key]
        public string? NumeroTarjeta { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
    }
}
