﻿using System;
 using System.Collections.Generic;

 namespace VoidSharp
{
    // ReSharper disable once InconsistentNaming
    public static class JSON
    {
        /// <summary>
        /// Converts JSON to a Table
        /// </summary>
        public static dynamic Parse(string str)
        {
            dynamic func = Globals.Util.JSONToTable;
            return func(str);
        }

        /// <summary>
        /// Converts Table to JSON
        /// </summary>
        public static string Serialize(object obj, bool prettyPrint = false)
        {
            dynamic func = Globals.Util.TableToJSON;
            return func(obj, prettyPrint);
        }

        public static T TableToDictionary<T>(object tbl) where T : new()
        {
            var dict = new T();
            /*
            [[
                for key, value in pairs(tbl) do
                    dict:Add(key, value)
                end
            ]]
            */
            return dict;
        }

        public static T TableToList<T>(object tbl) where T : new()
        {
            var list = new T();
            /*
            [[
                for key, value in pairs(tbl) do
                    tbl[key] = value
                end
            ]]
            */
            return list;
        }
    }
}