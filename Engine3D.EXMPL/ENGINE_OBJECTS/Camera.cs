using Engine3D.EXMPL._3D_OBJECTS;
using Engine3D.EXMPL.OBJECTS;
using Engine3D.EXMPL.SCRIPTS;

namespace Engine3D.EXMPL.ENGINE_OBJECTS;

public class Camera {
    public Camera() {
        Coordinates = new Vector3(0);
        Angles = new Vector3(0);
        Size = (120, 30);
        CameraDepth = 20;
        
        Initialization();
    }

    public Camera(Vector3 coordinates, Vector3 angles) {
        Coordinates = coordinates;
        Angles = angles;
        Size = (120, 30);
        CameraDepth = 20;
        
        Initialization();
    }

    public Camera(Vector3 coordinates, Vector3 angles, int cameraX, int cameraY) {
        Coordinates = coordinates;
        Angles = angles;
        Size = (cameraX, cameraY);
        CameraDepth = 20;
        
        Initialization();
    }

    private void Initialization() {
        _aspect = Size.wight / (double)Size.height;
        Console.SetWindowSize(Size.wight, Size.height);
        Console.SetBufferSize(Size.wight, Size.height);
        Console.SetCursorPosition(0,0);
    }
    
    public Vector3 Coordinates { get; set; }
    public Vector3 Angles { get; set; }
    public int CameraDepth { get; set; }
    private static (int wight, int height) Size { get; set; }
    
    private char[] _buffer = null!;
    private double _aspect = 1d;
    private const double PixelAspect = 11d / 24d;
    private const string Gradient = " .:!/r(l1Z4H9W8$@";

    public char[] GetView(List<IObject> objects, List<Vector3> lights) {
        _buffer = new char[Size.wight * Size.height];
        for (var i = 0; i < Size.wight; i++) {
            for (var j = 0; j < Size.height; j++) {
                var uv = new Vector2(i, j) / new Vector2(Size.wight, Size.height) * new Vector2(2d) - new Vector2(1d);
                uv.X *= _aspect * PixelAspect;

                var cameraRay = new Vector3(1, uv).Rotate(Angles).Normalize();
                var minIt = 99999d;
                for (var k = 0; k < 1; k++) {
                    foreach (var iObject in objects) {
                        var intersection = iObject.Intersection(Coordinates, cameraRay, out var normal);
                        
                        if (intersection.X > 0 && intersection.X < minIt) {
                            if (lights.Count > 0)
                                foreach (var light in lights) {
                                    _buffer[i + j * Size.wight] = Gradient[(int)MathScripts.Clamp(
                                        Gradient.IndexOf(_buffer[i + j * Size.wight]) +
                                        (int)(normal.Dot(light.Normalize()) * 20),
                                        0, Gradient.Length - 2)];
                                }
                            else
                                _buffer[i + j * Size.wight] = '@';

                            minIt = intersection.X;
                        }
                    }
                    
                    
                    //if (maxValue < double.MaxValue) {
                        //distance *= (n.Dot(lightRay) * .5d + .5d) * albedo;
                        //cameraPosition += cameraRay * (maxValue - .01d);
                        //cameraRay = Vector3.Reflect(cameraRay, n);
                    //} else break;
                }

                //_buffer[i + j * Size.wight] = Gradient[(int)MathScripts.Clamp((int)(distance * 20), 0, Gradient.Length - 2)];
            }
        }

        Console.Write(_buffer);
        return _buffer;
    }
}