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

        public async Task<List<Filme>> ObterFilmesRepository(CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            IEnumerable<Filme> filmes = await connection.QueryAsync<Filme>(querys.ObterFilmes(), cancellationToken);
            return filmes.ToList();
        }

        public async Task<List<Filme>> ObterFilmesNaoAvaliadosRepository(CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            IEnumerable<Filme> filmes = await connection.QueryAsync<Filme>(querys.ObterFilmesNaoAvaliados(), cancellationToken);
            return filmes.ToList();
        }

        public Task CriarFilme(Filme filme, CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            connection.Execute(querys.CriarFilme(), filme);
            return Task.CompletedTask;
        }

        public Task AtualizarFilme(int id, Filme filme, CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            connection.Execute(querys.AtualizarFilme(id), filme);
            return Task.CompletedTask;
        }

        public Task AvaliarFilme(int id, float nota, CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            connection.Execute(querys.AvaliarFilme(id, nota), cancellationToken);
            return Task.CompletedTask;
        }

        public Task DeletarFilme(int id, CancellationToken cancellationToken)
        {
            var connection = _dbContext.connection;
            var querys = _dbContext.sqlCommand;

            connection.Execute(querys.DeletarFilme(id), cancellationToken);
            return Task.CompletedTask;
        }
    }
}
