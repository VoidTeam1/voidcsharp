using System;
using System.Linq;
using VoidSharp;

namespace VoidSharp.Handlers
{
    public static class HookHandler
    {
        /// <summary>
        /// Initializes hooks for usage in passed instance.
        /// </summary>
        /// <param name="instance">The instance of the class.</param>
        public static void InitializeHooks(object instance)
        {
            var methods = HookAttribute.GetAllHookAttributes(instance.GetType());
            foreach (var method in methods)
            {
                HookAttribute hookAttribute =
                    (HookAttribute) method.GetCustomAttributes(typeof(HookAttribute), true)[0];

                string hookName = hookAttribute.HookName;
                string hookId = hookAttribute.HookId;

                Hook.Add(hookName, hookId ?? hookName + ".Listener." + method.Name,
                    objects =>
                    {
                        method.Invoke(instance, objects);
                    });
            }
        }
    }
}