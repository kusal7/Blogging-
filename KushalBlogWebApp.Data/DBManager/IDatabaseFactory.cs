using System.Data;

namespace DBManager
{
    public interface IDatabaseFactory : IDisposable
    {
        IDbConnection Db { get; }
        Dialect Dialect { get; }
        QueryBuilder QueryBuilder { get; }
        IDbConnection GetConnection();

    }
}