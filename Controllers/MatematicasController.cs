using Microsoft.AspNetCore.Mvc;

namespace ExamenU1.Controllers
{
    [ApiController]
    [Route("api/matematicas")]
    public class MatematicasController : ControllerBase
    {
        // GET /api/matematicas/tabla/{numero}?hasta={limite}


        [HttpGet("tabla/{numero}")]
        public IActionResult Tabla(int numero, [FromQuery] int? hasta)
        {
            // Si no se proporciona el parámetro 'hasta', se asume un valor predeterminado de 10
            int limite = hasta ?? 10;

            // Validar que el límite sea un número positivo
            if (limite <= 0)
                return BadRequest(new { mensaje = "El límite debe ser mayor que 0" });


            // Generar la tabla de multiplicar
            var tabla = new List<string>();
            for (int i = 1; i <= limite; i++)
            {
                tabla.Add($"{numero} x {i} = {numero * i}");
            }

            // Retornar la respuesta con el número, el límite y la tabla de multiplicar
            return Ok(new
            {
                numero,
                hasta = limite,
                tabla
            });
        }
    }
}