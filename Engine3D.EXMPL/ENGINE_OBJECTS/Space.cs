using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA;
using Engine3D.EXMPL.OBJECTS;
using Object = Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.Object;

namespace Engine3D.EXMPL.ENGINE_OBJECTS;

public class Space {
    /// <summary>
    /// Space
    /// </summary>
    public Space() {
        Camera  = null!;
        Objects = new List<Object>();
    }
    
    /// <summary>
    /// Space
    /// </summary>
    /// <param name="camera"> Camera </param>
    public Space(Camera camera) {
        Camera  = camera;
        Objects = new List<Object>();
    }
    
    /// <summary>
    /// Space
    /// </summary>
    /// <param name="camera"> Camera </param>
    /// <param name="objects"> Objects </param>
    public Space(Camera camera, List<Object> objects) {
        Camera  = camera;
        Objects = objects;
    }

    private Camera Camera { get; set; }
    public List<Object> Objects { get; set; }

    /// <summary>
    /// Get camera view in space
    /// </summary>
    /// <returns> Camera view in console and char array of this view </returns>
    public (char[,] image, ConsoleColor[,] color, double[,] light) GetView() => Camera.GetView(Objects);

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
    public Object GetObject(string name) =>
        Objects.FirstOrDefault(iObject => iObject.GetName() == name) ?? new NullObject(new Vector3(0), new Vector3(0));

    /// <summary>
    /// Add object into space
    /// </summary>
    /// <param name="obj"> New object </param>
    public void CreateObject(Object obj) => Objects.Add(obj);

    /// <summary>
    /// Delete object from space
    /// </summary>
    /// <param name="name"> Object name </param>
    public void DeleteObject(string name) {
        foreach (var currentObject in Objects.Where(currentObject => currentObject.GetName() == name)) {
            Objects.Remove(currentObject);
            break;
        }
    }
}