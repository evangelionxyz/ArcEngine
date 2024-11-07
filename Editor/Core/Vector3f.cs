using System;

namespace Editor.Core;

public struct Vector3f
{
    private float _x, _y, _z;
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

    public Vector3f(float scalar)
    {
        X = scalar;
        Y = scalar;
        Z = scalar;
    }

    public Vector3f(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3f(Vector3f vector)
    {
        X = vector.X;
        Y = vector.Y;
        Z = vector.Z;
    }

    public Vector3f(Vector4f vector)
    {
        X = vector.X;
        Y = vector.Y;
        Z = vector.Z;
    }

    public Vector3f(Vector2f vector, float z)
    {
        X = vector.X;
        Y = vector.Y;
        Z = z;
    }

    public Vector2f XY
    {
        get => new Vector2f(X, Y);
        set
        {
            X = value.X;
            Y = value.Y;
        }
    }

    public static Vector3f Zero => new Vector3f(0.0f);

    public Vector3f Normalized()
    {
        float length = Length();
        if (length > 0.0f)
        {
            return new Vector3f(X / length, Y / length, Z / length);
        }

        return Zero;
    }

    public float Length()
    {
        return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public static Vector3f operator *(Vector3f a, Vector3f b)
    {
        return new Vector3f(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    }

    public static Vector3f operator *(Vector3f vector, float scalar)
    {
        return new Vector3f(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
    }

    public static Vector3f operator *(float scalar, Vector3f vector)
    {
        return new Vector3f(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
    }

    public static Vector3f operator /(Vector3f a, Vector3f b)
    {
        return new Vector3f(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
    }

    public static Vector3f operator /(Vector3f vector, float scalar)
    {
        return new Vector3f(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
    }

    public static Vector3f operator /(float scalar, Vector3f vector)
    {
        return new Vector3f(vector.X / scalar, vector.Y / scalar, vector.Z / scalar);
    }

    public static Vector3f operator +(Vector3f vectorA, Vector3f vectorB)
    {
        return new Vector3f(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y, vectorA.Z + vectorB.Z);
    }

    public static Vector3f operator -(Vector3f vectorA)
    {
        return new Vector3f(-vectorA.X, -vectorA.Y, -vectorA.Z);
    }

    public static Vector3f operator -(Vector3f vectorA, Vector3f vectorB)
    {
        return new Vector3f(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y, vectorA.Z - vectorB.Z);
    }
}