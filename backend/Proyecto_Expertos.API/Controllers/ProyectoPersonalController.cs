using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Expertos.Application.Interfaces;
using Proyecto_Expertos.Domain.Entities;
using Proyecto_Expertos.Application.Features.Proyectos.DTOs;
using System.ComponentModel.DataAnnotations;
namespace Proyecto_Expertos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoPersonalController : ControllerBase
    {
        private readonly IPPERepository _ppeRepository;
        private readonly IValidator<CreateProyectoRequestDto> _validator;
        public ProyectoPersonalController(IPPERepository ppeRepository, IValidator<CreateProyectoRequestDto> validator)
        {
            _ppeRepository = ppeRepository;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProyectos()
        {
            var proyectos = await _ppeRepository.GetAllAsync();

            var response = proyectos.Select(h => new ProyectosResponseDto
            {
                Id = h.Id,
                Nombre = h.Nombre
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> crearPPE([FromBody] CreateProyectoRequestDto request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var nuevoProyecto = new PPE_Global
            {
                Nombre = request.Nombre
            };

            var proyectoCreado = await _ppeRepository.AddSync(nuevoProyecto);

            var response =new ProyectosResponseDto
            {
                Id = proyectoCreado.Id,
                Nombre = proyectoCreado.Nombre
            };

            return CreatedAtAction(nameof(GetProyectos),new {id = response.Id}, response);
        }
    }
}