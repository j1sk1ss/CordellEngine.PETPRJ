using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.LIGHT_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.CHROME_CAMERA;
using Engine3D.EXMPL.OBJECTS;
using Object = Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.Object;

namespace Engine3D.EXMPL;

public static class MainWindow {
    public static void Main() {
        Console.CursorVisible = false;

        var space = new Space(new ChromeCamera(new Vector3(-4,0,0), new Vector3(0), 20), 
            new List<Object> {
                new Collection(new Vector3(0), new Vector3(0), new List<Object> {
                    new Polygon(new [] {
                        new Vector3(0,-1,-1),
                        new Vector3(0,1,-1),
                        new Vector3(0,1,1),
                    }),
                    new Polygon(new [] {
                        new Vector3(0,-1,-1),
                        new Vector3(0,-1,1),
                        new Vector3(0,1,1),
                    }),
                    
                    new Polygon(new [] {
                        new Vector3(1,-1,-1),
                        new Vector3(0,-1,-1),
                        new Vector3(1,-1,1),
                    }),
                    new Polygon(new [] {
                        new Vector3(0,-1,-1),
                        new Vector3(0,-1,1),
                        new Vector3(6,-1,1),
                    }),
                })
            });

        var t = 0;
        while (true) {
            t++;
            space.GetView();
            
            space.GetObject("collection1").Rotate(new Vector3(0, .01, .01));
        }
    }
}