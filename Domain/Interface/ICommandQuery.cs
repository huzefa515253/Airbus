using System.Data;



namespace Domain.Interface
{
    public interface IMarkerQuery
    {

    }

    public interface IMarkerQuery<T>
    {

    }

    /// <summary>
    /// Database query for any of the CRUD operations.
    /// This may be typically used in Create, Update Or delete operations
    /// where the entity return type is not required
    /// </summary>
    public interface IQuery : IMarkerQuery
    {
        /// <summary>
        /// Executes the specified database.
        /// </summary>
        /// <param name="db">The database.</param>
        void Execute(IDbConnection db);
    }


    /// <summary>
    /// Database query for any of the CRUD operations.
    /// </summary>
    /// <typeparam name="T">Entity Type used for the operation</typeparam>
    public interface IQuery<T> : IMarkerQuery<T>
    {
        /// <summary>
        /// Executes the specified query using the database connection settings.
        /// </summary>
        /// <param name="db">The database object.</param>
        /// <returns>Entity type</returns>
        T Execute(IDbConnection db);
    }

    public interface IOracleQuery : IMarkerQuery
    {
        void ExecuteOra(IDbConnection db);
    }

    public interface IOracleQuery<T> : IMarkerQuery<T>
    {
        T ExecuteOra(IDbConnection db);
    }
}
