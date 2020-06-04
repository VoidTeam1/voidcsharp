#pragma warning disable 0626

/// <summary>
/// @CSharpLua.Ignore
/// </summary>
public class Vector {
    public float x;
    public float y;
    public float z;

    public Vector(float _x, float _y, float _z) {
        x = _x;
        y = _y;
        z = _z;
    }

    public extern float Distance(Vector vec);
}
