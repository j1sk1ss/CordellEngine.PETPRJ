using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS;

public class Plane : IObject {
    public Plane(Vector3 size, double high) {
        Size = size;
        High = high;
    }
    
    private Vector3 Size { get; set; }
    private double High { get; set; }
    
    public Vector2 Intersection(Vector3 cameraPosition, Vector3 cameraRay) =>
        new (-(cameraPosition.Dot(Size) + High) / cameraRay.Dot(Size));
    
    public Vector3 GetPosition() => new (0);

    public Vector3 GetNormal(Vector3 cameraPosition, Vector3 cameraRay, double value) => new (0, 0, -1);
}