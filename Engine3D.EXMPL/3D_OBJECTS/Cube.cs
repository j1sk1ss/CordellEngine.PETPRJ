using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS;

public class Cube : IObject {
    public Cube(Vector3 position, Vector3 size) {
        Position = position;
        Size   = size;
        
        Normal = new Vector3(0);
    }

    private Vector3 Position { get; set; }
    private Vector3 Size { get; set; }
    private Vector3 Normal { get; set; }
    
    public Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        rayOrigin -= Position;
        
        var invertedRay = new Vector3(1d) / rayDirection;
        var scaledOffset = invertedRay * rayOrigin;
        var boxHalfSize = invertedRay.Abs() * Size;
        
        var tNear = -scaledOffset - boxHalfSize;
        var tFar = -scaledOffset + boxHalfSize;

        var tNearMax = Math.Max(Math.Max(tNear.X, tNear.Y), tNear.Z);
        var tFarMin = Math.Min(Math.Min(tFar.X, tFar.Y), tFar.Z);
        if (tNearMax > tFarMin || tFarMin < .0d) {
            intersectionNormal = new Vector3(0);
            return new Vector2(-1d);
        }

        var yzxOrder = new Vector3(tNear.Y, tNear.Z, tNear.X);
        var zxyOrder = new Vector3(tNear.Z, tNear.X, tNear.Y);

        intersectionNormal = -rayDirection.Sign() * yzxOrder.Step(tNear) * zxyOrder.Step(tNear);
        return new Vector2(tNearMax, tFarMin);
    }

    public void SetPosition(Vector3 position) => Position = position;
    
    public Vector3 GetPosition() => Position;
}