namespace Engine3D.EXMPL._3D_OBJECTS.MATERIALS;

public class Material {
    /// <summary>
    /// Material of Object
    /// </summary>
    /// <param name="gradient"> Gradient of material </param>
    public Material(string gradient) {
        Gradient = gradient;
        ConsoleColor = ConsoleColor.White;
    }
    
    /// <summary>
    /// Material of Object
    /// </summary>
    /// <param name="color"> Color of material </param>
    public Material(ConsoleColor color) {
        Gradient     = " .:!/r(l1Z4H9W8$@";
        ConsoleColor = color;
    }
    
    /// <summary>
    /// Material of Object
    /// </summary>
    /// <param name="gradient"> Gradient of material </param>
    /// <param name="color"> Color of material </param>
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