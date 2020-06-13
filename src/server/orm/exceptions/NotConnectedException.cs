using System;

public class DatabaseNotConnectedException : Exception 
{
    public DatabaseNotConnectedException()
    {
    }

    public DatabaseNotConnectedException(string message)
    :base(message)
    {

    }
}