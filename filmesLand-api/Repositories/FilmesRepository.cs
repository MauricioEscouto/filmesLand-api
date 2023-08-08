using Dapper;
using filmesLand_api.Shared.AppSettings;
using filmesLand_api.Shared.Context;
using filmesLand_api.Shared.Entities;

namespace filmesLand_api.Repositories
{
    public class FilmesRepository
    {
        private readonly DbConnectionFactory _dbConnectionFactory;
        private readonly DbContext _dbContext;

        public FilmesRepository(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _dbContext = _dbConnectionFactory.ObterContexto(AppSettingsConstantes.DBMauricio);
        }

        public async Task<List<Filme>> ObterFilmesRepository()
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            IEnumerable<Filme> filmes = await connection.QueryAsync<Filme>(querys.ObterFilmes());
            return filmes.ToList();
        }

        public async Task<List<Filme>> ObterFilmesNaoAvaliadosRepository()
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            IEnumerable<Filme> filmes = await connection.QueryAsync<Filme>(querys.ObterFilmesNaoAvaliados());
            return filmes.ToList();
        }

        public Task CriarFilme(Filme filme)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            connection.Execute(querys.CriarFilme(), filme);
            return Task.CompletedTask;
        }

        public Task<int> AtualizarFilme(int id, Filme filme)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            var resposta = connection.Execute(querys.AtualizarFilme(id), filme);
            return Task.FromResult(resposta);
        }

        public Task<int> AvaliarFilme(int id, float nota)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            var resposta = connection.Execute(querys.AvaliarFilme(id, nota));
            return Task.FromResult(resposta);
        }

        public Task<int> DeletarFilme(int id)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            var resposta = connection.Execute(querys.DeletarFilme(id));
            return Task.FromResult(resposta);
        }
    }
}