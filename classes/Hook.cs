using System;
using System.Collections;

/// <summary>
/// @CSharpLua.Ignore
/// </summary>
public static class Hook {

    public static void Add(string name, string id, Action<dynamic[]> hookCallback) {
        throw new NotImplementedException();
    }

    /// <summary>
    /// @CSharpLua.Template = "hook.Remove({0}, {1})"
    /// </summary>
    public static void Remove(string name, string id) {
        throw new NotImplementedException();
    }

    public static void Call(string name, dynamic[] args) {
        throw new NotImplementedException();
    }


    
}