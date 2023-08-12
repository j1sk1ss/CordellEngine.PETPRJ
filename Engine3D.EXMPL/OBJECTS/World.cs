namespace Engine3D.EXMPL.OBJECTS;

public class World {
    public World(Camera camera) {
        Space = new int[20, 20, 20];
        Cameras = new List<Camera> {
            camera
        };
    }
    
    public World(Camera camera, Object @object) {
        Space = new int[20, 20, 20];
        Cameras = new List<Camera> {
            camera
        };

        Space = @object.Insert(Space);
    }
    
    public World(List<Camera> cameras, List<Object> objects) {
        Space = new int[20, 20, 20];
        Cameras = cameras;

        foreach (var obj in objects) 
            Space = obj.Insert(Space);
    }
    
    public int[,,] Space { get; set; }
    
    public List<Camera> Cameras { get; set; }

    public void GetView(int camera) {
        Cameras[camera].GetView(this);
    }
}