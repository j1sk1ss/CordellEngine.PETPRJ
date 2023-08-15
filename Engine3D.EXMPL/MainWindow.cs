using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.LIGHT_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.ENGINE_OBJECTS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL;

public static class MainWindow {
    public static void Main() {
        Console.CursorVisible = false;

        var space = new Space(new Camera(new Vector3(-4,0,0), new Vector3(0)), 
            new List<IObject> {
            //new Sphere(new Vector3(0,0,0), 1, new Material(" 123456789&H9W8$@"), "sphere1"),
            new Sphere(new Vector3(0,0,1), 1, new Material(" .:!/r(l1Z4H9W8$@"), "sphere2"),
            new Cube(new Vector3(0,0,0), new Vector3(1)),
            new Light(new Vector3(0, 2, -2), 1, "light1"),
        });

        var t = 0;
        while (true) {
            t++;
            space.GetView();
            space.GetObject("light1").SetPosition(new Vector3(Math.Cos(t * .01), Math.Sin(t * .01), -2));
            //space.GetObject("sphere1").SetPosition(new Vector3(0, Math.Sin(t * .01) * 2, 0));
            space.GetObject("cube1").SetPosition(new Vector3(Math.Sin(t * .01), -Math.Sin(t * .01), Math.Cos(t * .01)));
            
            //space.GetCamera().Coordinates.RotateZ(t * .000001);
            //space.GetCamera().Coordinates += new Vector3(0, 0, .0010);
            //space.GetCamera().Angles += new Vector3(0, .0001,0);
        }
    }
}