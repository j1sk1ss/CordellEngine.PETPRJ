using Engine3D.EXMPL.CONSTANTS;

namespace Engine3D.EXMPL.OBJECTS;

public class Camera
{
    public Camera()
    {
        Coordinates = (0, 0, 0);
        Angles = (0, 0);
        Size = (150, 40);
        Fov = Math.PI / 3;
        CameraDepth = 20;

        _buffer = new char[Size.wight * Size.height];
    }

    public Camera(double coordinateX, double coordinateY, double horizontalAngle, double verticalAngle)
    {
        Coordinates = (coordinateX, coordinateY, 0);
        Angles = (horizontalAngle, verticalAngle);
        Size = (150, 40);
        Fov = Math.PI / 3;
        CameraDepth = 20;

        _buffer = new char[Size.wight * Size.height];
    }

    public Camera(double coordinateX, double coordinateY, double horizontalAngle, double verticalAngle,
        int cameraX, int cameraY)
    {
        Coordinates = (coordinateX, coordinateY, 0);
        Angles = (horizontalAngle, verticalAngle);
        Size = (cameraX, cameraY);
        Fov = Math.PI / 3;
        CameraDepth = 20;

        _buffer = new char[Size.wight * Size.height];
    }

    public Camera(double coordinateX, double coordinateY, double horizontalAngle, double verticalAngle,
        int cameraX, int cameraY, double fov)
    {
        Coordinates = (coordinateX, coordinateY, 0);
        Angles = (horizontalAngle, verticalAngle);
        Size = (cameraX, cameraY);
        Fov = fov;
        CameraDepth = 20;

        _buffer = new char[Size.wight * Size.height];
    }

    public (double x, double y, double z) Coordinates { get; set; }
    public (double horizontal, double vertical) Angles { get; set; }
    public (int wight, int height) Size { get; set; }
    public double Fov { get; set; }
    public int CameraDepth { get; set; }

    private readonly char[] _buffer;

    public void GetView(World world) {
        Console.SetWindowSize(Size.wight, Size.height);
        Console.SetBufferSize(Size.wight, Size.height);
        Console.SetCursorPosition(0, 0);

        for (var i = 0; i < Size.wight; i++) {
            for (var j = 0; j < Size.height; j++) {
                var rayDirectionX = Angles.horizontal + Fov / 2 - i * Fov / Size.wight;
                var rayDirectionY = Angles.vertical + Fov / 2 - j * Fov / Size.height;

                var rayX = Math.Sin(rayDirectionX);
                var rayY = Math.Cos(rayDirectionX);
                var rayZ = Math.Sin(rayDirectionY);

                var distance = 0d;
                var isHit = false;

                while (!isHit && distance < CameraDepth) {
                    distance += EngineValues.LightSpeed;

                    var x = (int)(Coordinates.x + rayX * distance);
                    var y = (int)(Coordinates.y + rayY * distance);
                    var z = (int)(Coordinates.z + rayZ * distance);

                    if (x < 0 || x >= world.Space.GetLength(0) || y < 0 || y >= world.Space.GetLength(1) 
                        || z < 0 || z >= CameraDepth) {
                        isHit = true;
                        distance = CameraDepth;
                    }
                    else if (world.Space[z, y, x] == '1') 
                        isHit = true;
                }

                var wall = (int)(Size.height / 2d - Size.height * Fov / distance);
                var floor = Size.height - wall;

                for (var k = 0; k < Size.height; k++) {
                    if (k <= wall) 
                        _buffer[k * Size.wight + i] = ' ';
                    else if (k > wall && k <= floor) {
                        var textureSymbol = (CameraDepth / distance) switch {
                            < 1.3f and >= 1f => '░',
                            >= 1.3f and < 2f => '▒',
                            >= 2f and < 4f   => '▓',
                            >= 4f and < 20f  => '█',
                            
                            _ => ' '
                        };
                        
                        _buffer[k * Size.wight + i] = textureSymbol;
                    }
                    else 
                        _buffer[k * Size.wight + i] = '.';
                }
            }

            Console.Write(_buffer);
        }
    }
}