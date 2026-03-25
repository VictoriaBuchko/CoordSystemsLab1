namespace CoordSystemsLab1.Models;

public static class DistanceCalculator
{
    //2D евклідова відстань між двома декартовими точками
    public static double Euclidean(CartesianPoint2D a, CartesianPoint2D b)
    {
        double dx = b.X - a.X;
        double dy = b.Y - a.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    //2D відстань між двома полярними точками (теорема косинусів)
    public static double Polar(PolarPoint a, PolarPoint b)
    {
        return Math.Sqrt(
            a.Radius * a.Radius +
            b.Radius * b.Radius -
            2 * a.Radius * b.Radius * Math.Cos(b.Angle - a.Angle)
        );
    }

    //3D пряма відстань (хорда) між двома сферичними точками
    public static double SphericalChord(SphericalPoint a, SphericalPoint b)
    {
        return Math.Sqrt(
            a.Radius * a.Radius +
            b.Radius * b.Radius - 2 * a.Radius * b.Radius * (
                Math.Sin(a.PolarAngle) * Math.Sin(b.PolarAngle) * Math.Cos(a.Azimuth - b.Azimuth) +
                Math.Cos(a.PolarAngle) * Math.Cos(b.PolarAngle)
            )
        );
    }

    // 3D дугова відстань по поверхні сфери (велике коло)
    public static double SphericalArc(SphericalPoint a, SphericalPoint b)
    {
        double r = a.Radius;
        double cosAngle = Math.Sin(a.PolarAngle) * Math.Sin(b.PolarAngle) * Math.Cos(a.Azimuth - b.Azimuth) +
            Math.Cos(a.PolarAngle) * Math.Cos(b.PolarAngle);

        cosAngle = Math.Max(-1.0, Math.Min(1.0, cosAngle)); 
        return r * Math.Acos(cosAngle);
    }
}