using System;

namespace VoidSharp {

    public static class Hook
    {
        /// <summary>
        /// Add a hook to be called upon the given event occurring.
        /// </summary>
        public static void Add(string name, string id, Action<object[]> hookCallback)
        {
            dynamic func = Globals.Hook.Add;
            func(name, id, hookCallback);
        }

        /// <summary>
        /// Removes the hook with the supplied identifier from the given event.
        /// </summary>
        public static void Remove(string name, string id)
        {
            dynamic func = Globals.Hook.Remove;
            func(name, id);
        }

        /// <summary>
        /// Calls hooks associated with the given event.
        /// </summary>
        public static void Run(string name, object[] args)
        {
            dynamic func = Globals.Hook.Run;
            func(name, args);
        }

        /// <summary>
        /// Returns a list of all the hooks registered with hook.Add.
        /// </summary>
        /// <returns></returns>
        public static dynamic GetTable()
        {
            return Globals.Hook.GetTable();
        }

    }
}