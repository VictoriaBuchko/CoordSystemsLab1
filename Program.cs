using CoordSystemsLab1.Models;

const double Eps = 1e-9;
bool Near(double a, double b) => Math.Abs(a - b) < Eps;
string Check(bool ok) => ok ? "Збігаються" : "Не збігаються";

Console.WriteLine("=== Тест 2D перетворень ===");
var cartesian2D = new CartesianPoint2D(3.0, 4.0);
var polar = PolarPoint.FromCartesian(cartesian2D);
var cartesian2DBack = CartesianPoint2D.FromPolar(polar);
Console.WriteLine(cartesian2D);
Console.WriteLine(polar);
Console.WriteLine(cartesian2DBack);
Console.WriteLine($"X: {Check(Near(cartesian2D.X, cartesian2DBack.X))}
  Y: {Check(Near(cartesian2D.Y, cartesian2DBack.Y))}");

Console.WriteLine("\n=== Тест 3D перетворень ===");
var cartesian3D = new CartesianPoint3D(3.0, 4.0, 5.0);
var spherical = SphericalPoint.FromCartesian(cartesian3D);
var cartesian3DBack = CartesianPoint3D.FromSpherical(spherical);
Console.WriteLine(cartesian3D);
Console.WriteLine(spherical);
Console.WriteLine(cartesian3DBack);
Console.WriteLine($"X: {Check(Near(cartesian3D.X, cartesian3DBack.X))}
  Y: {Check(Near(cartesian3D.Y, cartesian3DBack.Y))}  Z: {Check(Near(cartesian3D.Z, cartesian3DBack.Z))}");

Console.WriteLine("\n=== Відстані 2D ===");
var origin2D = new CartesianPoint2D(0.0, 0.0);
var point2D = new CartesianPoint2D(3.0, 4.0);
Console.WriteLine($"Евклідова відстань: {DistanceCalculator.Euclidean(origin2D, point2D):F4}");
var polarPoint1 = new PolarPoint(2.0, 0.0);
var polarPoint2 = new PolarPoint(3.0, Math.PI / 3);
Console.WriteLine($"Полярна відстань:   {DistanceCalculator.Polar(polarPoint1, polarPoint2):F4}");

Console.WriteLine("\n=== Відстані 3D ===");
var sphericalPoint1 = new SphericalPoint(5.0, 0.5, 1.0);
var sphericalPoint2 = new SphericalPoint(5.0, 1.2, 0.8);
Console.WriteLine($"Пряма відстань (хорда): {DistanceCalculator.SphericalChord(sphericalPoint1, sphericalPoint2):F4}");
Console.WriteLine($"Дугова відстань:        {DistanceCalculator.SphericalArc(sphericalPoint1, sphericalPoint2):F4}");

//Бенчмаркінг
const int pairsCount = 100_000;
var random = new Random(42);
var stopwatch = new System.Diagnostics.Stopwatch();

var polarPairs = new (PolarPoint, PolarPoint)[pairsCount];
var cartesianPairs2D = new (CartesianPoint2D, CartesianPoint2D)[pairsCount];
for (int i = 0; i < pairsCount; i++)
{
    var first = new PolarPoint(random.NextDouble() * 100, random.NextDouble() * 2 * Math.PI);
    var second = new PolarPoint(random.NextDouble() * 100, random.NextDouble() * 2 * Math.PI);
    polarPairs[i] = (first, second);
    cartesianPairs2D[i] = (CartesianPoint2D.FromPolar(first), CartesianPoint2D.FromPolar(second));
}

Console.WriteLine("\n=== Бенчмаркінг 2D (N=100 000) ===");
double totalDistance = 0;
stopwatch.Restart();
for (int i = 0; i < pairsCount; i++)
    totalDistance += DistanceCalculator.Polar(polarPairs[i].Item1, polarPairs[i].Item2);
stopwatch.Stop();
double timePolar = stopwatch.Elapsed.TotalMilliseconds;

totalDistance = 0;
stopwatch.Restart();
for (int i = 0; i < pairsCount; i++)
    totalDistance += DistanceCalculator.Euclidean(cartesianPairs2D[i].Item1, cartesianPairs2D[i].Item2);
stopwatch.Stop();
double timeCartesian2D = stopwatch.Elapsed.TotalMilliseconds;

Console.WriteLine($"Підхід А  (полярні, теорема косинусів): {timePolar:F3} мс");
Console.WriteLine($"Підхід Б  (декартові, евклідова):       {timeCartesian2D:F3} мс");
Console.WriteLine($"Декартові швидше у:                     {timePolar / timeCartesian2D:F3}x");

var sphericalPairs = new (SphericalPoint, SphericalPoint)[pairsCount];
var cartesianPairs3D = new (CartesianPoint3D, CartesianPoint3D)[pairsCount];
for (int i = 0; i < pairsCount; i++)
{
    double radius = random.NextDouble() * 100 + 1.0;
    var first = new SphericalPoint(radius, random.NextDouble() * 2 * Math.PI, random.NextDouble() * Math.PI);
    var second = new SphericalPoint(radius, random.NextDouble() * 2 * Math.PI, random.NextDouble() * Math.PI);
    sphericalPairs[i] = (first, second);
    cartesianPairs3D[i] = (CartesianPoint3D.FromSpherical(first), CartesianPoint3D.FromSpherical(second));
}

Console.WriteLine("\n=== Бенчмаркінг 3D (N=100 000) ===");
totalDistance = 0;
stopwatch.Restart();
for (int i = 0; i < pairsCount; i++)
    totalDistance += DistanceCalculator.SphericalChord(sphericalPairs[i].Item1, sphericalPairs[i].Item2);
stopwatch.Stop();
double timeChord = stopwatch.Elapsed.TotalMilliseconds;

totalDistance = 0;
stopwatch.Restart();
for (int i = 0; i < pairsCount; i++)
    totalDistance += DistanceCalculator.SphericalArc(sphericalPairs[i].Item1, sphericalPairs[i].Item2);
stopwatch.Stop();
double timeArc = stopwatch.Elapsed.TotalMilliseconds;

totalDistance = 0;
stopwatch.Restart();
for (int i = 0; i < pairsCount; i++)
{
    var (first, second) = cartesianPairs3D[i];
    double dx = second.X - first.X;
    double dy = second.Y - first.Y;
    double dz = second.Z - first.Z;
    totalDistance += Math.Sqrt(dx * dx + dy * dy + dz * dz);
}
stopwatch.Stop();
double timeCartesian3D = stopwatch.Elapsed.TotalMilliseconds;

Console.WriteLine($"Підхід А  (сферична, хорда):      {timeChord:F3} мс");
Console.WriteLine($"Підхід Б  (сферична, дуга):        {timeArc:F3} мс");
Console.WriteLine($"Підхід В  (декартова, евклідова):  {timeCartesian3D:F3} мс");
Console.WriteLine($"Декартові швидше за хорду у:       {timeChord / timeCartesian3D:F3}x");
Console.WriteLine($"Декартові швидше за дугу у:        {timeArc / timeCartesian3D:F3}x");