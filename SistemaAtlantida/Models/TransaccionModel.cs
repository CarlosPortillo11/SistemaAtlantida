﻿using System.ComponentModel.DataAnnotations;

namespace SistemaAtlantida.Models
{
    public class TransaccionModel
    {
        
        [Key]
        [Required]
        public string NumeroTarjeta { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Introduzca una descripción de la transacción.")]
        public string Descripcion { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Realice una transacción válida.")]
        [Required(ErrorMessage = "Introduzca un monto para la transacción.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Introduzca datos válidos.")]
        public decimal Monto { get; set; }
    }
}
