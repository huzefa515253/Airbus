using System;
using System.Data;

namespace Domain.Interface
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }

        T Execute<T>(IQuery<T> query);
        void Execute(IQuery command);
    }
}
