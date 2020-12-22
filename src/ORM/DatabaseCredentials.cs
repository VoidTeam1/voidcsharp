using VoidSharp;
// Resharper is crying because it is being accessed from Lua state, and obviously Rider doesn't know that
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace VoidSharp.ORM
{
    public readonly struct DatabaseCredentials
    {
        public string Host { get; }
        public string Username { get; }
        public string Password { get; }
        public string Database { get; }
        public int Port { get; }

        public DatabaseCredentials(string host, string username, string password, string database, int port = 3306)
        {
            Host = host;
            Username = username;
            Password = password;
            Database = database;
            Port = port;
        }
        
        // ReSharper disable once InconsistentNaming
        public static DatabaseCredentials ParseFromJSON(string json)
        {
            dynamic obj = JSON.Parse(json);
            return new DatabaseCredentials(obj.host, obj.username, obj.password, obj.database, obj.port);
        }
    }
}