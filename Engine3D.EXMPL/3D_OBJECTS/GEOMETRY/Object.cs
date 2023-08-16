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

    /// <summary>
    /// Get object size
    /// </summary>
    /// <returns> Object size </returns>
    public Vector3 GetSize() => Size;

    /// <summary>
    /// Get collisions between objects
    /// </summary>
    /// <param name="objects"> List of objects on scene </param>
    /// <returns></returns>
    public List<Object> CollisionObjects(IEnumerable<Object> objects, double minDistance) =>
        objects.Where(currentObject => currentObject != this).Where(currentObject => 
            Collision(this, currentObject, minDistance)).ToList();
    
    /// <summary>
    /// Get collision status of objects
    /// </summary>
    /// <param name="firstObject"> First object </param>
    /// <param name="secondObject"> Second object </param>
    /// <returns></returns>
    private static bool Collision(Object firstObject, Object secondObject, double minDistance) {
        var firstCenter = new Vector3(firstObject.GetPosition().X + firstObject.GetSize().X / 2, 
            firstObject.GetPosition().Y + firstObject.GetSize().Y / 2, firstObject.GetPosition().Z + firstObject.GetSize().Z / 2);
        var secondCenter = new Vector3(secondObject.GetPosition().X + secondObject.GetSize().X / 2, 
            secondObject.GetPosition().Y + secondObject.GetSize().Y / 2, secondObject.GetPosition().Z + secondObject.GetSize().Z / 2);
    
        var distance = (float)Math.Sqrt(Math.Pow(firstCenter.X - secondCenter.X, 2) + Math.Pow(firstCenter.Y - secondCenter.Y, 2) 
            + Math.Pow(firstCenter.Z - secondCenter.Z, 2));
        
        return distance <= minDistance;
    }
}