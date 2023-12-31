﻿using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.LIGHT_OBJECTS;
using Engine3D.EXMPL.OBJECTS;
using Engine3D.EXMPL.SCRIPTS;
using Object = Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.Object;

namespace Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA;

public abstract class Camera {
    /// <summary>
    /// Camera object
    /// </summary>
    /// <param name="coordinates"> Camera coordinates </param>
    /// <param name="angles"> Camera angles </param>
    /// <param name="isConsole"> Is this console </param>
    /// <param name="viewDistance"> Distance of camera view </param>
    /// <param name="cameraX"> X camera size </param>
    /// <param name="cameraY"> Y camera size </param>
    protected Camera(Vector3 coordinates, Vector3 angles, bool isConsole = true, double viewDistance = 20, int cameraX = 120, int cameraY = 30) {
        Coordinates  = coordinates;
        Angles       = angles;
        Size         = (cameraX, cameraY);
        ViewDistance = viewDistance;

        IsConsole = isConsole;
        
        if (!isConsole) return;
        Console.SetWindowSize(Size.wight, Size.height);
        Console.SetBufferSize(Size.wight, Size.height);
        Console.SetCursorPosition(0, 0);
    }

    private bool IsConsole { get; }
    
    public Vector3 Coordinates { get; }
    public Vector3 Angles { get; }
    public double ViewDistance { get; }
    private static (int wight, int height) Size { get; set; }

    /// <summary>
    /// Get camera view via console or char array
    /// </summary> 
    /// <param name="objects"> Objects on scene </param>
    /// <returns> Char array </returns>
    public (char[,] image, ConsoleColor[,] color, double[,] light) GetView(List<Object> objects) {
        var lights = objects.Where(iObject => iObject.GetType() == typeof(Light)).ToList();
        
        var buffer = new char[Size.height, Size.wight];
        var colorBuffer = new ConsoleColor[Size.height, Size.wight];
        var lightBuffer = new double[Size.height, Size.wight];

        Parallel.For(0, Size.wight, i => {
            Parallel.For(0, Size.height, j => {
                var uv = new Vector2(i, j) / new Vector2(Size.wight, Size.height) * new Vector2(2d) - new Vector2(1d);
                uv.X *= Size.wight / (double)Size.height * (11d / 24d);

                var cameraRay = new Vector3(1, uv).Rotate(Angles).Normalize();
                var minIt = 99999d;

                
                
                //foreach (var iObject in objects.Where(iObject => !lights.Contains(iObject))) {
                    var rayOrigin = Coordinates;
                    var rayDirection = cameraRay;
                    
                    foreach (var anotherObject in objects.Where(anotherObject => !lights.Contains(anotherObject))) {
                        //if (iObject.Equals(anotherObject)) continue;
                        
                        var intersection = anotherObject.Intersection(rayOrigin, rayDirection, out var normal);
                        if (intersection.intersectionCoordinate.X <= 0 || intersection.intersectionCoordinate.X >= minIt) continue;

                        if ((from otherObject in objects
                                where otherObject != anotherObject
                                select otherObject.Intersection(rayOrigin, rayDirection, out _)).Any(shadowIntersection =>
                                shadowIntersection.intersectionCoordinate.X > 0 
                                && shadowIntersection.intersectionCoordinate.X < intersection.intersectionCoordinate.X))
                            buffer[j, i] = ' ';
                        else {
                            colorBuffer[j, i] = intersection.intersectionMaterial.GetGColor();

                            if (lights.Count > 0)
                                foreach (var light in lights.Cast<Light>())
                                {
                                    lightBuffer[j, i] = (int)MathScripts.Clamp(
                                        intersection.intersectionMaterial.GetGradient().IndexOf(buffer[j, i]) + (int)(normal.Dot(
                                            light.GetPosition().Normalize()) * (ViewDistance - Math.Max(
                                            0, ViewDistance - normal.Distance(Coordinates))) * light.GetStrength()), 0,
                                        intersection.intersectionMaterial.GetGradient().Length - 2);
                                    buffer[j, i] = intersection.intersectionMaterial.GetGradient()[(int)lightBuffer[j, i]];
                                }
                            else {
                                buffer[j, i] = '@';
                                lightBuffer[j, i] = -1;
                            }

                            lightBuffer[j, i] = lightBuffer[j, i] / intersection.intersectionMaterial.GetGradient().Length - 2;
                        }

                        minIt = intersection.intersectionCoordinate.X;
                        if (!(minIt < 99999)) continue;
                        if (!intersection.intersectionMaterial.GetReflection()) continue;

                        rayOrigin += rayDirection * (new Vector3(minIt) - new Vector3(.01));
                        rayDirection = rayDirection.Reflect(normal);
                    }
                //}
            });
        });
            
        if (IsConsole)
            GetConsoleView(buffer, colorBuffer);
        
        return (buffer, colorBuffer, lightBuffer);
    }

    /// <summary>
    /// Get console view
    /// </summary>
    /// <param name="buffer"> Console buffer </param>
    /// <param name="colorBuffer"> Color buffer </param>
    protected abstract void GetConsoleView(char[,] buffer, ConsoleColor[,] colorBuffer);
}