using Microsoft.AspNetCore.Mvc;
using ExamenU1.Entities;
using ExamenU1.Services;

namespace ExamenU1.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _service;

        public PersonController(PersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{dni}")]
        public IActionResult GetOne(string dni)
        {
            var person = _service.GetOne(dni);
            return person != null
                ? Ok(person)
                : NotFound(new { message = "Persona no encontrada" });
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonEntity person)
        {
            if (string.IsNullOrWhiteSpace(person.DNI))
                return BadRequest(new { message = "El DNI es requerido" });

            bool created = _service.Create(person);

            if (!created)
                return BadRequest(new { message = "El DNI ya está registrado" });

            // Devuelve 201 Created
            return Created($"api/person/{person.DNI}", person);
        }

        [HttpPut("{dni}")]
        public IActionResult Update(string dni, [FromBody] PersonEntity person)
        {
            bool ok = _service.Update(dni, person);
            return ok
                ? Ok(new { message = "Actualizado correctamente" })
                : NotFound(new { message = "Persona no encontrada" });
        }

        [HttpDelete("{dni}")]
        public IActionResult Delete(string dni)
        {
            bool ok = _service.Delete(dni);
            return ok
                ? Ok(new { message = "Eliminado correctamente" })
                : NotFound(new { message = "Persona no encontrada" });
        }
    }
}