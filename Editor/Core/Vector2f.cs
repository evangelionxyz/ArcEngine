namespace Editor.Core;

public struct Vector2f
{
    private float _x, _y;
    
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

    public Vector2f(float scalar)
    {
        X = scalar;
        Y = scalar;
    }

    public Vector2f(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Vector2f(Vector3f vector)
    {
        X = vector.X;
        Y = vector.Y;
    }

    public Vector2f(Vector4f vector)
    {
        X = vector.X;
        Y = vector.Y;
    }

    public static Vector2f Zero => new Vector2f(0.0f);

    public static Vector2f operator *(Vector2f vector, float scalar)
    {
        return new Vector2f(vector.X * scalar, vector.Y * scalar);
    }

    public static Vector2f operator /(Vector2f vector, float scalar)
    {
        return new Vector2f(vector.X / scalar, vector.Y / scalar);
    }

    public static Vector2f operator +(Vector2f vectorA, Vector2f vectorB)
    {
        return new Vector2f(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y);
    }

    public static Vector2f operator -(Vector2f vectorA, Vector2f vectorB)
    {
        return new Vector2f(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y);
    }
}