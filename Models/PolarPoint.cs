namespace CoordSystemsLab1.Models;

public sealed class PolarPoint
{
    public double Radius { get; }
    public double Angle { get; } 

    public PolarPoint(double radius, double angle)
    {
        Radius = radius;
        Angle = angle;
    }

    public static PolarPoint FromCartesian(CartesianPoint2D p)
    {
        double radius = Math.Sqrt(p.X * p.X + p.Y * p.Y);
        double angle = Math.Atan2(p.Y, p.X);
        return new PolarPoint(radius, angle);
    }

    public override string ToString() =>
        $"PolarPoint(radius={Radius:F4}, angle={Angle:F4} рад)";
}