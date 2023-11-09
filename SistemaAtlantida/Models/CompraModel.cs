using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SistemaAtlantida.Models
{
    public class CompraModel
    {
        [Key]
        public string? NumeroTarjeta { get; set; }

        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
