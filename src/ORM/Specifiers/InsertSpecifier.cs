using System;

namespace VoidSharp.ORM.Specifiers
{
    public class InsertSpecifier
    {
        private Tuple<string, object> Insert { get; set; }

        public string Key => Insert.Item1;
        public object Value => Insert.Item2;

        public InsertSpecifier(string a, object b)
        {
            var insertTuple = new Tuple<string, object>(a, b);
            Insert = insertTuple;
        }
    }
}