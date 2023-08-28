using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class Polygon : Object {
    /// <summary>
    /// Polygon object
    /// </summary>
    /// <param name="points"> Array of points of polygon </param>
    /// <param name="material"> Material of polygon </param>
    /// <param name="name"> Name of polygon </param>
    public Polygon(Vector3[] points, Material material = null!, string name = "polygon1") 
        : base(points[0], points[2], material, name) {
        Position = points[0];
        Size     = points[2];
        Name     = name;
        Material = material == null! ? Material.DefaultMaterial : material;

        Points = points;
    }

    private Vector3[] Points { get; }
    
    public override (Vector2, Material) Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        var e1 = Points[1] - Points[0];
        var e2 = Points[2] - Points[0];

        var h = rayDirection.Cross(e2);
        var a = e1.Dot(h);

        if (a is > -double.Epsilon and < double.Epsilon) {
            intersectionNormal = new Vector3(0);
            return (new Vector2(0), Material); 
        }

        var f = 1.0f / a;
        var s = rayOrigin - Points[0];
        var u = f * s.Dot(h);

        if (u is < 0.0f or > 1.0f) {
            intersectionNormal = new Vector3(0);
            return (new Vector2(0), Material); 
        }

        var q = s.Cross(e1);
        var v = f * rayDirection.Dot(q);

        if (v < 0.0f || u + v > 1.0f) {
            intersectionNormal = new Vector3(0);
            return (new Vector2(0), Material); 
        }

        var t = f * e2.Dot(q);
        if (t > float.Epsilon) {
            intersectionNormal = e1.Cross(e2).Normalize();
            return (new Vector2(t), Material); 
        }
        
        intersectionNormal = new Vector3(0);
        return (new Vector2(0), Material); 
    }
    
    public override void Rotate(Vector3 angle) {
        for (var i = 0; i < Points.Length; i++)
            Points[i] = Points[i].Rotate(angle);
    }

    public override void Move(Vector3 move) {
        for (var i = 0; i < Points.Length; i++) 
            Points[i] += move;
    }
}