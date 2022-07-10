public struct Coordinate
{
    public double X { get; }
    public double Y { get; }
    public Coordinate(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double ComputeDistance(double x, double y)
    {
        return Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - Y, 2));
    }

    public double ComputeDistance(Coordinate coordinate)
    {
        return Math.Sqrt(Math.Pow(coordinate.X - X, 2) + Math.Pow(coordinate.Y - Y, 2));
    }

    public static bool TryParse(string text, out Coordinate result)
    {
        string[] data = text.Split(",()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        double[] xy = new double[2];
        if (!double.TryParse(data[0], out xy[0]))
        {
            result = new();
            return false;
        }
        if (!double.TryParse(data[1], out xy[1]))
        {
            result = new();
            return false;
        }

        result = new Coordinate(xy[0], xy[1]);
        return true;
    }

    public override string? ToString()
    {
        return $"({X},{Y})";
    }
}
