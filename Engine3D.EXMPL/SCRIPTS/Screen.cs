namespace Engine3D.EXMPL.SCRIPTS;

public static class Screen {
    public static void Write(char[,] data) {
        for (var j = 0; j < data.GetLength(0); j++) {
            for (var i = 0; i < data.GetLength(1); i++) 
                Console.Write(data[j, i]);

            Console.Write('\n');
        }
    }
}