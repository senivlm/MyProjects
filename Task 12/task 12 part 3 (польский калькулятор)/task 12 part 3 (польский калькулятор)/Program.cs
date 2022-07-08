class Program
{
    public static void Main()
    {
        Calculator calculator = new();
        ConvertorToPostfix convertorToPostfix = new();
        using (var sr = new StreamReader(@"D:\MyProjects\Task 12\task 12 part 3 (польский калькулятор)\task 12 part 3 (польский калькулятор)\Приклади.txt"))
        {
            while (!sr.EndOfStream)
            {
                string normalNotation = sr.ReadLine();
                string postfixNotation = convertorToPostfix.ConvertToPostfixNotation(normalNotation, calculator);
                PolishCalculatorService calcService = new(postfixNotation);
                double result = calcService.Compute(calculator);
                using (var sw = new StreamWriter(@"D:\MyProjects\Task 12\task 12 part 3 (польский калькулятор)\task 12 part 3 (польский калькулятор)\Результати.txt"))
                {
                    sw.WriteLine($"Normal notation: {normalNotation}");
                    sw.WriteLine($"Postfix(polish) notation: {postfixNotation}");
                    sw.WriteLine($"Result: {result}");
                }
                
            }
        }
    }
}