using filmesLand_api.Shared.Context.Abstractions;
using System.Data;

namespace filmesLand_api.Shared.Context
{
    public class DbContext
    {
        public IDbConnection connection;
        public ISQLCommands sqlCommand;
        public DbContext(IDbConnection connection, ISQLCommands commands)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(DbContext.connection));
            this.sqlCommand = commands ?? throw new ArgumentNullException(nameof(sqlCommand));
        }
    }
}