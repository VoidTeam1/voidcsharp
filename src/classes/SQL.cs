using System;
using System.Collections.Generic;

namespace Void.GLua
{

    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public abstract class DatabaseDriver
    {
        public abstract Dictionary<string, object>[] Query(string query);
        public abstract string Escape(string str, bool noQuotes = false);
    }


    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public class MySQLoo : DatabaseDriver
    {
        public override Dictionary<string, object>[] Query(string query)
        {
            throw new NotImplementedException();
        }
        public override string Escape(string str, bool noQuotes = false)
        {
            throw new NotImplementedException();
        }
    }
    
    /// <summary>
    /// @CSharpLua.Ignore
    /// </summary>
    public class SQLite : DatabaseDriver
    {
        public override Dictionary<string, object>[] Query(string query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// @CSharpLua.Template = "sql.SQLStr({0}, {1})"
        /// </summary>
        public override string Escape(string str, bool noQuotes = false)
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