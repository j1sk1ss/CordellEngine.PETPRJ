using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class Plane : Object {
    /// <summary>
    /// Plane object
    /// </summary>
    /// <param name="position"> Plane size </param>
    /// <param name="high"> Plane high </param>
    /// <param name="material"> Material </param>
    /// <param name="name"> Plane name </param>
    public Plane(Vector3 position, Vector3 high, Material material = null!, string name = "plane1") : base(position, high, material, name) {
        Position = position;
        Size     = high;
        Name     = name;
        Material = material == null! ? Material.DefaultMaterial : material;
    }
    
    public override Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        intersectionNormal = new Vector3(0, 0, -1);
        return new Vector2(-(rayOrigin.Dot(Position) + Size.X) / rayDirection.Dot(Position));
    }
}