using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;
using System.Data.Common;

namespace Questao5.Application.Handlers.Base
{
    public abstract class CommandQueryBase<T, S> : IRequestHandler<T, S> where T : IRequest<S>
    {
        protected readonly DatabaseConfig _databaseConfig;

        public CommandQueryBase(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public abstract Task<S> Handle(T request, CancellationToken cancellationToken);

        public DbConnection GetConnection()
        {
            return new SqliteConnection(_databaseConfig.Name);
        }
    }
}
