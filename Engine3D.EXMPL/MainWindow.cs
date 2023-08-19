using System;
using System.Collections.Generic;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.GEOMETRY_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.LIGHT_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.ENGINE_OBJECTS;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.CHROME_CAMERA;
using Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.COLOR;
using Engine3D.EXMPL.OBJECTS;
using Object = Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.Object;

namespace Engine3D.EXMPL;

public static class MainWindow {
    public static void Main() {
        Console.CursorVisible = false;

        var space = new Space(new ChromeCamera(new Vector3(-4,0,0), new Vector3(0)), 
            new List<Object> {
                new Collection(new Vector3(0, 0, 0), new Vector3(1), new List<Object> {
                    new Line(new Vector3(-1.8, -1, 1), new Vector3(-1.8, 1, 1)),
                    new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, 1, 0)),
                
                    new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, -1, -1)),
                    new Line(new Vector3(-1.8, -3, 0), new Vector3(-1.8, -3, -1)),
                
                    new Line(new Vector3(0, -1, 1), new Vector3(0, 1, 1)),
                    new Line(new Vector3(0, -1, 0), new Vector3(0, 1, 0)),
                
                    new Line(new Vector3(0, -1, 0), new Vector3(0, -1, -1)),
                    new Line(new Vector3(0, -3, 0), new Vector3(0, -3, -1)),
                }, new Material(ConsoleColor.Blue), "cl1"),
                new Collection(new Vector3(0, 2, 0), new Vector3(1), new List<Object> {
                    new Line(new Vector3(-1.8, -1, 1), new Vector3(-1.8, 1, 1)),
                    new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, 1, 0)),
                
                    new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, -1, -1)),
                    new Line(new Vector3(-1.8, -3, 0), new Vector3(-1.8, -3, -1)),
                
                    new Line(new Vector3(0, -1, 1), new Vector3(0, 1, 1)),
                    new Line(new Vector3(0, -1, 0), new Vector3(0, 1, 0)),
                
                    new Line(new Vector3(0, -1, 0), new Vector3(0, -1, -1)),
                    new Line(new Vector3(0, -3, 0), new Vector3(0, -3, -1)),
                }, new Material(ConsoleColor.Yellow), "cl2"),
                new Collection(new Vector3(0, 2, 0), new Vector3(1), new List<Object> {
                    new Line(new Vector3(-1.8, -1, 1), new Vector3(-1.8, 1, 1)),
                    new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, 1, 0)),
                
                    new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, -1, -1)),
                    new Line(new Vector3(-1.8, -3, 0), new Vector3(-1.8, -3, -1)),
                
                    new Line(new Vector3(0, -1, 1), new Vector3(0, 1, 1)),
                    new Line(new Vector3(0, -1, 0), new Vector3(0, 1, 0)),
                
                    new Line(new Vector3(0, -1, 0), new Vector3(0, -1, -1)),
                    new Line(new Vector3(0, -3, 0), new Vector3(0, -3, -1)),
                }, new Material(ConsoleColor.Green), "cl3"),
                new Collection(new Vector3(0, 2, 0), new Vector3(1), new List<Object> {
                    new Line(new Vector3(-1.8, -1, 1), new Vector3(-1.8, 1, 1)),
                    new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, 1, 0)),
                
                    new Line(new Vector3(-1.8, -1, 0), new Vector3(-1.8, -1, -1)),
                    new Line(new Vector3(-1.8, -3, 0), new Vector3(-1.8, -3, -1)),
                
                    new Line(new Vector3(0, -1, 1), new Vector3(0, 1, 1)),
                    new Line(new Vector3(0, -1, 0), new Vector3(0, 1, 0)),
                
                    new Line(new Vector3(0, -1, 0), new Vector3(0, -1, -1)),
                    new Line(new Vector3(0, -3, 0), new Vector3(0, -3, -1)),
                }, new Material(ConsoleColor.Red), "cl4"),
            });

        var t = 0;
        while (true) {
            t++;
            space.GetView();
            
            space.GetObject("cl1").SetPosition(new Vector3(Math.Cos(t * .01), -Math.Cos(t * .01), Math.Sin(t * .01)));
            space.GetObject("cl2").SetPosition(new Vector3(Math.Cos(t * .01), -Math.Cos(t * .01) - 2, Math.Sin(t * .01)));
            space.GetObject("cl3").SetPosition(new Vector3(Math.Cos(t * .01), -Math.Cos(t * .01) - 2, Math.Sin(t * .01) + 1));
            space.GetObject("cl4").SetPosition(new Vector3(Math.Cos(t * .01), -Math.Cos(t * .01), Math.Sin(t * .01) + 1));
        }
    }
}