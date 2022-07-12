interface ICalculator
{// можна було розділити на 2 інтерфейси.
    public void AddBinaryOperator(string sign, Func<double, double, double> func);
    public void AddUnaryOperator(string sign, Func<double, double> func);
    public void AddValue(params double[] values);
    public double PopValue();
    public double UseOperator(string sign);
    public bool IsBinaryOperator(string operat);
    public bool IsUnaryOperator(string operat);
    public bool IsOperator(string operat);
    public Calculator Copy();
}
