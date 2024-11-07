namespace Editor.Core;

public struct Vector4f
{
    private float _x, _y, _z, _w;
    public float X
    {
        get => _x;
        set => _x = value;
    }
    
    public float Y
    {
        get => _y;
        set => _y = value;
    }
    
    public float Z
    {
        get => _z;
        set => _z = value;
    }
    
    public float W
    {
        get => _w;
        set => _w = value;
    }

    public Vector4f(float scalar)
    {
        X = scalar;
        Y = scalar;
        Z = scalar;
        W = scalar;
    }

    public Vector4f(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public Vector4f(Vector4f vector)
    {
        X = vector.X;
        Y = vector.Y;
        Z = vector.Z;
        W = vector.W;
    }

    public static Vector4f Zero => new Vector4f(0.0f);

    public Vector4f(Vector2f vector, float z, float w)
    {
        X = vector.X;
        Y = vector.Y;
        Z = z;
        W = w;
    }

    public Vector4f(Vector3f vector, float w)
    {
        X = vector.X;
        Y = vector.Y;
        Z = vector.Z;
        W = w;
    }

    public static Vector4f operator +(Vector4f vectorA, Vector4f vectorB)
    {
        return new Vector4f(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y, vectorA.Z + vectorB.Z, vectorA.W + vectorB.W);
    }

    public static Vector4f operator -(Vector4f vectorA, Vector4f vectorB)
    {
        return new Vector4f(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y, vectorA.Z - vectorB.Z, vectorA.W - vectorB.W);
    }

    public static Vector4f operator *(Vector4f vectorA, float scalar)
    {
        return new Vector4f(vectorA.X * scalar, vectorA.Y * scalar, vectorA.Z * scalar, vectorA.W * scalar);
    }

    public static Vector4f operator /(Vector4f vectorA, float scalar)
    {
        return new Vector4f(vectorA.X / scalar, vectorA.Y / scalar, vectorA.Z / scalar, vectorA.W / scalar);
    }
}