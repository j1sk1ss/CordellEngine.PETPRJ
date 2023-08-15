using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class Sphere : IObject {
    /// <summary>
    /// Sphere object
    /// </summary>
    /// <param name="position"> Sphere coordinates </param>
    /// <param name="radius"> Sphere radius </param>
    /// <param name="material"> Material </param>
    /// <param name="name"> Sphere name </param>
    public Sphere(Vector3 position, double radius, Material material = null!, string name = "sphere1") {
        Position     = position;
        Radius       = radius;
        Name         = name;
        Material     = material == null! ? Material.DefaultMaterial : material;
    }
    
    private string Name { get; set; }
    private double Radius { get; set; }
    private Vector3 Position { get; set; }
    private Material Material { get; set; }

    public string GetName() => Name;
    
    public Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        rayOrigin -= Position;
        
        var b = rayOrigin.Dot(rayDirection);
        var c = rayOrigin.Dot(rayOrigin) - Radius * Radius;
        var h = b * b - c;
        if (h < .0d) {
            intersectionNormal = new Vector3(0);
            return new Vector2(-1.0d);
        }

        h = Math.Sqrt(h);
        var intersection = new Vector2(-b - h, -b + h);
        intersectionNormal = rayOrigin - Position + rayDirection * new Vector3(intersection.X);
        
        return intersection;
    }
    
    public Vector3 GetPosition() => Position;
    
    public void SetPosition(Vector3 position) => Position = position;
    
    public Material GetMaterial() => Material;
}