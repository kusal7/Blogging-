namespace DBManager
{
    public static class DbFactoryProvider
    {
        private static IDatabaseFactory _currentDatabaseFactory;



        public static void SetCurrentDbFactory(MsSQLFactory dbFactory)
        {

            _currentDatabaseFactory = dbFactory;
        }

        //public static IDatabaseFactory GetFactory(string connectionString)
        //{
        //	IDatabaseFactory dbfactory = _currentDatabaseFactory ?? new MsSQLFactory(connectionString);
        //	return dbfactory;
        //}
        public static IDatabaseFactory GetFactory()
        {
            DBManager.MsSQLFactory obj = new MsSQLFactory();
            _currentDatabaseFactory = obj;
            if (_currentDatabaseFactory == null)
                throw new Exception("Please set first default db factory!");
            return _currentDatabaseFactory;
        }

    }
}