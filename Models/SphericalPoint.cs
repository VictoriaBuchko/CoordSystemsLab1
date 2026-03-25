namespace CoordSystemsLab1.Models;

public sealed class SphericalPoint
{
    private const double Eps = 1e-9;

    public double Radius { get; }
    public double Azimuth { get; }    
    public double PolarAngle { get; } 

    public SphericalPoint(double radius, double azimuth, double polarAngle)
    {
        Radius = radius;
        Azimuth = azimuth;
        PolarAngle = polarAngle;
    }

    public static SphericalPoint FromCartesian(CartesianPoint3D p)
    {
        double r = Math.Sqrt(p.X * p.X + p.Y * p.Y + p.Z * p.Z);
        double azimuth = Math.Atan2(p.Y, p.X);
        double polar = (r < Eps) ? 0.0 : Math.Acos(p.Z / r);
        return new SphericalPoint(r, azimuth, polar);
    }

    public override string ToString() =>
        $"SphericalPoint(radius={Radius:F4}, azimuth={Azimuth:F4} рад, polarAngle={PolarAngle:F4} рад)";
}