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
           
