namespace Engine3D.EXMPL.SCRIPTS;

public static class MathScripts
{
    public static double Clamp(double value, double min, double max) => Math.Max(Math.Min(value, max), min);

    public static double Step(double edge, double x) => (x > edge) switch {
        true  => 1,
        false => 0
    };
}