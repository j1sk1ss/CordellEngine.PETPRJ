using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS;

public class Cube : IObject {
    public Cube(Vector3 position, Vector3 size) {
        Position = position;
        Size   = size;

        Yzx = new Vector3(0);
        Zxy = new Vector3(0);
        T1  = new Vector3(0);
        
        Normal = new Vector3(0);
    }

    private Vector3 Position { get; set; }
    private Vector3 Size { get; set; }
    private Vector3 Normal { get; set; }
    
    public Vector2 Intersection(Vector3 cameraPosition, Vector3 cameraRay) {
        //cameraPosition -= Position;
        
        var m = new Vector3(1) / cameraRay;
        var n = m * cameraPosition;
        var k = m.Abs() * Size;
        var t1 = -n - k;
        var t2 = -n + k;

        var tN = Math.Max(Math.Max(t1.X, t1.Y), t1.Z);
        var tF = Math.Min(Math.Min(t2.X, t2.Y), t2.Z);
        if (tN > tF || tF < .0) return new Vector2(-1);

        Yzx = new Vector3(t1.Y, t1.Z, t1.X);
        Zxy = new Vector3(t1.Z, t1.X, t1.Y);

        return new Vector2(tN, tF);
    }

    private Vector3 Yzx { get; set; }
    private Vector3 Zxy { get; set; }
    private Vector3 T1 { get; set; }

    public Vector3 GetPosition() => Position;

    public Vector3 GetNormal(Vector3 cameraPosition, Vector3 cameraRay, double value) => 
        -cameraRay.Sign() * Yzx.Step(T1) * Zxy.Step(T1);
}