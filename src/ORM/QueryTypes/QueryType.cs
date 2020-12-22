using System;

namespace VoidSharp.ORM.QueryTypes
{
    public abstract class QueryType
    {
        public abstract string GenerateQuery(Type t);
        protected Database Database { get; set; }

        protected QueryType(Database database)
        {
            Database = database;
        }
    }
}