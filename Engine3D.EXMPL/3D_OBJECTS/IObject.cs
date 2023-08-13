using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS;

public interface IObject {
    public Vector2 Intersection(Vector3 cameraPosition, Vector3 cameraRay);

    public Vector3 GetPosition();
    
    public Vector3 GetNormal(Vector3 cameraPosition, Vector3 cameraRay, double value);
}