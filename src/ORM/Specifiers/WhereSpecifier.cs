using System;
using System.Collections.Generic;

namespace VoidSharp.ORM.Specifiers
{
    public class WhereSpecifier
    {
        private Tuple<string, string, object> Where { get; set; }

        public string Key => Where.Item1;
        public string Comparator => Where.Item2;
        public object Value => Where.Item3;

        public WhereSpecifier(string a, string comparator, object b)
        {
            var whereTuple = new Tuple<string, string, object>(a, comparator, b);
            Where = whereTuple;
        }
    }
}