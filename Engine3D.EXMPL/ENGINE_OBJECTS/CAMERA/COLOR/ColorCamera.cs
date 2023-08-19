using System;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL.ENGINE_OBJECTS.CAMERA.COLOR;

public class ColorCamera : Camera {
    public ColorCamera(Vector3 coordinates, Vector3 angles) : base(coordinates, angles) { }

    public ColorCamera(Vector3 coordinates, Vector3 angles, int cameraX, int cameraY) : base(coordinates, angles, cameraX, cameraY) { }

    protected override void GetConsoleView(char[] buffer, ConsoleColor[] colorBuffer) {
        if (Console.ForegroundColor != ConsoleColor.Black)
            Console.ResetColor();
        
        for (var i = 0; i < buffer.Length; i++) {
            if (buffer[i] != ' ') Console.ForegroundColor = colorBuffer[i];
            
            Console.Write(buffer[i]);
        }
        
        Console.SetCursorPosition(0,0);
    }
}