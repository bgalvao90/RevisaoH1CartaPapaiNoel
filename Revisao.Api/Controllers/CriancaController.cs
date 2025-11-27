using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Revisao.Api.DTO;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;

namespace Revisao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriancaController : ControllerBase
    {
        private readonly ICriancaService _criancaService;
        private readonly IMapper _mapper;

        public CriancaController(ICriancaService criancaService, IMapper mapper)
        {
            _criancaService = criancaService;
            _mapper = mapper;
        }


        [HttpGet("ObterTodos")]
        public async Task<IEnumerable<Crianca>> ObterTodos()
        {
            try
            {
                var criancas = await _criancaService.ListarCriancas();
                if (criancas is null || !criancas.Any())
                {
                    Response.StatusCode = StatusCodes.Status204NoContent;
                    return Enumerable.Empty<Crianca>();
                }

                return criancas;

            }
            catch (Exception ex)
            {
                return (IEnumerable<Crianca>)StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult<CriancaRequestDto>> Adicionar(CriancaRequestDto criancaDto)
        {
            try
            {
                var crianca = _mapper.Map<Crianca>(criancaDto);

                if (crianca == null)    
                    return BadRequest("Dados da criança inválidos.");

                var novaCrianca = await _criancaService.AdicionarCrianca(crianca);
                return CreatedAtAction(nameof(Adicionar), new { id = novaCrianca.CriancaID }, novaCrianca);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
