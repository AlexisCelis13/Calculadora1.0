using System;

namespace GoldenCalculator.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // Ej: area_cuadrado, volumen_cilindro
        public string Parametros { get; set; } // JSON con los parámetros
        public string Resultado { get; set; } // JSON con el resultado
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
} 