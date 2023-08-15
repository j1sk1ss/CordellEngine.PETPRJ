using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY;

public interface IObject {
    /// <summary>
    /// Get name
    /// </summary>
    /// <returns> Name of object </returns>
    public string GetName();
    
    /// <summary>
    /// Get intersection with object by ray direction and ray origin
    /// </summary>
    /// <param name="rayOrigin"> Position of ray origin </param>
    /// <param name="rayDirection"> Ray direction </param>
    /// <param name="intersectionNormal"> Normal of intersection </param>
    /// <returns> Vector2 of intersection params </returns>
    public Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal);

    /// <summary>
    /// Get position of object
    /// </summary>
    /// <returns> Position of object </returns>
    public Vector3 GetPosition();

    /// <summary>
    /// Set position of object
    /// </summary>
    /// <param name="position"> New position </param>
    public void SetPosition(Vector3 position);

    /// <summary>
    /// Gets material
    /// </summary>
    /// <returns> Material of object </returns>
    public Material GetMaterial();
}