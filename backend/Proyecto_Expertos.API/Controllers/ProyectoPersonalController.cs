using Microsoft.AspNetCore.Mvc;
using Proyecto_Expertos.Application.Interfaces;
using Proyecto_Expertos.Domain.Entities;

namespace Proyecto_Expertos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoPersonalController : ControllerBase
    {
        private readonly IPPERepository _ppeRepository;

        public ProyectoPersonalController(IPPERepository ppeRepository)
        {
            _ppeRepository = ppeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PPE_Global>>> GetAll()
        {
            var ppeList = await _ppeRepository.GetAllAsync();
            return Ok(ppeList);
        }

        [HttpPost]
        public async Task<ActionResult> crearPPE([FromBody] PPE_Global ppe)
        {
         if (string.IsNullOrWhiteSpace(ppe.Nombre))
            {
                return BadRequest("El nombre es obligatorio.");
            }

            var createdPPE = await _ppeRepository.AddSync(ppe);
            return CreatedAtAction(nameof(GetAll), new { id = createdPPE.Id }, createdPPE);
        }
    }
}