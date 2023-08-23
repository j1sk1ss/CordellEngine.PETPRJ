using System.Text;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.CHROME_CAMERA;

public class ChromeCamera : Camera {
    public ChromeCamera(Vector3 coordinates, Vector3 angles) : base(coordinates, angles) { }

    public ChromeCamera(Vector3 coordinates, Vector3 angles, bool isConsole = true, double viewDistance = 20, int cameraX = 120, int cameraY = 30) 
        : base(coordinates, angles, isConsole, viewDistance, cameraX, cameraY) { }

    protected override void GetConsoleView(char[,] buffer, ConsoleColor[,] colorBuffer) {
        var output = new StringBuilder();

        for (var i = 0; i < buffer.GetLength(0); i++) {
            for (var j = 0; j < buffer.GetLength(1); j++) 
                output.Append(buffer[i, j]);
            
        }
        
        Console.SetCursorPosition(0,0);
        Console.Write(output);
    }
}