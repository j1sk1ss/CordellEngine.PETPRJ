using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.COLOR;

public class ColorCamera : Camera {
    public ColorCamera(Vector3 coordinates, Vector3 angles) : base(coordinates, angles) { }

    public ColorCamera(Vector3 coordinates, Vector3 angles, bool isConsole = true, double viewDistance = 20, int cameraX = 120, int cameraY = 30) 
        : base(coordinates, angles, isConsole, viewDistance, cameraX, cameraY) { }

    protected override void GetConsoleView(char[,] buffer, ConsoleColor[,] colorBuffer) {
        if (Console.ForegroundColor != ConsoleColor.White)
            Console.ResetColor();
        
        Console.SetCursorPosition(0,0);
        
        for (var i = 0; i < buffer.GetLength(0); i++) 
            for (var j = 0; j < buffer.GetLength(1); j++) {
                if (buffer[i, j] != ' ') Console.ForegroundColor = colorBuffer[i, j];
            
                Console.Write(buffer[i, j]);
            }
    }
}