using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        //сам ввід не прив*язаний до логіки, по суті, ми можемо його змінити на читання з файлу
        string x = "";
        var calc = new PolishCalculatorService("");
        while (x != "exit" || x != "EXIT")
        {
            Console.WriteLine("Enter example");
            x = Console.ReadLine();
            calc.ChangeLine(x);
            //compute це дженерік метод, щоб можливо було вибирати реалізації калькулятора, які реалізують
            //інтерфейс icalculator
            Console.WriteLine("Result: " + calc.Compute<Calculator>());
        }
        //додавання операцій
        Calculator calculator = new Calculator();
        calculator.AddBinaryOperator("%", (x, y) => x % y);

    }
}