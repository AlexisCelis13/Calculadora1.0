using Microsoft.AspNetCore.Mvc;
using GoldenCalculator.Models;
using System.Text.Json;

namespace GoldenCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VolumenController : ControllerBase
    {
        private readonly OperacionesDbContext _db;
        public VolumenController(OperacionesDbContext db)
        {
            _db = db;
        }

        [HttpGet("cubo")]
        public IActionResult CalcularVolumenCubo(double lado)
        {
            if (lado <= 0)
                return BadRequest("El lado debe ser mayor que 0");

            double volumen = lado * lado * lado;
            var operacion = new Operacion
            {
                Tipo = "volumen_cubo",
                Parametros = JsonSerializer.Serialize(new { lado }),
                Resultado = JsonSerializer.Serialize(new { volumen })
            };
            _db.Operaciones.Add(operacion);
            _db.SaveChanges();
            return Ok(new { volumen = volumen });
        }

        [HttpGet("prisma-rectangular")]
        public IActionResult CalcularVolumenPrismaRectangular(double largo, double ancho, double alto)
        {
            if (largo <= 0 || ancho <= 0 || alto <= 0)
                return BadRequest("Las dimensiones deben ser mayores que 0");

            double volumen = largo * ancho * alto;
            var operacion = new Operacion
            {
                Tipo = "volumen_prisma_rectangular",
                Parametros = JsonSerializer.Serialize(new { largo, ancho, alto }),
                Resultado = JsonSerializer.Serialize(new { volumen })
            };
            _db.Operaciones.Add(operacion);
            _db.SaveChanges();
            return Ok(new { volumen = volumen });
        }

        [HttpGet("cilindro")]
        public IActionResult CalcularVolumenCilindro(double radio, double altura)
        {
            if (radio <= 0 || altura <= 0)
                return BadRequest("El radio y la altura deben ser mayores que 0");

            double volumen = Math.PI * radio * radio * altura;
            var operacion = new Operacion
            {
                Tipo = "volumen_cilindro",
                Parametros = JsonSerializer.Serialize(new { radio, altura }),
                Resultado = JsonSerializer.Serialize(new { volumen })
            };
            _db.Operaciones.Add(operacion);
            _db.SaveChanges();
            return Ok(new { volumen = volumen });
        }

        [HttpGet("esfera")]
        public IActionResult CalcularVolumenEsfera(double radio)
        {
            if (radio <= 0)
                return BadRequest("El radio debe ser mayor que 0");

            double volumen = (4.0 / 3.0) * Math.PI * radio * radio * radio;
            var operacion = new Operacion
            {
                Tipo = "volumen_esfera",
                Parametros = JsonSerializer.Serialize(new { radio }),
                Resultado = JsonSerializer.Serialize(new { volumen })
            };
            _db.Operaciones.Add(operacion);
            _db.SaveChanges();
            return Ok(new { volumen = volumen });
        }

        [HttpGet("cono")]
        public IActionResult CalcularVolumenCono(double radio, double altura)
        {
            if (radio <= 0 || altura <= 0)
                return BadRequest("El radio y la altura deben ser mayores que 0");

            double volumen = (1.0 / 3.0) * Math.PI * radio * radio * altura;
            var operacion = new Operacion
            {
                Tipo = "volumen_cono",
                Parametros = JsonSerializer.Serialize(new { radio, altura }),
                Resultado = JsonSerializer.Serialize(new { volumen })
            };
            _db.Operaciones.Add(operacion);
            _db.SaveChanges();
            return Ok(new { volumen = volumen });
        }
    }
} 