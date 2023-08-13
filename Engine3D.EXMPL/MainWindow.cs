using Engine3D.EXMPL._3D_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL;

public static class MainWindow {
    public static void Main() {
        Console.CursorVisible = false;

        var camera = new Camera(new Vector3(-4,0,0), new Vector3(0));
        var world = new World(camera, new List<IObject> {
            new Sphere(new Vector3(0,0,2.0), 1),
            new Sphere(new Vector3(0,0,0), 1),
            //new Cube(new Vector3(0,0,0), new Vector3(1)),
            //new Plane(new Vector3(0, 0, -1), 1)
        }, new List<Vector3> {
            new Vector3(0, 0, -2),
        });

        var t = 0;
        while (true) {
            t++;
            world.GetView();
            world.Lights[0] = new Vector3(Math.Cos(t * .01), Math.Sin(t * .01), .1);
            world.Objects[0].SetPosition(new Vector3(Math.Sin(t * .01), Math.Sin(t * .01), Math.Sin(t * .01)));
            
            //world.Camera.Coordinates.RotateZ(t * .000001);
            //world.Camera.Angles = new Vector3(0, 0,t * .001);
        }
    }
}