namespace CoordSystemsLab1.Models;

public sealed class CartesianPoint2D
{
    public double X { get; }
    public double Y { get; }

    public CartesianPoint2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    public static CartesianPoint2D FromPolar(PolarPoint p)
    {
        double x = p.Radius * Math.Cos(p.Angle);
        double y = p.Radius * Math.Sin(p.Angle);
        return new CartesianPoint2D(x, y);
    }

    public override string ToString() =>
        $"CartesianPoint2D(x={X:F4}, y={Y:F4})";
}