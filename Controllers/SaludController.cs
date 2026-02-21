using Microsoft.AspNetCore.Mvc;

namespace ExamenU1.Controllers
{
    [ApiController]
    [Route("api/salud")]
    public class SaludController : ControllerBase
    {
        //GET /api/salud/imc?peso={peso}&altura={altura}
        [HttpGet("imc")]
        public IActionResult CalcularIMC([FromQuery] double peso, [FromQuery] double altura)
        {
            // Validar que peso y altura sean mayores que 0
            if (peso <= 0 || altura <= 0)
                return BadRequest(new { mensaje = "Peso y altura deben ser mayores que 0" });

            double imc = peso / (altura * altura);

            // Clasificar el IMC
            string clasificacion =
                imc < 18.5 ? "Bajo peso" :
                imc < 25.0 ? "Normal" :
                imc < 30.0 ? "Sobrepeso" :
                "Obesidad";

            // Retornar el resultado
            return Ok(new
            {
                peso,
                altura,
                imc = Math.Round(imc, 2),
                clasificacion
            });
        }
    }
}