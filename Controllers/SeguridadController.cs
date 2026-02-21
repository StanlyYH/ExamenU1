using Microsoft.AspNetCore.Mvc;
using ExamenU1.Models;

namespace ExamenU1.Controllers
{
    [ApiController]
    [Route("api/seguridad")]
    public class SeguridadController : ControllerBase
    {
        // POST /api/seguridad/validar-password
        [HttpPost("validar-password")]
        public IActionResult ValidarPassword([FromBody] PasswordRequest request)
        {
            // Validar que la contraseña cumpla con los requisitos:
            string password = request.Password ?? "";

            bool longitudMinima = password.Length >= 8;
            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneNumero = false;

            // especiales permitidos: (@, #, $, %, &, *)
            string especiales = "@#$%&*";
            bool tieneEspecial = false;

            foreach (char c in password)
            {
                // Verificar cada carácter para determinar si cumple con los requisitos
                if (char.IsUpper(c)) tieneMayuscula = true;
                else if (char.IsLower(c)) tieneMinuscula = true;
                else if (char.IsDigit(c)) tieneNumero = true;
                else if (especiales.Contains(c)) tieneEspecial = true;
            }
            // La contraseña es válida si cumple con todos los requisitos
            bool esValida = longitudMinima && tieneMayuscula && tieneMinuscula && tieneNumero && tieneEspecial;

            // Preparar el mensaje de respuesta
            string mensaje = esValida ? "Contraseña segura" : "Contraseña insegura";

            return Ok(new
            {
                // Indicar si la contraseña es válida o no
                esValida,
                mensaje,
                requisitos = new
                {
                    longitudMinima,
                    tieneMayuscula,
                    tieneMinuscula,
                    tieneNumero,
                    tieneEspecial
                }
            });
        }
    }
}