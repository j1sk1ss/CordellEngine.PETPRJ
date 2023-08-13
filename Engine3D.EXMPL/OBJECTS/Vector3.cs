using Engine3D.EXMPL.SCRIPTS;

namespace Engine3D.EXMPL.OBJECTS;

public class Vector3 {
    public Vector3(double position) {
        X = position;
        Y = position;
        Z = position;

        Length = Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public Vector3(double x, Vector2 vector) {
        X = x;
        Y = vector.X;
        Z = vector.Y;
        
        Length = Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    
    public Vector3(double x, double y, double z) {
        X = x;
        Y = y;
        Z = z;
        
        Length = Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    private double Length { get; set; }


    public static Vector3 operator +(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X + secondVector.X, firstVector.Y + secondVector.Y, firstVector.Z + secondVector.Z);
    
    public static Vector3 operator -(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X - secondVector.X, firstVector.Y - secondVector.Y, firstVector.Z - secondVector.Z);
    
    public static Vector3 operator /(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X / secondVector.X, firstVector.Y / secondVector.Y, firstVector.Z / secondVector.Z);

    public static Vector3 operator *(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X * secondVector.X, firstVector.Y * secondVector.Y, firstVector.Z * secondVector.Z);

    public static Vector3 operator -(Vector3 vector) => new(-vector.X, -vector.Y, -vector.Z);


    public Vector3 Normalize() => this / new Vector3(Length);

    public double Dot(Vector3 secondVector) => X * secondVector.X + Y * secondVector.Y + Z * secondVector.Z;

    public Vector3 Abs() => new(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));

    public Vector3 Sign() => new(Math.Sign(X), Math.Sign(Y), Math.Sign(Z));

    public Vector3 Step(Vector3 edge) =>
        new(MathScripts.Step(edge.X, X), MathScripts.Step(edge.Y, Y), MathScripts.Step(edge.Z, Z));


    public Vector3 Reflect(Vector3 n) => this - n * (new Vector3(2) * new Vector3(n.Dot(this)));

    public Vector3 RotateX(double angle) => new(X,
        Z * Math.Cos(angle) - Y * Math.Sin(angle),
        Z * Math.Sin(angle) + Y * Math.Cos(angle));

    public Vector3 RotateY(double angle) => new(
        X * Math.Cos(angle) - Z * Math.Sin(angle), Y,
        X * Math.Sin(angle) + Z * Math.Cos(angle));
    
    public Vector3 RotateZ(double angle) => new(
        X * Math.Cos(angle) - Y * Math.Sin(angle), 
        X * Math.Sin(angle) + Y * Math.Cos(angle), Z);
}