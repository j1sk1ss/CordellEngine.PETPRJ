namespace Engine3D.EXMPL._3D_OBJECTS.MATERIALS;

public class Material {
    public Material(string gradient) {
        Gradient = gradient;
        ConsoleColor = ConsoleColor.White;
    }
    
    public Material(string gradient, ConsoleColor color) {
        Gradient     = gradient;
        ConsoleColor = color;
    }
    
    private string Gradient { get; set; }
    private ConsoleColor ConsoleColor { get; set; }

    public string GetGradient() => Gradient;
    
    public ConsoleColor GetGColor() => ConsoleColor;

    public static Material DefaultMaterial => new Material(" .:!/r(l1Z4H9W8$@");
}