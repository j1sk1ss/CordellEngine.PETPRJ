﻿using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY;

public abstract class Object {
    /// <summary>
    /// Object
    /// </summary>
    /// <param name="position"> Position of object </param>
    /// <param name="size"> Size of object </param>
    /// <param name="material"> Material of object </param>
    /// <param name="name"> Name of object </param>
    protected Object(Vector3 position, Vector3 size, Material material, string name) {
        Name     = name;
        Position = position;
        Size     = size;
        Material = material;
    }

    protected string Name { get; init; }
    protected Vector3 Position { get; set; }
    protected Vector3 Size { get; set; }
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
    public abstract (Vector2 intersectionCoordinate, Material intersectionMaterial) Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal);

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
    public virtual void Move(Vector3 move) => Position += move;

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
    /// Set size of object
    /// </summary>
    /// <param name="size"> New size </param>
    public void SetSize(Vector3 size) => Size = size;

    /// <summary>
    /// Get collisions between objects
    /// </summary>
    /// <param name="objects"> List of objects on scene </param>
    /// <param name="minDistance"> Min distance between objects </param>
    /// <returns> Collided objects </returns>
    public List<Object> CollisionObjects(IEnumerable<Object> objects, double minDistance) =>
        objects.Where(currentObject => currentObject != this).Where(currentObject => 
            Collision(this, currentObject, minDistance)).ToList();

    /// <summary>
    /// Get distance with another object
    /// </summary>
    /// <param name="obj"> Another object </param>
    /// <returns> Distance between two objects </returns>
    public double Distance(Object obj) {
        var firstCenter = new Vector3(Position.X + Size.X / 2, Position.Y + Size.Y / 2, Position.Z + Size.Z / 2);
        var secondCenter = new Vector3(obj.GetPosition().X + obj.GetSize().X / 2, 
            obj.GetPosition().Y + obj.GetSize().Y / 2, obj.GetPosition().Z + obj.GetSize().Z / 2);
    
       return (float)Math.Sqrt(Math.Pow(firstCenter.X - secondCenter.X, 2) + Math.Pow(firstCenter.Y - secondCenter.Y, 2) 
            + Math.Pow(firstCenter.Z - secondCenter.Z, 2));
    }

    /// <summary>
    /// Get collision status of objects
    /// </summary>
    /// <param name="firstObject"> First object </param>
    /// <param name="secondObject"> Second object </param>
    /// <param name="minDistance"> Min distance between objects </param>
    /// <returns> Collision object </returns>
    private static bool Collision(Object firstObject, Object secondObject, double minDistance) =>
        firstObject.Distance(secondObject) <= minDistance;

    /// <summary>
    /// Rotate object
    /// </summary>
    /// <param name="angle"> Angle of Rotation </param>
    public abstract void Rotate(Vector3 angle);
}