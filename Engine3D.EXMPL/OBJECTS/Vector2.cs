namespace Engine3D.EXMPL.OBJECTS;

public class Vector2 {
    public Vector2(double position) {
        X = position;
        Y = position;
    }

    public Vector2(double x, double y) {
        X = x;
        Y = y;
    }

    public double X { get; set; }
    public double Y { get; set; }

    public static Vector2 operator +(Vector2 firstVector, Vector2 secondVector) =>
        new (firstVector.X + secondVector.X, firstVector.Y + secondVector.Y);
    
    public static Vector2 operator -(Vector2 firstVector, Vector2 secondVector) =>
        new (firstVector.X - secondVector.X, firstVector.Y - secondVector.Y);

    public static Vector2 operator /(Vector2 firstVector, Vector2 secondVector) =>
        new (firstVector.X / secondVector.X, firstVector.Y / secondVector.Y);
    
    public static Vector2 operator *(Vector2 firstVector, Vector2 secondVector) =>
        new (firstVector.X * secondVector.X, firstVector.Y * secondVector.Y);
}