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

    public Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        rayOrigin -= Position;
        
        var b = rayOrigin.Dot(rayDirection);
        var c = rayOrigin.Dot(rayOrigin) - Radius * Radius;
        var h = b * b - c;
        if (h < .0d) {
            intersectionNormal = new Vector3(0);
            return new Vector2(-1.0d);
        }

        h = Math.Sqrt(h);
        var intersection = new Vector2(-b - h, -b + h);
        intersectionNormal = rayOrigin - Position + rayDirection * new Vector3(intersection.X);
        
        return intersection;
    }
    
    public Vector3 GetPosition() => Position;
    
    public void SetPosition(Vector3 position) => Position = position;
}