class Calculator : ICalculator
{
    private Dictionary<string, Func<double, double, double>> binaryOperators;
    private Dictionary<string, Func<double, double>> unaryOperators;
    private Queue<double> operands; 

    public Calculator()
    {
        operands = new Queue<double>();
        binaryOperators = new Dictionary<string, Func<double, double, double>>();
        binaryOperators.Add("+", (x, y) => x + y);
        binaryOperators.Add("*", (x, y) => x * y);
        binaryOperators.Add("-", (x, y) => x - y);
        binaryOperators.Add("/", (x, y) => x / y);
        binaryOperators.Add("^", (x, y) => Math.Pow(x, y));

        unaryOperators = new Dictionary<string, Func<double, double>>();
        unaryOperators.Add("cos", x => Math.Cos(x));
        unaryOperators.Add("sin", x => Math.Sin(x));
        unaryOperators.Add("tg", x => Math.Tan(x));
        unaryOperators.Add("ctg", x => 1.0 / Math.Tan(x));
    }


    public void AddBinaryOperator(string sign, Func<double, double, double> func)
    {
        if (binaryOperators.ContainsKey(sign))
            return;
        binaryOperators.Add(sign, func);
    }

    public void AddUnaryOperator(string sign, Func<double, double> func)
    {
        if (unaryOperators.ContainsKey(sign))
            return;
        unaryOperators.Add(sign, func);
    }

    public void AddValue(params double[] values)
    {
        foreach (var item in values)
        {
            operands.Enqueue(item);
        }
    }

    public double PopValue()
    {
        if(operands.Count == 0)
        {
            throw new Exception();
        }
        return operands.Dequeue();
    }

    public double UseOperator(string sign)
    {
        if(!operands.TryPeek(out var operand1))
        {
            throw new IndexOutOfRangeException();
        }
        operands.Dequeue();
        if (binaryOperators.ContainsKey(sign))
        {
            if (!operands.TryPeek(out var operand2))
            {
                throw new IndexOutOfRangeException();
            }
            operands.Dequeue();
            double x = binaryOperators[sign](operand1, operand2);
            return x;
        }
        else if (unaryOperators.ContainsKey(sign))
        {
            double x = unaryOperators[sign](operand1);
            return x;
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public bool IsBinaryOperator(string operat) => binaryOperators.ContainsKey(operat);
    

    public bool IsUnaryOperator(string operat) => unaryOperators.ContainsKey(operat);

    public bool IsOperator(string operat) => unaryOperators.ContainsKey(operat) || binaryOperators.ContainsKey(operat);

    public Calculator Copy()
    {
        var calc = new Calculator();
        calc.binaryOperators = new Dictionary<string, Func<double, double, double>>(binaryOperators);
        calc.unaryOperators = new Dictionary<string, Func<double, double>>(unaryOperators);
        calc.operands = new Queue<double>();
        return calc;
    }

    public double PeekLastValue() => operands.Dequeue();
}
