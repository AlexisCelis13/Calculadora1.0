using Microsoft.AspNetCore.Mvc;

namespace GoldenCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        [HttpGet("cuadrado")]
        public IActionResult CalcularAreaCuadrado(double lado)
        {
            if (lado <= 0)
                return BadRequest("El lado debe ser mayor que 0");

            double area = lado * lado;
            return Ok(new { area = area });
        }

        [HttpGet("rectangulo")]
        public IActionResult CalcularAreaRectangulo(double base_, double altura)
        {
            if (base_ <= 0 || altura <= 0)
                return BadRequest("La base y la altura deben ser mayores que 0");

            double area = base_ * altura;
            return Ok(new { area = area });
        }

        [HttpGet("triangulo")]
        public IActionResult CalcularAreaTriangulo(double base_, double altura)
        {
            if (base_ <= 0 || altura <= 0)
                return BadRequest("La base y la altura deben ser mayores que 0");

            double area = (base_ * altura) / 2;
            return Ok(new { area = area });
        }

        [HttpGet("circulo")]
        public IActionResult CalcularAreaCirculo(double radio)
        {
            if (radio <= 0)
                return BadRequest("El radio debe ser mayor que 0");

            double area = Math.PI * radio * radio;
            return Ok(new { area = area });
        }
    }
} 