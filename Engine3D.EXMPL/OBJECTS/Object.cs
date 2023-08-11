namespace Engine3D.EXMPL.OBJECTS;

public class Object {
    public Object((int wight, int height, int depth) size, (int x, int y, int z) coordinates) {
        Size = size;
        Coordinates = coordinates;
    }
    
    public (int wight, int height, int depth) Size { get; set; } 
    public (int x, int y, int z) Coordinates { get; set; } 

    public int[,,] Insert(int[,,] space) {
        for (var i = Coordinates.x; i < Size.wight + Coordinates.x; i++)
            for (var j = Coordinates.y; j < Size.height + Coordinates.y; j++)
                for (var k = Coordinates.z; k < Size.depth + Coordinates.z; k++)
                    space[k, j, i] = 1; 

        return space;
    }
}