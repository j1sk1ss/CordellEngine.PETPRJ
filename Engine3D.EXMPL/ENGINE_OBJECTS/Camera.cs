using Engine3D.EXMPL._3D_OBJECTS;
using Engine3D.EXMPL._3D_OBJECTS.LIGHT_OBJECTS;
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
    private double _aspect = 1d;
    private const double PixelAspect = 11d / 24d;
    private const string Gradient = " .:!/r(l1Z4H9W8$@";

    /// <summary>
    /// Get camera view via console or char array
    /// </summary> 
    /// <param name="objects"> Objects on scene </param>
    /// <returns> Char array </returns>
    public char[] GetView(List<IObject> objects) {
        var lights = objects.Where(iObject => iObject.GetType() == typeof(Light)).ToList();
        _buffer = new char[Size.wight * Size.height];

        for (var i = 0; i < Size.wight; i++) 
            for (var j = 0; j < Size.height; j++) {
                var uv = new Vector2(i, j) / new Vector2(Size.wight, Size.height) * new Vector2(2d) - new Vector2(1d);
                uv.X *= _aspect * PixelAspect;

                var cameraRay = new Vector3(1, uv).Rotate(Angles).Normalize();
                var minIt = 99999d;

                var rayOrigin = Coordinates;
                var rayDirection = cameraRay;

                for (var k = 0; k < 1; k++) {
                    foreach (var iObject in objects) {
                        var intersection = iObject.Intersection(rayOrigin, rayDirection, out var normal);
                        if (!(intersection.X > 0) || !(intersection.X < minIt)) continue;
                        if (lights.Count > 0)
                            foreach (var light in lights) {
                                _buffer[i + j * Size.wight] = Gradient[(int)MathScripts.Clamp(
                                    Gradient.IndexOf(_buffer[i + j * Size.wight]) +
                                    (int)(normal.Dot(light.GetPosition().Normalize()) * 20),
                                    0, Gradient.Length - 2)];

                                if (!(minIt < 99999)) continue;
                                rayOrigin += rayDirection * (new Vector3(minIt) - new Vector3(0.01));
                                rayDirection = rayDirection.Reflect(normal);
                            }
                        else _buffer[i + j * Size.wight] = '@';

                        minIt = intersection.X;
                    }
                }
            }
        
        Console.Write(_buffer); 
        return _buffer;
    }
}