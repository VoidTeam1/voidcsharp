namespace VoidSharp.ORM
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DatabaseConnectionResult
    {
        public bool HasFailed { get; }
        public string Error { get; }
        
        public DatabaseConnectionResult(bool hasFailed, string error = null)
        {
            HasFailed = hasFailed;
            Error = error;
        }
    }
}