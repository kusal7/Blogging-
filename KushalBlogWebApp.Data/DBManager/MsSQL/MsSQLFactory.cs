using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBManager
{
    /// <summary>
    ///
    /// </summary>
    public class MsSQLFactory : IDatabaseFactory
    {
        public IDbConnection Db { get; set; }
        public Dialect Dialect => Dialect.SQLServer;

        public QueryBuilder QueryBuilder { get; }

        private static string _connectionString;

        public MsSQLFactory()
        { }



        public IDbConnection GetConnection()
        {

            Db = new SqlConnection(_connectionString);
            return Db;
        }


        public MsSQLFactory(IConfiguration configuration, IServiceProvider serviceProvider)
        {

            _connectionString = configuration.GetConnectionString("DatabaseConnectionString");// ConfigurationManager.ConnectionStrings[connectionStringName].ToString();
            Db = new SqlConnection(_connectionString);
            QueryBuilder = new MsSqlQueryBuilder(new MsSQLTemplate());

        }

        public void Dispose()
        {
            if (Db.State == ConnectionState.Open)
                Db.Close();
            Db.Close();
            //db.Dispose();
        }

        // public Log.ILogger DbLogger { get; set; }
    }
}