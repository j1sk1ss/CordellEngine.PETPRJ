using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.LIGHT_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.ENGINE_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.CHROME_CAMERA;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.COLOR;
using Engine3D.EXMPL.OBJECTS;
using Object = Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.Object;

namespace Engine3D.EXMPL;

public static class MainWindow {
    public static void Main() {
        Console.CursorVisible = false;

        var space = new Space(new ColorCamera(new Vector3(-4,0,0), new Vector3(0), true, 20), 
            new List<Object> {
                new Polygon(
                    new [] {
                        new Vector3(0,0,0),
                        new Vector3(0,2,0),
                        new Vector3(0,2,2)
                    }, new Material(ConsoleColor.Red), "p1"),
                new Polygon(
                    new [] {
                        new Vector3(0,0,0),
                        new Vector3(0,2,0),
                        new Vector3(0,2,2)
                    }, new Material(ConsoleColor.Green), "p2")
            });

        var t = 0;
        while (true) {
            t++;
            space.GetView();
            
            space.GetObject("p2").Move(new Vector3(-.1, 0, 0));
            //space.GetObject("p2").Move(new Vector3(0, 0, 0));
        }
    }
}