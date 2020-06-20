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


        public String TableName;

        private List<Tuple<string, string, object>> whereList = new List<Tuple<string, string, object>>();
        private List<string> selectList = new List<string>();
        private List<Tuple<string, object>> updateList = new List<Tuple<string, object>>();
        private List<Tuple<string, object>> insertList = new List<Tuple<string, object>>();
        private List<Tuple<string, string>> createList = new List<Tuple<string, string>>();
        private string primaryKeys;

        private List<object> preparedVars = new List<object>();

        public QueryBuilder(string tableName)
        {
            if (!Database.IsConnected)
            {
                throw new DatabaseNotConnectedException("The connection to the database has not been yet finished.");
            }

            TableName = tableName;
        }

        #region Select Region

        public void SelectColumn(string val)
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

        public void InsertColumn(string key, object value)
        {
            Tuple<string, object> tuple = new Tuple<string, object>(key, value);
            insertList.Add(tuple);
        }

        #endregion

        #region Update Region

        public void UpdateColumn(string key, string value)
        {
            Tuple<string, object> tuple = new Tuple<string, object>(key, value);
            updateList.Add(tuple);
        }

        #endregion

        #region Create region

        public void CreateColumn(string key, string value)
        {
            Tuple<string, string> tuple = new Tuple<string, string>(key, value);
            createList.Add(tuple);
        }

        #endregion

        #region Execution

        public async Task<Dictionary<string, object>[]> Select()
        {
            string query = CreateQuery(QueryType.Select);
            return await ExecuteQuery(query, QueryType.Select);
        }

        public Task Create()
        {
            string query = CreateQuery(QueryType.Create);
            return ExecuteQuery(query, QueryType.Create);
        }

        public Task Insert()
        {
            string query = CreateQuery(QueryType.Insert);
            return ExecuteQuery(query, QueryType.Insert);
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

        private async Task<dynamic> ExecuteQuery(string query, QueryType queryType)
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
                if (queryType == QueryType.Select)
                {
                    Dictionary<string, object>[] obj = (Dictionary<string, object>[]) Database.RawQuery(query);
                    var task = await Task.FromResult<Dictionary<string, object>[]>(obj);
                    return task;
                }
                else
                {
                    string res = (string) Database.RawQuery(query);
                    var task = await Task.FromResult<string>(res);
                    return task;
                }
                
            }
        }

        private string CreateQuery(QueryType queryType)
        {
            string returnVal = null;
            switch (queryType)
            {
                case QueryType.Select:
                    returnVal = BuildSelectQuery();
                    break;

                case QueryType.Update:
                    returnVal = BuildUpdateQuery();
                    break;

                case QueryType.Create:
                    returnVal = BuildCreateQuery();
                    break;

                case QueryType.Insert:
                    returnVal = BuildInsertQuery();
                    break;

                default:
                    throw new NotImplementedException("Unknown query type");
            }

            return returnVal;

        }

        private string BuildInsertQuery()
        {
            List<string> query = new List<string>();
            query.Add("INSERT INTO");
            query.Add(TableName);
            query.Add("(");
            int i = 0;
            foreach (Tuple<string, object> insertClause in insertList)
            {
                bool isLast = insertList.Count == i+1;
                if (isLast)
                    query.Add(insertClause.Item1);
                else
                    query.Add(insertClause.Item1 + ",");
                i++;
            }
            query.Add(")");

            query.Add("VALUES");
            query.Add("(");
            int j = 0;
            foreach (Tuple<string, object> insertClause in insertList)
            {
                preparedVars.Add(insertClause.Item2);
                bool isLast = insertList.Count == j+1;
                if (isLast)
                    query.Add("?");
                else
                    query.Add("?,");
                j++;
            }
            query.Add(")");

            return String.Join(" ", query.ToArray());
        }

        private string BuildCreateQuery()
        {
            List<string> query = new List<string>();
            query.Add("CREATE TABLE IF NOT EXISTS");
            query.Add(TableName);
            query.Add("(");
            
            int i = 0;
            foreach (Tuple<string, string> createClause in createList)
            {
                bool isLast = createList.Count == i+1;
                if (isLast)
                    query.Add(String.Format("{0} {1}", createClause.Item1, createClause.Item2));
                else
                    query.Add(String.Format("{0} {1},", createClause.Item1, createClause.Item2));
                
                i++;
            }

            query.Add(")");

            return String.Join(" ", query.ToArray());
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
            if (whereList.Count < 1) return;
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