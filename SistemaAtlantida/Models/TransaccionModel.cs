using System.ComponentModel.DataAnnotations;

namespace SistemaAtlantida.Models
{
    public class TransaccionModel
    {
        
        [Key]
        [Required]
        public string NumeroTarjeta { get; set; }
        public string? Tipo { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public string? Descripcion { get; set; }
        [Required]
        public decimal Monto { get; set; }
    }
}
