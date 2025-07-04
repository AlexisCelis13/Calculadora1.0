using Microsoft.AspNetCore.Mvc;
using GoldenCalculator.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using GoldenCalculator.Services;

namespace GoldenCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VolumenController : ControllerBase
    
    {
        private readonly OperacionService _servicio;
        public VolumenController(OperacionService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("cubo")]
        public async Task<IActionResult> CalcularVolumenCubo(double lado)
        {
            if (lado <= 0)
                return BadRequest("El lado debe ser mayor que 0");

            double volumen = lado * lado * lado;
            var operacion = new Operacion
            {
                Tipo = "volumen_cubo",
                Parametros = System.Text.Json.JsonSerializer.Serialize(new { lado }),
                Resultado = System.Text.Json.JsonSerializer.Serialize(new { volumen })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { volumen = volumen });
        }

        [HttpGet("prisma-rectangular")]
        public async Task<IActionResult> CalcularVolumenPrismaRectangular(double largo, double ancho, double alto)
        {
            if (largo <= 0 || ancho <= 0 || alto <= 0)
                return BadRequest("Las dimensiones deben ser mayores que 0");

            double volumen = largo * ancho * alto;
            var operacion = new Operacion
            {
                Tipo = "volumen_prisma_rectangular",
                Parametros = System.Text.Json.JsonSerializer.Serialize(new { largo, ancho, alto }),
                Resultado = System.Text.Json.JsonSerializer.Serialize(new { volumen })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { volumen = volumen });
        }

        [HttpGet("cilindro")]
        public async Task<IActionResult> CalcularVolumenCilindro(double radio, double altura)
        {
            if (radio <= 0 || altura <= 0)
                return BadRequest("El radio y la altura deben ser mayores que 0");

            double volumen = Math.PI * radio * radio * altura;
            var operacion = new Operacion
            {
                Tipo = "volumen_cilindro",
                Parametros = System.Text.Json.JsonSerializer.Serialize(new { radio, altura }),
                Resultado = System.Text.Json.JsonSerializer.Serialize(new { volumen })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { volumen = volumen });
        }

        [HttpGet("esfera")]
        public async Task<IActionResult> CalcularVolumenEsfera(double radio)
        {
            if (radio <= 0)
                return BadRequest("El radio debe ser mayor que 0");

            double volumen = (4.0 / 3.0) * Math.PI * radio * radio * radio;
            var operacion = new Operacion
            {
                Tipo = "volumen_esfera",
                Parametros = System.Text.Json.JsonSerializer.Serialize(new { radio }),
                Resultado = System.Text.Json.JsonSerializer.Serialize(new { volumen })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { volumen = volumen });
        }

        [HttpGet("cono")]
        public async Task<IActionResult> CalcularVolumenCono(double radio, double altura)
        {
            if (radio <= 0 || altura <= 0)
                return BadRequest("El radio y la altura deben ser mayores que 0");

            double volumen = (1.0 / 3.0) * Math.PI * radio * radio * altura;
            var operacion = new Operacion
            {
                Tipo = "volumen_cono",
                Parametros = System.Text.Json.JsonSerializer.Serialize(new { radio, altura }),
                Resultado = System.Text.Json.JsonSerializer.Serialize(new { volumen })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { volumen = volumen });
        }
    }
} 