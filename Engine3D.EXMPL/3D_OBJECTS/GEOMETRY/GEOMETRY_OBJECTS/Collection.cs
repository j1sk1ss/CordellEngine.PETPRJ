using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class Collection : Object {
    /// <summary>
    /// Collection object
    /// </summary>
    /// <param name="position"> Collection coordinates </param>
    /// <param name="size"> Collection size </param>
    /// <param name="objects"> Objects in collection </param>
    /// <param name="material"> Material </param>
    /// <param name="name"> Collection name </param>
    public Collection(Vector3 position, Vector3 size, List<Object> objects, Material material = null!, string name = "collection1") 
        : base(position, size, material, name) {
        Position = position;
        Size     = size;
        Name     = name;
        Material = material == null! ? Material.DefaultMaterial : material;

        Objects = objects;
    }

    private List<Object> Objects { get; }

    public override Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        var vector = new Vector2(0);
        var normal = new Vector3(0);

        foreach (var obj in Objects) {
            vector += obj.Intersection(rayOrigin + Position, rayDirection, out var currentNormal);
            normal += currentNormal;
        }
        
        intersectionNormal = normal;
        return vector;
    }
    
    /// <summary>
    /// Get object via name
    /// </summary>
    /// <param name="name"> Object name </param>
    /// <returns> Object </returns>
    public Object GetObject(string name) =>
        Objects.FirstOrDefault(iObject => iObject.GetName() == name) ?? new NullObject(new Vector3(0), new Vector3(0));
    
    public override void Rotate(Vector3 angle) {
        foreach (var obj in Objects)
            obj.Rotate(angle);
    }
}