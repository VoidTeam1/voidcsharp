using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using VoidSharp.Utilities;
using VoidSharp;
using VoidSharp.DarkRP;
using VoidSharp.ORM.Attributes;
using VoidSharp.ORM.QueryTypes;
using VoidSharp.ORM.Serializers;

namespace VoidSharp.ORM
{
    public class Database
    {
        public IDatabaseDriver DatabaseDriver { get; set; }
        private DatabaseCredentials DatabaseCredentials { get; set; }

        public Database(IDatabaseDriver databaseDriver)
        {
            DatabaseDriver = databaseDriver;
            
            AddSerializers();
        }
        
        public Database(IDatabaseDriver databaseDriver, DatabaseCredentials databaseCredentials)
        {
            DatabaseDriver = databaseDriver;
            DatabaseCredentials = databaseCredentials;
            
            AddSerializers();
        }

        /// <summary>
        /// Connects to the database
        /// </summary>
        /// <exception cref="Exception">Thrown when the connection attempt is unsuccessful.</exception>
        public async Task Connect(Type entryPoint)
        {
            if (DatabaseDriver is MySQLoo)
            {
                MySQLoo mySqloo = (MySQLoo) DatabaseDriver;
                
                Logger.LogInfo("Connecting to MySQL database...", "Database");
                var result = await mySqloo.Connect(DatabaseCredentials);
                
                if (result.HasFailed)
                {
                    throw new Exception("Couldn't connect to MySQL database! Error: " + result.Error);
                }
                
                Logger.LogInfo("Successfully connected to MySQL database!", "Database");
            } else if (DatabaseDriver is SQLite)
            {
                Logger.LogInfo("Initialized local SQLite database instance!", "Database");
            }
            
            await CreateTables(entryPoint);
        }

        /// <summary>
        /// Adds all the serializers that translate the object into an SQL string.
        /// </summary>
        private void AddSerializers()
        {
            SerializerMap.RegisterSerializer<DateTime, DateTimeSerializer>();
            SerializerMap.RegisterSerializer<string, StringSerializer>();
            SerializerMap.RegisterSerializer<int, IntegerSerializer>();
            SerializerMap.RegisterSerializer<Color, ColorSerializer>();
            SerializerMap.RegisterSerializer<bool, BoolSerializer>();
            SerializerMap.RegisterSerializer<Job, JobSerializer>();
            SerializerMap.RegisterSerializer<dynamic, DynamicSerializer>();
        }

        /// <summary>
        /// Creates all the tables from Models.
        /// </summary>
        private async Task CreateTables(Type entryPoint)
        {
            CreateQueryType createQueryType = new CreateQueryType(this);

            Assembly assembly = Assembly.GetAssembly(entryPoint);

            if (assembly is null)
            {
                throw new Exception("Entry assembly not found. Could not find ORM models.");
            }
            
            foreach (var type in assembly.GetExportedTypes())
            {
                if (type.GetCustomAttributes(typeof(TableAttribute), true).Length > 0) {
                    string query = createQueryType.GenerateQuery(type);
                    var result = await Query<object>(query);
                    
                    Console.WriteLine(result.Result);
                }
            }

        }

        /// <summary>
        /// Performs an SQL query on the Database directly. This is used internally, but can be also used 
        /// </summary>
        /// <param name="query">The SQL Query</param>
        /// <returns>DatabaseResult</returns>
        public async Task<DatabaseResult<T>> Query<T>(string query) where T : new()
        {
            object data = await DatabaseDriver.Query(query);
            return new DatabaseResult<T>(data);
        }

        /// <summary>
        /// Selects rows from the Database.
        /// </summary>
        /// <typeparam name="T">Wanted class</typeparam>
        /// <returns>SelectQueryType</returns>
        public SelectQueryType<T> Select<T>() where T : new()
        {
            return new SelectQueryType<T>(this);
        }
        
        /// <summary>
        /// Updates one row in the database.
        /// </summary>
        /// <param name="obj">The changed object.</param>
        /// <returns>UpdateQueryType</returns>
        public UpdateQueryType<T> Update<T>(object obj) where T : new()
        {
            var updateQueryType = new UpdateQueryType<T>(this);
            return updateQueryType.Update(obj);
        }
        
        /// <summary>
        /// Alters a database model - should be only used in migrations, nowhere else!
        /// </summary>
        public AlterQueryType<T> Alter<T>() where T : new()
        {
            return new AlterQueryType<T>(this);
        }
        
        /// <summary>
        /// Deletes row(s) from the database.
        /// </summary>
        public DeleteQueryType<T> Delete<T>() where T : new()
        {
            return new DeleteQueryType<T>(this);
        }
        
        /// <summary>
        /// Inserts an object into the database.
        /// </summary>
        /// <param name="obj">The object to insert.</param>
        /// <typeparam name="T">The object class.</typeparam>
        /// <returns>InsertQueryType</returns>
        public InsertQueryType<T> Insert<T>(object obj) where T : new()
        {
            var insertQueryType = new InsertQueryType<T>(this);
            return insertQueryType.Insert(obj);
        }
        
        /// <summary>
        /// Drops a table from the database. Should be ONLY used in migrations.
        /// </summary>
        public DropQueryType<T> Drop<T>() where T : new()
        {
            return new DropQueryType<T>(this);
        }

        /// <summary>
        /// Replaces an object if exists or inserts a new row. (based on primary key)
        /// </summary>
        public InsertQueryType<T> Replace<T>(object obj) where T : new()
        {
            var insertQueryType = new InsertQueryType<T>(this);
            return insertQueryType.Replace(obj);
        }
        
        
    }
}