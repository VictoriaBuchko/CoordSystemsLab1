namespace CoordSystemsLab1.Models;

public sealed class CartesianPoint3D
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public CartesianPoint3D(double x, double y, double z)
    {
        X = x; Y = y; Z = z;
    }

    public static CartesianPoint3D FromSpherical(SphericalPoint s)
    {
        double x = s.Radius * Math.Sin(s.PolarAngle) * Math.Cos(s.Azimuth);
        double y = s.Radius * Math.Sin(s.PolarAngle) * Math.Sin(s.Azimuth);
        double z = s.Radius * Math.Cos(s.PolarAngle);
        return new CartesianPoint3D(x, y, z);
    }

    public override string ToString() =>
        $"CartesianPoint3D(x={X:F4}, y={Y:F4}, z={Z:F4})";
}