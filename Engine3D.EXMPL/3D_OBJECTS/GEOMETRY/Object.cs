using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY;

public abstract class Object {
    protected Object(Vector3 position, Vector3 size, Material material, string name) {
        Name     = name;
        Position = position;
        Size     = size;
        Material = material;
    }

    protected string Name { get; init; }
    protected Vector3 Position { get; set; }
    protected Vector3 Size { get; init; }
    protected Material Material { get; init; }

    /// <summary>
    /// Get name
    /// </summary>
    /// <returns> Name of object </returns>
    public string GetName() => Name;
    
    /// <summary>
    /// Get intersection with object by ray direction and ray origin
    /// </summary>
    /// <param name="rayOrigin"> Position of ray origin </param>
    /// <param name="rayDirection"> Ray direction </param>
    /// <param name="intersectionNormal"> Normal of intersection </param>
    /// <returns> Vector2 of intersection params </returns>
    public abstract Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal);

    /// <summary>
    /// Get position of object
    /// </summary>
    /// <returns> Position of object </returns>
    public Vector3 GetPosition() => Position;

    /// <summary>
    /// Set position of object
    /// </summary>
    /// <param name="position"> New position </param>
    public void SetPosition(Vector3 position) => Position = position;

    /// <summary>
    /// Move object
    /// </summary>
    /// <param name="move"> Move vector </param>
    public void Move(Vector3 move) => Position += move;

    /// <summary>
    /// Gets material
    /// </summary>
    /// <returns> Material of object </returns>
    public Material GetMaterial() => Material;
}