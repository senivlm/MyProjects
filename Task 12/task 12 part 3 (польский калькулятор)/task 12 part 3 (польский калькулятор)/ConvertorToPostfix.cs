class ConvertorToPostfix
{
    private Dictionary<string, int> priority;

    public ConvertorToPostfix()
    {
        priority = new Dictionary<string, int>();

        priority.Add("(", 0);
        priority.Add("+", 1);
        priority.Add("-", 1);
        priority.Add("*", 2);
        priority.Add("/", 2);
        priority.Add("sin", 3);
        priority.Add("cos", 3);
        priority.Add("tg", 3);
        priority.Add("ctg", 3);
    }

    public void AddPriority(string sign, int value)
    {
        priority[sign] = value;
    }

    public string ConvertToPostfixNotation(string text, ICalculator calculator)
    {
        text = "(" + text + ")";
        string postfixEx = "";
        Stack<string> stack = new Stack<string>();
        List<string> dividedNotation = (List<string>)divideToOperandsAndFuncs(text, calculator);
        for (int i = 0; i < dividedNotation.Count; i++)
        {
            if (char.IsDigit(dividedNotation[i][dividedNotation[i].Length - 1]))
            {
                postfixEx += dividedNotation[i] + " ";
            }
            else if (dividedNotation[i] == "(")
            {
                stack.Push(dividedNotation[i]);
            }
            else if (dividedNotation[i] == ")")
            {
                while (stack.Peek() != "(")
                {
                    postfixEx += stack.Pop() + " ";
                }
                stack.Pop();
            }
            else
            {
                while (priority[stack.Peek()] >= priority[dividedNotation[i]])
                {
                    postfixEx += stack.Pop() + " ";
                }
                stack.Push(dividedNotation[i]);
            }
        }
        return postfixEx;
    }



    private ICollection<string> divideToOperandsAndFuncs(string text, ICalculator calculator)
    {
        List<string> expression = new List<string>();
        int start = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsDigit(text[i]) ||
                (text[i] == '-' && calculator.IsOperator(char.ToString(text[i])) && char.IsDigit(text[i + 1])
                && !char.IsDigit(expression[expression.Count - 1][expression[expression.Count - 1].Length - 1])))
            {
                string number = char.ToString(text[i]);
                while (text.Length - 1 > i && (char.IsDigit(text[++i]) || text[i] == '.'))
                {
                    number += text[i];
                }
                i--;
                expression.Add(number);
            }
            else if (calculator.IsOperator(char.ToString(text[i])))
            {
                expression.Add(char.ToString(text[i]));
            }
            else if (text[i] == '(' || text[i] == ')')
            {
                expression.Add(char.ToString(text[i]));
            }
            else if (text.Length > i && char.IsLetter(text[i]))
            {
                string func = char.ToString(text[i]);
                while (text.Length - 1 > i && text[++i] != '(')
                {
                    func += text[i];
                }
                expression.Add(func);
                expression.Add(char.ToString(text[i]));
                string number = "";
                while (text.Length - 1 > i && text[++i] == '(')
                {
                    expression.Add(char.ToString(text[i]));
                }
                number += text[i];
                while (text.Length - 1 > i && (char.IsDigit(text[++i]) || text[i] == '.'))
                {
                    number += text[i];
                }
                expression.Add(number);
                expression.Add(char.ToString(text[i]));
            }
        }
        return expression;
    }
}
