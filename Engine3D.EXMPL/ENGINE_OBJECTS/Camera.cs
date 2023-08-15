using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY;
using Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.LIGHT_OBJECTS;
using Engine3D.EXMPL.OBJECTS;
using Engine3D.EXMPL.SCRIPTS;

namespace Engine3D.EXMPL.ENGINE_OBJECTS;

public class Camera {
    /// <summary>
    /// Camera object
    /// </summary>
    /// <param name="coordinates"> Camera coordinates </param>
    /// <param name="angles"> Camera angles </param>
    public Camera(Vector3 coordinates, Vector3 angles) {
        Coordinates = coordinates;
        Angles      = angles;
        Size        = (120, 30);

        Initialization();
    }

    /// <summary>
    /// Camera object
    /// </summary>
    /// <param name="coordinates"> Camera coordinates </param>
    /// <param name="angles"> Camera angles </param>
    /// <param name="cameraX"> X camera size </param>
    /// <param name="cameraY"> Y camera size </param>
    public Camera(Vector3 coordinates, Vector3 angles, int cameraX, int cameraY) {
        Coordinates = coordinates;
        Angles      = angles;
        Size        = (cameraX, cameraY);

        Initialization();
    }

    private void Initialization() {
        _aspect = Size.wight / (double)Size.height;
        Console.SetWindowSize(Size.wight, Size.height);
        Console.SetBufferSize(Size.wight, Size.height);
        Console.SetCursorPosition(0, 0);
    }

    public Vector3 Coordinates { get; set; }
    public Vector3 Angles { get; set; }
    private static (int wight, int height) Size { get; set; }

    private char[] _buffer = null!;
    private ConsoleColor[] _colorBuffer = null!;
    private double _aspect = 1d;
    private const double PixelAspect = 11d / 24d;

    /// <summary>
    /// Get camera view via console or char array
    /// </summary> 
    /// <param name="objects"> Objects on scene </param>
    /// <returns> Char array </returns>
    public char[] GetView(List<IObject> objects) {
        var lights = objects.Where(iObject => iObject.GetType() == typeof(Light)).ToList();
        _buffer = new char[Size.wight * Size.height];
        _colorBuffer = new ConsoleColor[Size.wight * Size.height];

        for (var i = 0; i < Size.wight; i++) 
            for (var j = 0; j < Size.height; j++) {
                var uv = new Vector2(i, j) / new Vector2(Size.wight, Size.height) * new Vector2(2d) - new Vector2(1d);
                uv.X *= _aspect * PixelAspect;

                var cameraRay = new Vector3(1, uv).Rotate(Angles).Normalize();
                var minIt = 99999d;
                
                foreach (var iObject in objects) {
                    var intersection = iObject.Intersection(Coordinates, cameraRay, out var normal);
                    if (!(intersection.X > 0) || !(intersection.X < minIt)) continue;

                    if ((from otherObject in objects where otherObject != iObject select otherObject.Intersection(
                            Coordinates, cameraRay, out _)).Any(shadowIntersection =>
                            shadowIntersection.X > 0 && shadowIntersection.X < intersection.X)) 
                        _buffer[i + j * Size.wight] = ' ';
                    else {
                        _colorBuffer[i + j * Size.wight] = iObject.GetMaterial().GetGColor();
                        if (lights.Count > 0)
                            foreach (var light in lights.Cast<Light>())
                                _buffer[i + j * Size.wight] = iObject.GetMaterial().GetGradient()[
                                    (int)MathScripts.Clamp(
                                        iObject.GetMaterial().GetGradient().IndexOf(_buffer[i + j * Size.wight]) +
                                        (int)((normal.Dot(light.GetPosition().Normalize()) * 20) * light.GetStrength()),
                                        0, iObject.GetMaterial().GetGradient().Length - 2)];
                        else _buffer[i + j * Size.wight] = '@';
                    }

                    minIt = intersection.X;
                }
            }
        
        Console.Write(_buffer);
        Console.SetCursorPosition(0,0);
        
        return _buffer;
    }
}