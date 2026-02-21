using Microsoft.AspNetCore.Mvc;

namespace ExamenU1.Controllers
{
    [ApiController]
    [Route("api/conversiones")]
    public class ConversionesController : ControllerBase
    {
        // GET /api/conversiones/temperatura?valor={valor}&de={escalaOrigen}&a={escalaDestino}
        [HttpGet("temperatura")]
        public IActionResult ConvertirTemperatura([FromQuery] double valor, [FromQuery] string de, [FromQuery] string a)
        {
            de = (de ?? "").Trim().ToUpper();
            a = (a ?? "").Trim().ToUpper();

            if (!EsEscalaValida(de) || !EsEscalaValida(a))
                return BadRequest(new { mensaje = "Escalas válidas: C, F, K" });

            double convertido = Convertir(valor, de, a);

            return Ok(new
            {
                valorOriginal = valor,
                escalaOriginal = NombreEscala(de),
                valorConvertido = Math.Round(convertido, 2),
                escalaDestino = NombreEscala(a)
            });
        }

        private static bool EsEscalaValida(string e) => e == "C" || e == "F" || e == "K";

        private static string NombreEscala(string e) => e switch
        {
            "C" => "Celsius",
            "F" => "Fahrenheit",
            "K" => "Kelvin",
            _ => e
        };

        private static double Convertir(double valor, string de, string a)
        {
            if (de == a) return valor;

            // Primero convertimos a Celsius
            double celsius = de switch
            {
                "C" => valor,
                "F" => (valor - 32) * 5 / 9,
                "K" => valor - 273.15,
                _ => valor
            };

            // Luego de Celsius a destino
            return a switch
            {
                "C" => celsius,
                "F" => (celsius * 9 / 5) + 32,
                "K" => celsius + 273.15,
                _ => celsius
            };
        }
    }
}