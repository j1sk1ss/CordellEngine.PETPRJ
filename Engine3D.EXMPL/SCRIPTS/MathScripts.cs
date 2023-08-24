namespace Engine3D.EXMPL.SCRIPTS;

public static class MathScripts {
    /// <summary>
    /// Clamp script
    /// </summary>
    /// <param name="value"> Value for clamping </param>
    /// <param name="min"> Min value for clamping </param>
    /// <param name="max"> Max value for clamping </param>
    /// <returns> Clamped value </returns>
    public static double Clamp(double value, double min, double max) => Math.Max(Math.Min(value, max), min);

    /// <summary>
    /// Step script
    /// </summary>
    /// <param name="edge"> Edge for stepping </param>
    /// <param name="x"> Value for stepping </param>
    /// <returns> Stepped value </returns>
    public static double Step(double edge, double x) => (x > edge) switch {
        true  => 1,
        false => 0
    };
}