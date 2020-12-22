using System;

namespace VoidSharp.ORM.Specifiers
{
    public class AlterSpecifier
    {
        private Tuple<string, string> Alter { get; set; }

        public string Name => Alter.Item1;
        public object DataType => Alter.Item2;

        public AlterSpecifier(string a, string b)
        {
            var insertTuple = new Tuple<string, string>(a, b);
            Alter = insertTuple;
        }
    }
}