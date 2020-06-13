using System;
using System.Linq;

using System.Collections.Generic;

using System.Threading.Tasks;

using Void.GLua;

namespace Void.ORM
{

    public enum QueryType
    {
        Select,
        Insert,
        Update,
        Delete,
        Drop,
        Create,

    }

    public class QueryBuilder
    {

        public QueryType QueryType;

        public String TableName;

        private List<Tuple<string, string, object>> whereList = new List<Tuple<string, string, object>>();
        private List<string> selectList = new List<string>();
        private List<Tuple<string, object>> updateList = new List<Tuple<string, object>>();
        private List<Tuple<string, object>> insertList = new List<Tuple<string, object>>();
        private List<Tuple<string, object>> createList = new List<Tuple<string, object>>();
        private string primaryKeys;

        private List<object> preparedVars = new List<object>();

        public QueryBuilder(string tableName, QueryType queryType)
        {
            if (!Database.IsConnected)
            {
                throw new DatabaseNotConnectedException("The connection to the database has not been yet finished.");
            }

            TableName = tableName;
            QueryType = queryType;
        }

        #region Select Region

        public void Select(string val)
        {
            selectList.Add(val);
        }

        #endregion


        #region Where Selection

        public void Where(string key, string comparison, object value)
        {
            Tuple<string, string, object> tuple = new Tuple<string, string, object>(key, comparison, value);
            whereList.Add(tuple);
        }

        public void Where(string key, object value)
        {
            Where(key, "=", value);
        }

        public void WhereEqual(string key, object value)
        {
            Where(key, "=", value);
        }

        public void WhereNotEqual(string key, object value)
        {
            Where(key, "!=", value);
        }

        #endregion

        #region Insert Region

        public void Insert(string key, object value)
        {
            Tuple<string, object> tuple = new Tuple<string, object>(key, value);
            insertList.Add(tuple);
        }

        #endregion

        #region Update Region

        public void Update(string key, string value)
        {
            Tuple<string, object> tuple = new Tuple<string, object>(key, value);
            updateList.Add(tuple);
        }

        #endregion

        #region Create region

        public void Create(string key, object value)
        {
            Tuple<string, object> tuple = new Tuple<string, object>(key, value);
            createList.Add(tuple);
        }

        #endregion

        #region Execution

        public Task<Dictionary<string, object>[]> Execute()
        {
            string query = CreateQuery();
            return ExecuteQuery(query);
        }


        #endregion

        #region Query building

        string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        private async Task<Dictionary<string, object>[]> ExecuteQuery(string query)
        {
            if (SQLConfig.usingMySQL)
            {
                // Prepared query
                throw new NotImplementedException();
            }
            else
            {
                // Replace question marks
                foreach (object var in preparedVars)
                {
                    query = ReplaceFirst(query, "?", var.ToString());
                }
                
                Console.WriteLine(query);
                Dictionary<string, object>[] dict = Database.RawQuery(query);
                var task = await Task.FromResult<Dictionary<string, object>[]>(dict);
                return task;
            }
        }

        private string CreateQuery()
        {
            string returnVal = null;
            switch (QueryType)
            {
                case QueryType.Select:
                    returnVal = BuildSelectQuery();
                    break;

                case QueryType.Update:
                    returnVal = BuildUpdateQuery();
                    break;

                default:
                    throw new NotImplementedException("Unknown query type");
            }

            return returnVal;

        }

        private string BuildSelectQuery()
        {
            List<string> query = new List<string>();
            query.Add("SELECT");
            if (selectList.Count > 0)
            {
                query.Add(String.Join(", ", selectList));
            }
            else
            {
                query.Add("*");
            }

            query.Add(String.Format("FROM `{0}`", TableName));
            AddWhereClause(query);

            return String.Join(" ", query.ToArray());
        }

        private string BuildUpdateQuery()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Selectors Region

        private void AddWhereClause(List<string> list)
        {
            list.Add("WHERE");
            bool isFirst = true;
            foreach (Tuple<string, string, object> whereClause in whereList)
            {
                if (!isFirst)
                {
                    list.Add("AND");
                }
                list.Add("`" + whereClause.Item1 + "`");
                list.Add(whereClause.Item2);
                list.Add("?");

                preparedVars.Add(whereClause.Item3);

                isFirst = false;
            }
        }

        #endregion



    }
}