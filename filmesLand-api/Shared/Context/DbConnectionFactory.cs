using filmesLand_api.Shared.AppSettings;
using filmesLand_api.Shared.Context.Abstractions;
using filmesLand_api.Shared.Context.Implementations;
using MySql.Data.MySqlClient;
using System.Data;

namespace filmesLand_api.Shared.Context
{
    public class DbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContext ObterContexto(string AppSettingsSection)
        {
            IConfigurationSection configuracaoSessao = _configuration.GetSection(AppSettingsSection);
            AppSettingsDbConfiguracao configSessao = new();
            configuracaoSessao.Bind(configSessao);

            IDbConnection dbConnection;
            ISQLCommands sqlCommands;

            dbConnection = new MySqlConnection(configSessao.ConnectionString);
            sqlCommands = new MySQLCommands();

            return new DbContext(dbConnection, sqlCommands);
        }
    }
}