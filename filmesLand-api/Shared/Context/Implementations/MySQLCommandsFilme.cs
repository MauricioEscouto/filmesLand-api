using filmesLand_api.Shared.Context.Abstractions;
using filmesLand_api.Shared.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace filmesLand_api.Shared.Context.Implementations
{
    public partial class MySQLCommands : ISQLCommands
    {
        public string ObterFilmes()
        {
            string query = $@"SELECT 
                    id AS Id,
                    titulo AS Titulo,
                    diretor AS Diretor,
                    estudio AS Estudio,
                    avaliacao AS Avaliacao,
                    isAvaliado AS IsAvaliado
                 FROM filmes";

            return query;
        }

        public string ObterFilmesNaoAvaliados()
        {
            string query = $@"SELECT 
                    id AS Id,
                    titulo AS Titulo,
                    diretor AS Diretor,
                    estudio AS Estudio,
                    avaliacao AS Avaliacao,
                    isAvaliado AS IsAvaliado
                 FROM filmesland.filmes
                 WHERE isAvaliado = 0";

            return query;
        }

        public string CriarFilme()
        {
            string query = $@"INSERT INTO filmes
                                ( titulo
                                , diretor
                                , estudio) 
                                    VALUES 
                                ( @Titulo
                                , @Diretor
                                , @Estudio)
            ";

            return query;
        }

        public string AtualizarFilme(int id)
        {
            string query = $@"UPDATE filmes SET 
                          titulo = @Titulo
                        , diretor = @Diretor
                        , estudio = @Estudio
                            WHERE id = {id}
            ";

            return query;
        }

        public string AvaliarFilme(int id, float nota)
        {
            string notaFormatada = nota.ToString(System.Globalization.CultureInfo.InvariantCulture);

            string query = $@"UPDATE filmes SET 
                          avaliacao = {notaFormatada}
                        , isAvaliado = 1
                            WHERE id = {id}
            ";

            return query;
        }

        public string DeletarFilme(int id)
        {
            string query = $@"DELETE FROM filmes WHERE id = {id}";

            return query;
        }
    }
}