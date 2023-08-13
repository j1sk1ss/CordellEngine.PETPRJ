using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS;

public class Plane : IObject {
    public Plane(Vector3 size, double high) {
        Size = size;
        High = high;
    }
    
    private Vector3 Size { get; set; }
    private double High { get; set; }

    public Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        intersectionNormal = new Vector3(0, 0, -1);
        return new Vector2(-(rayOrigin.Dot(Size) + High) / rayDirection.Dot(Size));
    }
    
    public Vector3 GetPosition() => Size;
    
    public void SetPosition(Vector3 position) => Size = position;
}