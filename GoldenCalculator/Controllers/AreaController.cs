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
    public class AreaController : ControllerBase
    {
        private readonly OperacionService _servicio;
        public AreaController(OperacionService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("cuadrado")]
        public async Task<IActionResult> CalcularAreaCuadrado(double lado)
        {
            if (lado <= 0)
                return BadRequest("El lado debe ser mayor que 0");

            double area = lado * lado;
            var operacion = new Operacion
            {
                Tipo = "area_cuadrado",
                Parametros = JsonSerializer.Serialize(new { lado }),
                Resultado = JsonSerializer.Serialize(new { area })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { area = area });
        }

        [HttpGet("rectangulo")]
        public async Task<IActionResult> CalcularAreaRectangulo(double base_, double altura)
        {
            if (base_ <= 0 || altura <= 0)
                return BadRequest("La base y la altura deben ser mayores que 0");

            double area = base_ * altura;
            var operacion = new Operacion
            {
                Tipo = "area_rectangulo",
                Parametros = JsonSerializer.Serialize(new { base_, altura }),
                Resultado = JsonSerializer.Serialize(new { area })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { area = area });
        }

        [HttpGet("triangulo")]
        public async Task<IActionResult> CalcularAreaTriangulo(double base_, double altura)
        {
            if (base_ <= 0 || altura <= 0)
                return BadRequest("La base y la altura deben ser mayores que 0");

            double area = (base_ * altura) / 2;
            var operacion = new Operacion
            {
                Tipo = "area_triangulo",
                Parametros = JsonSerializer.Serialize(new { base_, altura }),
                Resultado = JsonSerializer.Serialize(new { area })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { area = area });
        }

        [HttpGet("circulo")]
        public async Task<IActionResult> CalcularAreaCirculo(double radio)
        {
            if (radio <= 0)
                return BadRequest("El radio debe ser mayor que 0");

            double area = Math.PI * radio * radio;
            var operacion = new Operacion
            {
                Tipo = "area_circulo",
                Parametros = JsonSerializer.Serialize(new { radio }),
                Resultado = JsonSerializer.Serialize(new { area })
            };
            await _servicio.AgregarOperacionAsync(operacion);
            return Ok(new { area = area });
        }

        [HttpGet("historial")]
        public async Task<IActionResult> Historial()
        {
            var historial = await _servicio.ObtenerHistorialAsync();
            return Ok(historial);
        }
    }
} 