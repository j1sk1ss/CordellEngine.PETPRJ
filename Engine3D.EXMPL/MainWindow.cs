using Engine3D.EXMPL.ENGINE_OBJECTS;
using Object = Engine3D.EXMPL.ENGINE_OBJECTS.Object;

namespace Engine3D.EXMPL;

public static class MainWindow {
    public static void Main() {
        Console.CursorVisible = false;

        var camera = new Camera(0d, 0d, 0d, 0d);
        var map = new Object((1,1,1), (4,0,0));
        var world = new World(camera);
        
        while (true) {
            world.GetView(0);
        }
    }
}