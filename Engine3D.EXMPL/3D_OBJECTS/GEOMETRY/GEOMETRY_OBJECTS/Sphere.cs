using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class Sphere : Object {
    /// <summary>
    /// Sphere object
    /// </summary>
    /// <param name="position"> Sphere coordinates </param>
    /// <param name="radius"> Sphere radius </param>
    /// <param name="material"> Material </param>
    /// <param name="name"> Sphere name </param>
    public Sphere(Vector3 position, Vector3 radius, Material material = null!, string name = "sphere1") : base(position, radius, material, name) {
        Position = position;
        Size     = radius;
        Name     = name;
        Material = material == null! ? Material.DefaultMaterial : material;
    }

    public override Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        rayOrigin -= Position;
        
        var rayAngle = rayOrigin.Dot(rayDirection);
        var c = rayOrigin.Dot(rayOrigin) - Size.X * Size.X;
        var h = rayAngle * rayAngle - c;
        if (h < .0d) {
            intersectionNormal = new Vector3(0);
            return new Vector2(-1.0d);
        }

        h = Math.Sqrt(h);
        var intersection = new Vector2(-rayAngle - h, -rayAngle + h);
        intersectionNormal = rayOrigin - Position + rayDirection * new Vector3(intersection.X);
        
        return intersection;
    }
}