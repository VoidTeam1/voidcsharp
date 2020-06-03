using System;
using System.Numerics;

/// <summary>
/// @CSharpLua.Ignore
/// </summary>
public class Entity {
    public int GetBoneCount() {
        throw new NotImplementedException();
    }
    
    public Vector GetPos() {
        throw new NotImplementedException();
    }

    public Vector SetPos(Vector pos) {
        throw new NotImplementedException();
    }
}

/// <summary>
/// @CSharpLua.Ignore
/// </summary>
public static class Ents {
    /// <summary>
	/// @CSharpLua.Template = "ents.GetAll()"
	/// </summary>
    public extern static Entity[] GetAll(); 
}