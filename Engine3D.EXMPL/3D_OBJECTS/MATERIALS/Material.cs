using System;

namespace Engine3D.EXMPL._3D_OBJECTS.MATERIALS;

public class Material {
    /// <summary>
    /// Material of Object
    /// </summary>
    /// <param name="gradient"> Gradient of material </param>
    public Material(string gradient) {
        Gradient     = gradient;
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
    
    private string Gradient { get; }
    private ConsoleColor ConsoleColor { get; }
    
    /// <summary>
    /// Get material gradient
    /// </summary>
    /// <returns> Gradient </returns>
    public string GetGradient() => Gradient;
    
    /// <summary>
    /// Get material color
    /// </summary>
    /// <returns> Color </returns>
    public ConsoleColor GetGColor() => ConsoleColor;

    /// <summary>
    /// Default material
    /// </summary>
    public static Material DefaultMaterial => new (" .:!/r(l1Z4H9W8$@", ConsoleColor.White);
}