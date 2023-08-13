using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS;

public class Sphere : IObject {
    public Sphere(double radius) {
        Radius = radius;
        Position = new Vector3(0);
    }
    
    public Sphere(Vector3 position, double radius) {
        Position = position;
        Radius   = radius;
    }

    private double Radius { get; set; }
    private Vector3 Position { get; set; }

    public Vector2 Intersection(Vector3 cameraPosition, Vector3 cameraRay) {
        cameraPosition -= Position;
        
        var b = cameraPosition.Dot(cameraRay);
        var c = cameraPosition.Dot(cameraPosition) - Radius * Radius;
        var h = b * b - c;
        if (h < .0d) return new Vector2(-1.0d);

        h = Math.Sqrt(h);
        return new Vector2(-b - h, -b + h);
    }
    
    public Vector3 GetPosition() => Position;
    
    public Vector3 GetNormal(Vector3 cameraPosition, Vector3 cameraRay, double value) => 
        cameraPosition - Position + cameraRay * new Vector3(value);
}