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

    
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
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
        new(MathScripts.Step(X, edge.X), MathScripts.Step(Y, edge.Y), MathScripts.Step(Z, edge.Z));
    
    public Vector3 Reflect(Vector3 n) => this - n * (new Vector3(2) * new Vector3(n.Dot(this)));

    public Vector3 Cross(Vector3 other) {
        var newX = Y * other.Z - Z * other.Y;
        var newY = Z * other.X - X * other.Z;
        var newZ = X * other.Y - Y * other.X;

        return new Vector3(newX, newY, newZ);
    }
    
    public Vector3 RotateX(double angle) {
        var tempVector = this;
        tempVector.Z = Z * Math.Cos(angle) - Y * Math.Sin(angle);
        tempVector.Y = Z * Math.Sin(angle) + Y * Math.Cos(angle);

        return tempVector;
    }

    public Vector3 RotateY(double angle) {
        var tempVector = this;
        tempVector.X = X * Math.Cos(angle) - Z * Math.Sin(angle);
        tempVector.Z = X * Math.Sin(angle) + Z * Math.Cos(angle);

        return tempVector;
    }
    
    public Vector3 RotateZ(double angle) {
        var tempVector = this;
        tempVector.X = X * Math.Cos(angle) - Y * Math.Sin(angle);
        tempVector.Y = X * Math.Sin(angle) + Y * Math.Cos(angle);

        return tempVector;
    }

    public Vector3 Rotate(Vector3 angles) {
        RotateX(angles.X);
        RotateY(angles.Y);
        RotateZ(angles.Z);

        return this;
    }
    
    public static Vector3 Max(Vector3 firstVector, Vector3 secondVector) =>
        new Vector3(Math.Max(firstVector.X, secondVector.X), Math.Max(firstVector.Y, secondVector.Y), Math.Max(firstVector.Z, secondVector.Z));
    
    public static Vector3 Min(Vector3 firstVector, Vector3 secondVector) =>
        new Vector3(Math.Min(firstVector.X, secondVector.X), Math.Min(firstVector.Y, secondVector.Y), Math.Min(firstVector.Z, secondVector.Z));
}