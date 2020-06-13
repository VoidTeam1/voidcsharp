using System;
using System.Linq;

using System.Threading.Tasks;
using System.Collections.Generic;

using Void.GLua;

namespace Void.ORM
{
    static class Database
    {

        public static DatabaseDriver DatabaseDriver;
        public static bool IsConnected = false;

        public static Task Connect()
        {
            Console.WriteLine("[Void.ORM] Connecting to database..");

            string host = SQLConfig.host;
            string username = SQLConfig.username;
            string password = SQLConfig.password;
            string database = SQLConfig.database;
            int port = SQLConfig.port;
            bool usingMySQL = SQLConfig.usingMySQL;

            DatabaseDriver = usingMySQL ? (DatabaseDriver) new MySQLoo() : new SQLite();

            if (usingMySQL) 
            {
                throw new NotImplementedException();
            } 
            else 
            {
                ConnectFinished();

                // The connection is basically already done, return a completed task
                return Task.CompletedTask;
            }

        }


        // SQLite is not async, so we can return dynamic
        public static Dictionary<string, object>[] RawQuery(string query)
        {
            // This only works for SQLite, MySQL needs to use PreparedQueries
            if (SQLConfig.usingMySQL) {
                throw new NotSupportedException("RawQuery is only for SQLite. Use Prepare for MySQL.");
            }

            string escapedQuery = DatabaseDriver.Escape(query, true);
            Dictionary<string, object>[] result = DatabaseDriver.Query(escapedQuery);

            return result;
        }

        private static void ConnectFinished()
        {
            IsConnected = true;

            Console.WriteLine("[Void.ORM] Successfully finished to database!");
        }
    }
}