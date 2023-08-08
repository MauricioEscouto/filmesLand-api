using filmesLand_api.Repositories;
using filmesLand_api.Shared.Entities;
using filmesLand_api.Shared.Models;
using filmesLand_api.Shared.OutputPort;
using filmesLand_api.Validation;
using Microsoft.AspNetCore.Mvc;

namespace filmesLand_api.Services
{
    public class FilmesService
    {
        private readonly OutputPort _outputPort;
        private readonly FilmesRepository _repository;
        private readonly FilmesValidation _validation;

        public FilmesService(FilmesRepository repository) { 
            _outputPort = new OutputPort();
            _repository = repository;
            _validation = new FilmesValidation(_outputPort);
        }

        public async Task<IActionResult> GetMoviesServices()
        {
            var filmesEncontrados = await _repository.ObterFilmesRepository();
            var resposta = await _validation.ObterFilmesValidation(filmesEncontrados);

            return resposta;
        }

        public async Task<IActionResult> GetUnratedMoviesServices()
        {
            var filmesEncontrados = await _repository.ObterFilmesNaoAvaliadosRepository();
            var resposta = await _validation.ObterFilmesNaoAvaliadosValidation(filmesEncontrados);

            return resposta;
        }

        public async Task<IActionResult> CreateMovieServices(FilmeRequest filmeRequest)
        {
            var resposta = await _validation.CriarFilmeValidation(filmeRequest) as ObjectResult;
            if (resposta!.StatusCode == 400)
            {
                string mensagem = resposta.Value!.ToString()!;
                return _outputPort.FalhaRequisicao(mensagem);
            }
            else
            {
                var filme = new Filme(filmeRequest);
                await _repository.CriarFilme(filme);
            }

            return _outputPort.Sucesso("Filme criado com sucesso");
        }

        public async Task<IActionResult> UpdateMovieServices(int id, FilmeRequest filmeRequest)
        {
            var resposta = await _validation.CriarFilmeValidation(filmeRequest) as ObjectResult;
            if (resposta!.StatusCode == 400)
            {
                string mensagem = resposta.Value!.ToString()!;
                return _outputPort.FalhaRequisicao(mensagem);
            }
            else
            {
                Filme filme = new Filme(filmeRequest);
                var respostaPosRequisicao = await _repository.AtualizarFilme(id, filme);
                var respostaValidation = await _validation.AtualizarFilmeValidation(respostaPosRequisicao) as ObjectResult;

                if (respostaValidation.StatusCode == 404)
                {
                    string mensagem = respostaValidation.Value!.ToString()!;
                    return _outputPort.NaoEncontrado(mensagem);
                }
            }
            
            return _outputPort.Sucesso("Filme atualizado com sucesso");
        }

        public async Task<IActionResult> RateMovieServices(int id, float nota)
        {
            var resposta = await _validation.AvaliarFilmeValidation(nota) as ObjectResult;
            if (resposta!.StatusCode == 400)
            {
                string mensagem = resposta.Value!.ToString()!;
                return _outputPort.FalhaRequisicao(mensagem);
            }
            else
            {
                var respostaPosRequisicao = await _repository.AvaliarFilme(id, nota);
                var respostaValidation = await _validation.AtualizarFilmeValidation(respostaPosRequisicao) as ObjectResult;

                if (respostaValidation.StatusCode == 404)
                {
                    string mensagem = respostaValidation.Value!.ToString()!;
                    return _outputPort.NaoEncontrado(mensagem);
                }
            }

            return _outputPort.Sucesso("Filme avaliado com sucesso");
        }

        public async Task<IActionResult> DeleteMovieServices(int id)
        {
            var respostaPosRequisicao = await _repository.DeletarFilme(id);
            var respostaValidation = await _validation.DeletarFilmeValidation(respostaPosRequisicao) as ObjectResult;

            if (respostaValidation.StatusCode == 404)
            {
                string mensagem = respostaValidation.Value!.ToString()!;
                return _outputPort.NaoEncontrado(mensagem);
            }

            return _outputPort.Sucesso("Filme excluído com sucesso");
        }
    }
}
