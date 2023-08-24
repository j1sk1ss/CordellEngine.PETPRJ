using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.LIGHT_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.CHROME_CAMERA;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.COLOR;
using Engine3D.EXMPL.OBJECTS;
using Object = Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.Object;

namespace Engine3D.EXMPL;

public static class MainWindow {
    public static void Main() {
        Console.CursorVisible = false;

        var space = new Space(new ChromeCamera(new Vector3(-4,0,0), new Vector3(0), true, 20), 
            new List<Object> {
                new Sphere(new Vector3(0), new Vector3(1)),
                new Light(new Vector3(-20, 0, 0), 20)
            });

        var t = 0;
        while (true) {
            t++;
            space.GetView();
            
            space.GetObject("sphere1").SetPosition(new Vector3(Math.Cos(t * .01) * 2, 0, 0));
        }
    }
}