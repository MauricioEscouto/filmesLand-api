namespace filmesLand_api.Shared.Context.Abstractions
{
    public partial interface ISQLCommands
    {
        public string ObterFilmes();
        public string ObterFilmesNaoAvaliados();
        public string CriarFilme();
        public string AtualizarFilme(int id);
        public string AvaliarFilme(int id, float nota);
        public string DeletarFilme(int id);
    }
}