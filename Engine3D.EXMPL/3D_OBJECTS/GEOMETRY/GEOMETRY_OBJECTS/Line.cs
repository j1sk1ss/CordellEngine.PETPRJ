using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class Line : Object {
    public Line(Vector3 startPoint, Vector3 endPoint, double thickness = .1, Material material = null!, string name = "line1") : base(startPoint, endPoint, material, name) {
        Position = startPoint;
        Size     = endPoint;
        Name     = name;
        Material = material == null! ? Material.DefaultMaterial : material;

        Thickness = thickness;
    }
    
    private double Thickness { get; set; }
    
    public override Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        var segmentDirection = Size - Position;
        var crossRaySegment = rayDirection.Cross(segmentDirection);
        
        if (crossRaySegment.Length < double.Epsilon) {
            intersectionNormal = new Vector3(0);
            return new Vector2(0); 
        }

        var diffStartRay = rayOrigin - Position;
        var t = diffStartRay.Dot(crossRaySegment) / Math.Pow(crossRaySegment.Length, 2);
        var u = diffStartRay.Cross(rayDirection).Dot(crossRaySegment) / Math.Pow(crossRaySegment.Length, 2);

        if (t >= 0f && t <= Thickness && u is >= 0f and <= 1f) {
            intersectionNormal = new Vector3(1); 
            return new Vector2(1); 
        }

        intersectionNormal = new Vector3(0);
        return new Vector2(0);
    }
}