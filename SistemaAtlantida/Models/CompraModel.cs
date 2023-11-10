using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaAtlantida.Models
{
    public class CompraModel
    {
        [DisplayName("Numero de la Tarjeta")]
        [Key]
        public string? NumeroTarjeta { get; set; }

        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
