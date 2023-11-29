namespace DBManager
{
    public interface ITableNameResolver
    {
        string ResolveTableName(Type type);
    }
}