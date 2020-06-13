using System;

public class DatabaseSQLQueryError : Exception 
{
    public DatabaseSQLQueryError()
    {
    }

    public DatabaseSQLQueryError(string message)
    :base(message)
    {

    }
}