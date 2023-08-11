namespace Engine3D.EXMPL.OBJECTS;

public class Map {
    public Map(int wight, int height) {
        Height = height;
        Wight  = wight;

        Body = new char[wight, height];
    }
    
    public Map(int wight, int height, string body) {
        Height = height;
        Wight  = wight;

        Body = new char[wight, height];
        InsertMap(body);
    }
    
    public int Height { get; set; } 
    public int Wight { get; set; }

    private char[,] Body { get; set; }

    public void InsertMap(string map) {
        var pos = 0;
        
        for (var i = 0; i < Wight; i++) 
            for (var j = 0; j < Height; j++)
                if (pos < map.Length) 
                    Body[i, j] = map[pos++];
    }

    public char[,] GetMap() => Body;
}