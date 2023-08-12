using Engine3D.EXMPL.CONSTANTS;
using Engine3D.EXMPL.SCRIPTS;

namespace Engine3D.EXMPL.OBJECTS;

public class Camera {
    public Camera() {
        Coordinates = (0, 0, 0);
        Angles = (0, 0);
        Size = (150, 40);
        Fov = Math.PI / 3;
        CameraDepth = 20;
    }

    public Camera(double coordinateX, double coordinateY, double horizontalAngle, double verticalAngle) {
        Coordinates = (coordinateX, coordinateY, 0);
        Angles = (horizontalAngle, verticalAngle);
        Size = (150, 40);
        Fov = Math.PI / 3;
        CameraDepth = 20;
    }

    public Camera(double coordinateX, double coordinateY, double horizontalAngle, double verticalAngle,
        int cameraX, int cameraY) {
        Coordinates = (coordinateX, coordinateY, 0);
        Angles = (horizontalAngle, verticalAngle);
        Size = (cameraX, cameraY);
        Fov = Math.PI / 3;
        CameraDepth = 20;
    }

    public Camera(double coordinateX, double coordinateY, double horizontalAngle, double verticalAngle,
        int cameraX, int cameraY, double fov) {
        Coordinates = (coordinateX, coordinateY, 0);
        Angles = (horizontalAngle, verticalAngle);
        Size = (cameraX, cameraY);
        Fov = fov;
        CameraDepth = 20;
    }

    public (double x, double y, double z) Coordinates { get; set; }
    public (double horizontal, double vertical) Angles { get; set; }
    public static (int wight, int height) Size { get; set; }
    public double Fov { get; set; }
    public int CameraDepth { get; set; }
    
    private char[,] _buffer = null!;

    public void GetView(World world) {
        _buffer = new char[Size.wight, Size.height];
        
        Console.SetWindowSize(Size.wight, Size.height);
        Console.SetBufferSize(Size.wight, Size.height);
        Console.SetCursorPosition(0,0);
        
        for (var i = 0; i < Size.wight; i++) {
            var rayDirection = Angles.horizontal + Fov / 2 - i * Fov / Size.wight;
            var rayX = Math.Sin(rayDirection);
            var rayY = Math.Cos(rayDirection);
            
            for (var z = 0; z < Size.height; z++) {
                var distance = 0d;
                while (distance < CameraDepth) {
                    distance += EngineValues.LightSpeed;

                    var x = (int)(Coordinates.x + rayX * distance);
                    var y = (int)(Coordinates.y + rayY * distance);

                    if (x < 0 || x >= CameraDepth + Coordinates.x || y < 0 || y >= CameraDepth + Coordinates.y 
                        || z < 0 || z >= CameraDepth + Coordinates.z) {
                        distance = CameraDepth;
                        break;
                    }

                    if (world.Space[x, y, z] == '1')
                        break;
                }

                var block = (int)(Size.height / 2d - Size.height * Fov / distance);
                var floor = Size.height - block;

                
                if (z <= block)
                    _buffer[i, z] = ' ';
                else if (z > block && z <= floor)
                    _buffer[i, z] = (CameraDepth / distance) switch {
                        < 1.3f and >= 1f => '░',
                        >= 1.3f and < 2f => '▒',
                        >= 2f and < 4f   => '▓',
                        >= 4f and < 20f  => '█',
                        _ => ' '
                    };
                else
                    _buffer[i, z] = '.';
            }
        }

        Screen.Write(_buffer);
    }
}