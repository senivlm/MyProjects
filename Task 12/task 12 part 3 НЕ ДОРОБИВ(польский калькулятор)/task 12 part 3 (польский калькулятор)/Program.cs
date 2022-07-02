using System;
using System.Collections.Generic;

class Calculator
{
    private Dictionary<string, Func<double, double, double>> binaryOperators;
    private Dictionary<string, Func<double, double>> unaryOperators;
    private Stack<double> operands; 

    public Calculator()
    {
        operands = new Stack<double>();
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

    public void AddValues(params double[] values)
    {
        foreach (var item in values)
        {
            operands.Push(item);
        }
    }

    public double UseOperator(string sign)
    {
        if(!operands.TryPop(out var operand1))
        {
            throw new IndexOutOfRangeException();
        }
        if (binaryOperators.ContainsKey(sign))
        {
            if (!operands.TryPop(out var operand2))
            {
                throw new IndexOutOfRangeException();
            }
            return binaryOperators[sign](operand1, operand2);
        }
        else if (unaryOperators.ContainsKey(sign))
        {
            return unaryOperators[sign](operand1);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public bool IsBinaryOperator(string operat)
    {
        return binaryOperators.ContainsKey(operat);
    }

    public bool IsUnaryOperator(string operat)
    {
        return unaryOperators.ContainsKey(operat);
    }

    public Calculator Copy()
    {
        var calc = new Calculator();
        calc.binaryOperators = new Dictionary<string, Func<double, double, double>>(binaryOperators);
        calc.unaryOperators = new Dictionary<string, Func<double, double>>(unaryOperators);
        calc.operands = new Stack<double>();
        return calc;
    }
}

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

    public double Compute()
    {
        var calc = new Calculator();
        string[] numbersAndOper = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in numbersAndOper)
        {
            double x = 0;
            if (TryToDouble(item, out x))
            {
                calc.AddValues(x);
            }
            else if (calc.IsUnaryOperator(item))
            {
                calc.AddValues()
            }
        }
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

class Program
{
    public static void Main()
    {

    }
}