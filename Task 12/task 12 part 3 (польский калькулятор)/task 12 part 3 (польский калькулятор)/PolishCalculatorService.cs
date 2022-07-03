class PolishCalculatorService
{
    private string line;
    public PolishCalculatorService(string line)
    {
        this.line = line;
    }

    public void ChangeLine(string line)
    {
        this.line = line;
    }

    public double Compute(ICalculator calculator)
    {
        var calc = calculator.Copy();
        return compute(calc);
    }

    public double Compute<T>()
        where T : ICalculator, new()
    {
        var calc = new T();
        return compute(calc);
    }

    private double compute(ICalculator calculator)
    {
        string[] numbersAndOper = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in numbersAndOper)
        {
            double x = 0;
            if (TryToDouble(item, out x))
            {
                calculator.AddValue(x);
            }
            else if (calculator.IsUnaryOperator(item) || calculator.IsBinaryOperator(item))
            {
                calculator.AddValue(calculator.UseOperator(item));
            }
        }
        return calculator.PeekLastValue();
    }

    private bool TryToDouble(string line, out double number)
    {
        if(!double.TryParse(line,out number))
        {
            return false;
        }
        return true;
    }
}
