using Engine3D.EXMPL._3D_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.LIGHT_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL;

public static class MainWindow {
    public static void Main() {
        Console.CursorVisible = false;

        var space = new Space(new Camera(new Vector3(-4,0,0), new Vector3(0)), 
            new List<IObject> {
            //new Cube(new Vector3(0,0,0), new Vector3(4), "cube1"),
            new Sphere(new Vector3(0,0,-1), 1, "sphere1"),
            //new Sphere(new Vector3(0,-2,0), 1, "sphere2"),
            new Plane(new Vector3(0, 0, -1), 1, "plane1"),
            new Light(new Vector3(-2, 2, -2), "light1")
        });

        var t = 0;
        while (true) {
            t++;
            space.GetView();
            //space.GetObject("light1").SetPosition(new Vector3(Math.Cos(t * .01) * 2, Math.Cos(t * .01) * 2, -2));
            space.GetObject("plane1").SetPosition(new Vector3(0, 0, Math.Sin(t * .01) * 2));
            
            //space.GetCamera().Coordinates.RotateZ(t * .000001);
            //space.GetCamera().Coordinates += new Vector3(0, 0, .0010);
            //space.GetCamera().Angles += new Vector3(0, .0001,0);
        }
    }
}