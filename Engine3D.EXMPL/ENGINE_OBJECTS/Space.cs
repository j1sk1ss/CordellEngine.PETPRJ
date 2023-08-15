using Engine3D.EXMPL._3D_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY;

namespace Engine3D.EXMPL.ENGINE_OBJECTS;

public class Space {
    /// <summary>
    /// Space
    /// </summary>
    /// <param name="camera"> Camera </param>
    public Space(Camera camera) {
        Camera  = camera;
        Objects = new List<IObject>();
    }
    
    /// <summary>
    /// Space
    /// </summary>
    /// <param name="camera"> Camera </param>
    /// <param name="objects"> Objects </param>
    public Space(Camera camera, List<IObject> objects) {
        Camera  = camera;
        Objects = objects;
    }

    private Camera Camera { get; set; }
    private List<IObject> Objects { get; set; }

    /// <summary>
    /// Get camera view in space
    /// </summary>
    /// <returns> Camera view in console and char array of this view </returns>
    public char[] GetView() => Camera.GetView(Objects);

    /// <summary>
    /// Get camera
    /// </summary>
    /// <returns> Camera </returns>
    public Camera GetCamera() => Camera;
    
    /// <summary>
    /// Get object via name
    /// </summary>
    /// <param name="name"> Object name </param>
    /// <returns> Object </returns>
    public IObject GetObject(string name) =>
        Objects.FirstOrDefault(iObject => iObject.GetName() == name)!;
}