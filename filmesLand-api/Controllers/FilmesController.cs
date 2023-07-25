using filmesLand_api.Services;
using filmesLand_api.Shared.Entities;
using filmesLand_api.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace filmesLand_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly FilmesService _service;

        public FilmesController(FilmesService service)
        {
            _service = service;
        }

        [HttpGet("Obter")]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterFilmes(CancellationToken cancellationToken)
        {
            return await _service.ObterFilmesServices(cancellationToken);
        }

        [HttpGet("ObterNaoAvaliados")]
        [ProducesResponseType(typeof(Filme), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterFilmesNaoAvaliados(CancellationToken cancellationToken)
        {
            return await _service.ObterFilmesNaoAvaliadosServices(cancellationToken);
        }

        [HttpPost]
        [Route("Criar")]
        [ProducesResponseType(typeof(FilmeRequest), StatusCodes.Status200OK)]
        public async Task<IActionResult> CriarFilme([FromBody] FilmeRequest request, CancellationToken cancellationToken)
        {
            return await _service.CriarFilmeServices(request, cancellationToken);
        }

        [HttpPut]
        [Route("Atualizar/{id:int}")]
        public async Task<IActionResult> AtualizarFilme(int id, FilmeRequest request, CancellationToken cancellationToken)
        {
            return await _service.AtualizarFilmeServices(id, request, cancellationToken);
        }

        [HttpPut]
        [Route("Avaliar/{id:int}")]
        public async Task<IActionResult> AvaliarFilme(int id, float nota, CancellationToken cancellationToken)
        {
            return await _service.AvaliarFilmeServices(id, nota, cancellationToken);
        }

        [HttpDelete]
        [Route("Deletar/{id:int}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> Deletar(int id, CancellationToken cancellationToken)
        {
            return await _service.DeletarFilmeServices(id, cancellationToken);
        }
    }
}