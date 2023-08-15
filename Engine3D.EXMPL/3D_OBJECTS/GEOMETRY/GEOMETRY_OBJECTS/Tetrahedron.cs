using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;

public class Tetrahedron : IObject {
    public Tetrahedron(Vector3 position, Material material = null!, string name = "tetrahedron1") {
        Position = position;
        Name     = name;
        Material = material == null! ? Material.DefaultMaterial : material;
        
        Vertices = new Vector3[5];
        for (var i = 0; i < Vertices.Length; i++) 
            Vertices[i] = position;
    }

    public Tetrahedron(Vector3 position, Vector3[] vertices, Material material = null!, string name = "tetrahedron1") {
        Position = position;
        Vertices = vertices;
        Name     = name;
        Material = material == null! ? Material.DefaultMaterial : material;
    }
    
    private string Name { get; set; }
    private Vector3 Position { get; set; }
    private Vector3[] Vertices { get; set; }
    private Material Material { get; set; }
    
    public string GetName() => Name;
    
    public Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        rayOrigin -= Position;

        var edge1 = Vertices[1] - Vertices[0];
        var edge2 = Vertices[2] - Vertices[0];
        var edge3 = Vertices[3] - Vertices[0];

        var pVec = rayDirection.Cross(edge3);
        var det = edge1.Dot(pVec);

        if (det is > -float.Epsilon and < float.Epsilon) {
            intersectionNormal = new Vector3(0);
            return new Vector2(-1f);
        }

        var invDet = 1.0f / det;
        var tVec = rayOrigin - Vertices[0];

        var u = tVec.Dot(pVec) * invDet;

        if (u is < 0.0f or > 1.0f) {
            intersectionNormal = new Vector3(0);
            return new Vector2(-1f);
        }

        var qVec = tVec.Cross(edge1);
        var v = rayDirection.Dot(qVec) * invDet;

        if (v < 0.0f || u + v > 1.0f) {
            intersectionNormal = new Vector3(0);
            return new Vector2(-1f);
        }

        var t = edge2.Dot(qVec) * invDet;

        if (t > float.Epsilon) {
            intersectionNormal = edge1.Cross(edge2).Normalize();
            return new Vector2(0f, t);
        }

        intersectionNormal = new Vector3(0);
        return new Vector2(-1f);
    }

    public Vector3 GetPosition() => Position;

    public void SetPosition(Vector3 position) => Position = position;
    
    public Material GetMaterial() => Material;
}