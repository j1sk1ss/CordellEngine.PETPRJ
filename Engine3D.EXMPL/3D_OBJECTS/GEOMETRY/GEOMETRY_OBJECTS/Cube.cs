using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class Cube : Object {
    /// <summary>
    /// Cube object
    /// </summary>
    /// <param name="position"> Cube coordinates </param>
    /// <param name="size"> Cube size </param>
    /// <param name="material"> Material </param>
    /// <param name="name"> Cube name </param>
    public Cube(Vector3 position, Vector3 size, Material material = null!, string name = "cube1") : base(position, size, material, name) {
        Position = position;
        Size     = size;
        Name     = name;
        Material = material == null! ? Material.DefaultMaterial : material;
    }

    public override Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        var origin = rayOrigin - Position;

        var minVector = Position;
        var maxVector = new Vector3(Position.X + Size.X, Position.Y + Size.Y, Position.Z + Size.Z);
        if (Position.Z + Size.Z < Position.Z) {
            minVector = new Vector3(Position.X + Size.X, Position.Y + Size.Y, Position.Z + Size.Z);
            maxVector = Position;
        }
        
        var tMin = (minVector - origin) / rayDirection;
        var tMax = (maxVector - origin) / rayDirection;
        
        var tNear = Vector3.Min(tMin, tMax);
        var tFar = Vector3.Max(tMin, tMax);
        
        var tNearMax = Math.Max(Math.Max(tNear.X, tNear.Y), tNear.Z);
        var tFarMin = Math.Min(Math.Min(tFar.X, tFar.Y), tFar.Z);
        if (tNearMax > tFarMin || tFarMin < .0d) {
            intersectionNormal = new Vector3(0);
            return new Vector2(0d);
        }

        var yzxOrder = new Vector3(tNear.Y, tNear.Z, tNear.X);
        var zxyOrder = new Vector3(tNear.Z, tNear.X, tNear.Y);

        intersectionNormal = -rayDirection.Sign() * yzxOrder.Step(tNear) * zxyOrder.Step(tNear);
        return new Vector2(tNearMax, tFarMin);
    }

    public override void Rotate(Vector3 angle) {
        Position.Rotate(angle);
        Size.Rotate(angle);
    }
}