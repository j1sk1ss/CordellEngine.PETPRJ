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
    /// <param name="color"> Color of material </param>
    /// <param name="reflected"> Reflection status </param>
    public Material(ConsoleColor color, bool reflected) {
        Gradient     = " .:!/r(l1Z4H9W8$@";
        ConsoleColor = color;
        Reflected    = reflected;
    }
    
    /// <summary>
    /// Material of Object
    /// </summary>
    /// <param name="gradient"> Gradient of material </param>
    /// <param name="color"> Color of material </param>
    /// <param name="reflected"> Reflection status </param>
    public Material(string gradient, ConsoleColor color, bool reflected) {
        Gradient     = gradient;
        ConsoleColor = color;
        Reflected    = reflected;
    }
    
    private string Gradient { get; }
    private ConsoleColor ConsoleColor { get; }
    private bool Reflected { get; } 
    
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
    /// Get reflection status
    /// </summary>
    /// <returns> Reflection status </returns>
    public bool GetReflection() => Reflected;

    /// <summary>
    /// Default material
    /// </summary>
    public static Material DefaultMaterial => new (" .:!/r(l1Z4H9W8$@", ConsoleColor.White, false);
}