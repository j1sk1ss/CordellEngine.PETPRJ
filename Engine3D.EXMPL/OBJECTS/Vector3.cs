using Engine3D.EXMPL.SCRIPTS;

namespace Engine3D.EXMPL.OBJECTS;

public class Vector3 {
    public Vector3(double position) {
        X = position;
        Y = position;
        Z = position;
    }

    public Vector3(double x, Vector2 vector) {
        X = x;
        Y = vector.X;
        Z = vector.Y;
    }
    
    public Vector3(double x, double y, double z) {
        X = x;
        Y = y;
        Z = z;
    }
    
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    
    public double Lenght => Math.Sqrt(X * X + Y * Y + Z * Z);


    public static Vector3 operator +(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X + secondVector.X, firstVector.Y + secondVector.Y, firstVector.Z + secondVector.Z);
    
    public static Vector3 operator -(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X - secondVector.X, firstVector.Y - secondVector.Y, firstVector.Z - secondVector.Z);
    
    public static Vector3 operator /(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X / secondVector.X, firstVector.Y / secondVector.Y, firstVector.Z / secondVector.Z);
    
    public static Vector3 operator /(Vector3 firstVector, double value) =>
        new (firstVector.X / value, firstVector.Y / value, firstVector.Z / value);
    
    public static Vector3 operator *(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X * secondVector.X, firstVector.Y * secondVector.Y, firstVector.Z * secondVector.Z);
    
    public static Vector3 operator *(Vector3 firstVector, double value) =>
        new (firstVector.X * value, firstVector.Y * value, firstVector.Z * value);

    public static Vector3 operator -(Vector3 vector) => new(-vector.X, -vector.Y, -vector.Z);


    public Vector3 Normalize() => this / Lenght;

    public double Dot(Vector3 secondVector) => X * secondVector.X + Y + secondVector.Y + Z + secondVector.Z;

    public Vector3 Abs() => new(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));

    public Vector3 Sign() => new(Math.Sign(X), Math.Sign(Y), Math.Sign(Z));

    public Vector3 Step(Vector3 edge) =>
        new(MathScripts.Step(edge.X, X), MathScripts.Step(edge.Y, Y), MathScripts.Step(edge.Z, Z));


    public static Vector3 Reflect(Vector3 rd, Vector3 n) => rd - n * (2 * n.Dot(rd));

}