using System;
using System.Threading.Tasks;
using VoidSharp.ORM;

namespace VoidSharp
{

    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public interface IDatabaseDriver
    {
        /// <summary>
        /// Queries the database with an SQL Query.
        /// </summary>
        /// <param name="query">The SQL query</param>
        /// <returns>A database result object</returns>
        public Task<object> Query(string query);
        
        /// <summary>
        /// Escapes the string for SQL database usage.
        /// </summary>
        /// <param name="str">The string to escape.</param>
        /// <param name="noQuotes">Should wrap the string in quotes?</param>
        /// <returns>The escaped string.</returns>
        public string Escape(string str, bool noQuotes = false);
    }


    // ReSharper disable once InconsistentNaming
    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public class MySQLoo : IDatabaseDriver
    {
        public Task<DatabaseConnectionResult> Connect(DatabaseCredentials credentials)
        {
            throw new NotImplementedException();
        }
        
        public Task<object> Query(string query)
        {
            throw new NotImplementedException();
        }
        public string Escape(string str, bool noQuotes = false)
        {
            throw new NotImplementedException();
        }
    }
    
    // ReSharper disable once InconsistentNaming
    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public class SQLite : IDatabaseDriver
    {
        public Task<object> Query(string query)
        {
            throw new NotImplementedException();
        }

        public string Escape(string str, bool noQuotes = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "sql.LastError()"
        /// </summary>
        public string LastError()
        {
            throw new NotImplementedException();
        }
    }
}