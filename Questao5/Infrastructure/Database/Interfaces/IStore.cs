using MediatR;

namespace Questao5.Infrastructure.Database.Interfaces
{
    public interface IStore<T> : IRequest<T> where T : class
    {
        string GetSql();
    }
}
