using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.CHROME_CAMERA;

public class ChromeCamera : Camera {
    public ChromeCamera(Vector3 coordinates, Vector3 angles) : base(coordinates, angles) { }

    public ChromeCamera(Vector3 coordinates, Vector3 angles, int cameraX, int cameraY) : base(coordinates, angles, cameraX, cameraY) { }

    protected override void GetConsoleView(char[] buffer, ConsoleColor[] colorBuffer) {
        Console.Write(buffer);
        Console.SetCursorPosition(0,0);
    }
}