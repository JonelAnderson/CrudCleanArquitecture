using ARQUICAPAS.Application.Dtos.Encargado.Request;
using ARQUICAPAS.Application.Interfaces;
using ARQUICAPAS.Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ARQUICAPAS.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EncargadoController : ControllerBase
    {
        private readonly IEncargadoApplication _encargadoApplication;
        public EncargadoController(IEncargadoApplication encargadoApplication)
        {
            _encargadoApplication = encargadoApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListEncargados([FromBody] BaseFiltersRequest filters)
        {
            var response = await _encargadoApplication.ListEncargados(filters);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectEncargados()
        {
            var response = await _encargadoApplication.ListSelectEncargados();
            return Ok(response);
        }

        [HttpGet("{encargadoId:int}")]
        public async Task<IActionResult> EncargadoById(int encargadoId)
        {
            var response = await _encargadoApplication.EncargadoById(encargadoId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterEncargado([FromBody] EncargadoRequestDto requestDto)
        {
            var response = await _encargadoApplication.RegisterEncargado(requestDto);
            return Ok(response);
        }

        [HttpPut("Edit/{encargadoId:int}")]
        public async Task<IActionResult> EditEncargado([FromBody] EncargadoRequestDto requestDto, int encargadoId)
        {
            var response = await _encargadoApplication.EditEncargado(encargadoId, requestDto);
            return Ok(response);
        }

        [HttpPut("Remove/{encargadoId:int}")]
        public async Task<IActionResult> RemoveEncargado(int encargadoId)
        {
            var response = await _encargadoApplication.RemoveEncargado(encargadoId);
            return Ok(response);
        }
    }
}
