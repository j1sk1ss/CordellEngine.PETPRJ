using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class NullObject : Object{
    /// <summary>
    /// Null object
    /// </summary>
    /// <param name="position"> Null object coordinates </param>
    /// <param name="size"> Null object size </param>
    /// <param name="material"> Null object material </param>
    /// <param name="name"> Null object name </param>
    public NullObject(Vector3 position, Vector3 size, Material material = null!, string name = "NULL") 
        : base(position, size, material, name) { }

    public override Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        intersectionNormal = new Vector3(0);
        return new Vector2(0);
    }
    
    public override void Rotate(Vector3 angle) { }
}