using filmesLand_api.Shared.Entities;
using filmesLand_api.Shared.Models;
using filmesLand_api.Shared.OutputPort;
using Microsoft.AspNetCore.Mvc;

namespace filmesLand_api.Validation
{
    public class FilmesValidation
    {
        private readonly OutputPort _outputPort;

        public FilmesValidation(OutputPort outputPort) { 
            _outputPort = outputPort;
        }

        public async Task<IActionResult> ObterFilmesValidation(List<Filme> filmes)
        {
            if (filmes.Count == 0)
            {
                return _outputPort.NaoEncontrado("Nenhum filme registrado no momento");
            }

            return _outputPort.Sucesso(filmes);
        }

        public async Task<IActionResult> ObterFilmesNaoAvaliadosValidation(List<Filme> filmes)
        {
            if (filmes.Count == 0)
            {
                return _outputPort.NaoEncontrado("Nenhum filme registrado sem avaliação no momento");
            }

            return _outputPort.Sucesso(filmes);
        }

        public async Task<IActionResult> CriarFilmeValidation(FilmeRequest filmeRequest)
        {
            if (string.IsNullOrEmpty(filmeRequest.Titulo))
            {
                return _outputPort.FalhaRequisicao("Favor informar um título válido");
            }
            else if (string.IsNullOrEmpty(filmeRequest.Diretor))
            {
                return _outputPort.FalhaRequisicao("Favor informar um diretor válido");
            }
            else if (string.IsNullOrEmpty(filmeRequest.Estudio))
            {
                return _outputPort.FalhaRequisicao("Favor informar um estúdio válido");
            }

            return _outputPort.Sucesso(filmeRequest);
        }

        public async Task<IActionResult> AtualizarFilmeValidation(int respostaPosRequisicao)
        {
            if (respostaPosRequisicao == 0)
            {
                return _outputPort.NaoEncontrado("O filme desejado para atualização não foi encontrado");
            }

            return _outputPort.Sucesso("Filme atualizado com sucesso");
        }

        public async Task<IActionResult> AvaliarFilmeValidation(float nota)
        {
            if (nota < 0 || nota > 10)
            {
                return _outputPort.FalhaRequisicao("A nota de avaliação deve estar entre 0 e 10");
            }

            return _outputPort.Sucesso("Filme avaliado com sucesso");
        }

        public async Task<IActionResult> DeletarFilmeValidation(int respostaPosRequisicao)
        {
            if (respostaPosRequisicao == 0)
            {
                return _outputPort.NaoEncontrado("O filme desejado para exclusão não foi encontrado");
            }

            return _outputPort.Sucesso("Filme deletado com sucesso");
        }
    }
}