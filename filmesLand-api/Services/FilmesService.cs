using filmesLand_api.Repositories;
using filmesLand_api.Shared.Entities;
using filmesLand_api.Shared.Models;
using filmesLand_api.Shared.OutputPort;
using Microsoft.AspNetCore.Mvc;

namespace filmesLand_api.Services
{
    public class FilmesService
    {
        private readonly OutputPort _outputPort;
        private readonly FilmesRepository _repository;

        public FilmesService(FilmesRepository repository) { 
            _outputPort = new OutputPort();
            _repository = repository;
        }

        public async Task<IActionResult> ObterFilmesServices(CancellationToken cancellationToken)
        {
            var encontrouFilmes = await _repository.ObterFilmesRepository(cancellationToken);

            return _outputPort.Sucesso(encontrouFilmes);
        }

        public async Task<IActionResult> ObterFilmesNaoAvaliadosServices(CancellationToken cancellationToken)
        {
            var encontrouFilmes = await _repository.ObterFilmesNaoAvaliadosRepository(cancellationToken);

            return _outputPort.Sucesso(encontrouFilmes);
        }

        public async Task<IActionResult> CriarFilmeServices(FilmeRequest filmeRequest, CancellationToken cancellationToken)
        {
            var filme = new Filme(filmeRequest);
            await _repository.CriarFilme(filme, cancellationToken);

            return _outputPort.Sucesso("Filme criado com sucesso");
        }

        public async Task<IActionResult> AtualizarFilmeServices(int id, FilmeRequest filmeRequest, CancellationToken cancellationToken)
        {
            Filme filme = new Filme(filmeRequest);
            await _repository.AtualizarFilme(id, filme, cancellationToken);

            return _outputPort.Sucesso("Filme atualizado com sucesso");
        }

        public async Task<IActionResult> AvaliarFilmeServices(int id, float nota, CancellationToken cancellationToken)
        {
            await _repository.AvaliarFilme(id, nota, cancellationToken);

            return _outputPort.Sucesso("Filme avaliado com sucesso");
        }

        public async Task<IActionResult> DeletarFilmeServices(int id, CancellationToken cancellationToken)
        {
            await _repository.DeletarFilme(id, cancellationToken);

            return _outputPort.Sucesso("Filme excluído com sucesso");
        }
    }
}
