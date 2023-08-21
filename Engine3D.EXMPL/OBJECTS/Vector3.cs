using Engine3D.EXMPL.SCRIPTS;

namespace Engine3D.EXMPL.OBJECTS;

public class Vector3 {
    /// <summary>
    /// Vector3 object
    /// </summary>
    /// <param name="position"> Position in space </param>
    public Vector3(double position) {
        X = position;
        Y = position;
        Z = position;

        Length = Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    /// <summary>
    /// Vector3 object
    /// </summary>
    /// <param name="x"> X coordinate </param>
    /// <param name="vector"> Vector2 coordinates </param>
    public Vector3(double x, Vector2 vector) {
        X = x;
        Y = vector.X;
        Z = vector.Y;
        
        Length = Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    
    /// <summary>
    /// Vector3 object
    /// </summary>
    /// <param name="x"> X coordinate </param>
    /// <param name="y"> Y coordinate </param>
    /// <param name="z"> Z coordinate </param>
    public Vector3(double x, double y, double z) {
        X = x;
        Y = y;
        Z = z;
        
        Length = Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    
    public double X { get; set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public double Length { get; set; }
    
    public static Vector3 operator +(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X + secondVector.X, firstVector.Y + secondVector.Y, firstVector.Z + secondVector.Z);
    
    public static Vector3 operator -(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X - secondVector.X, firstVector.Y - secondVector.Y, firstVector.Z - secondVector.Z);
    
    public static Vector3 operator /(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X / secondVector.X, firstVector.Y / secondVector.Y, firstVector.Z / secondVector.Z);

    public static Vector3 operator *(Vector3 firstVector, Vector3 secondVector) =>
        new (firstVector.X * secondVector.X, firstVector.Y * secondVector.Y, firstVector.Z * secondVector.Z);

    public static Vector3 operator -(Vector3 vector) => new(-vector.X, -vector.Y, -vector.Z);
    
    /// <summary>
    /// Normalize vector3
    /// </summary>
    /// <returns> Normalized vector3 </returns>
    public Vector3 Normalize() => this / new Vector3(Length);

    /// <summary>
    /// Vector3 multiplication
    /// </summary>
    /// <param name="secondVector"> Second vector in multiplication </param>
    /// <returns> Result of multiplication </returns>
    public double Dot(Vector3 secondVector) => X * secondVector.X + Y * secondVector.Y + Z * secondVector.Z;

    /// <summary>
    /// Vector3 Abs
    /// </summary>
    /// <returns> Abs of vector3 </returns>
    public Vector3 Abs() => new(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));

    /// <summary>
    /// Vector3 sign
    /// </summary>
    /// <returns> Sign of vector3 </returns>
    public Vector3 Sign() => new(Math.Sign(X), Math.Sign(Y), Math.Sign(Z));

    /// <summary>
    /// Vector3 step
    /// </summary>
    /// <param name="edge"> Edge </param>
    /// <returns> Step of vector3 with edge </returns>
    public Vector3 Step(Vector3 edge) =>
        new(MathScripts.Step(X, edge.X), MathScripts.Step(Y, edge.Y), MathScripts.Step(Z, edge.Z));
    
    /// <summary>
    /// Vector3 reflection
    /// </summary>
    /// <param name="normal"> Normal of reflection </param>
    /// <returns> Reflected vector3 </returns>
    public Vector3 Reflect(Vector3 normal) => this - normal * (new Vector3(2) * new Vector3(normal.Dot(this)));

    /// <summary>
    /// Rotate vector3 by X axis
    /// </summary>
    /// <param name="angle"> Angle </param>
    /// <returns> Rotated vector3 </returns>
    public Vector3 RotateX(double angle) {
        var tempVector = this;
        tempVector.Z = Z * Math.Cos(angle) - Y * Math.Sin(angle);
        tempVector.Y = Z * Math.Sin(angle) + Y * Math.Cos(angle);

        return tempVector;
    }

    /// <summary>
    /// Rotate vector3 by Y axis
    /// </summary>
    /// <param name="angle"> Angle </param>
    /// <returns> Rotated vector3 </returns>
    public Vector3 RotateY(double angle) {
        var tempVector = this;
        tempVector.X = X * Math.Cos(angle) - Z * Math.Sin(angle);
        tempVector.Z = X * Math.Sin(angle) + Z * Math.Cos(angle);

        return tempVector;
    }
    
    /// <summary>
    /// Rotate vector3 by Z axis
    /// </summary>
    /// <param name="angle"> Angle </param>
    /// <returns> Rotated vector3 </returns>
    public Vector3 RotateZ(double angle) {
        var tempVector = this;
        tempVector.X = X * Math.Cos(angle) - Y * Math.Sin(angle);
        tempVector.Y = X * Math.Sin(angle) + Y * Math.Cos(angle);

        return tempVector;
    }

    /// <summary>
    /// Rotate vector by all axis
    /// </summary>
    /// <param name="angles"> Angle represented lice vector3 </param>
    /// <returns> Rotated vector3 </returns>
    public Vector3 Rotate(Vector3 angles) {
        RotateX(angles.X);
        RotateY(angles.Y);
        RotateZ(angles.Z);

        return this;
    }
    
    /// <summary>
    /// Max of two vector3
    /// </summary>
    /// <param name="firstVector"> First vector3 </param>
    /// <param name="secondVector"> Second vector3 </param>
    /// <returns> New vector3 with max values in each parameter </returns>
    public static Vector3 Max(Vector3 firstVector, Vector3 secondVector) =>
        new(Math.Max(firstVector.X, secondVector.X), Math.Max(firstVector.Y, secondVector.Y), Math.Max(firstVector.Z, secondVector.Z));
    
    /// <summary>
    /// Min of two vector3
    /// </summary>
    /// <param name="firstVector"> First vector3 </param>
    /// <param name="secondVector"> Second vector3 </param>
    /// <returns> New vector3 with min values in each parameter </returns>
    public static Vector3 Min(Vector3 firstVector, Vector3 secondVector) =>
        new(Math.Min(firstVector.X, secondVector.X), Math.Min(firstVector.Y, secondVector.Y), Math.Min(firstVector.Z, secondVector.Z));
    
    /// <summary>
    /// Crossing with vector3
    /// </summary>
    /// <param name="b"> Another vector3 </param>
    /// <returns> Point of crosing </returns>
    public Vector3 Cross(Vector3 b) {
        var x = Y * b.Z - Z * b.Y;
        var y = Z * b.X - X * b.Z;
        var z = X * b.Y - Y * b.X;
        
        return new Vector3(x, y, z);
    }

    /// <summary>
    /// Get distance between two dots in space
    /// </summary>
    /// <param name="second"> Second position </param>
    /// <returns></returns>
    public double Distance(Vector3 second) => 
        Math.Sqrt(Math.Pow(second.X - X, 2) + Math.Pow(second.Y - Y, 2) + Math.Pow(second.Z - Z, 2));
    
}