using Engine3D.EXMPL._3D_OBJECTS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL.ENGINE_OBJECTS;

public class World {
    public World(Camera camera) {
        Camera  = camera;
        Objects = new List<IObject>();
        Lights  = new List<Vector3>();
    }
    
    public World(Camera camera, List<IObject> objects) {
        Camera  = camera;
        Objects = objects;
        Lights  = new List<Vector3>();
    }
    
    public World(Camera camera, List<IObject> objects, List<Vector3> lights) {
        Camera  = camera;
        Objects = objects;
        Lights  = lights;
    }
    
    public Camera Camera { get; set; }
    public List<IObject> Objects { get; set; }
    public List<Vector3> Lights { get; set; }

    public char[] GetView() {
        return Camera.GetView(Objects, Lights);
    }
}