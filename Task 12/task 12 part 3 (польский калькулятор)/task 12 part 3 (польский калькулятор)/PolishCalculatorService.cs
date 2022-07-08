class PolishCalculatorService
{
    private string notation;
    public PolishCalculatorService(string notation)
    {
        this.notation = notation;
    }

    public void ChangeLine(string notation)
    {
        this.notation = notation;
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
        string[] numbersAndOper = notation.Split(' ', StringSplitOptions.RemoveEmptyEntries);
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
