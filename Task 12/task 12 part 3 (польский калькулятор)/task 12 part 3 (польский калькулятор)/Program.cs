using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        try
        {
            //сам ввід не прив*язаний до логіки, по суті, ми можемо його змінити на читання з файлу
            string x = "";
            //додавання операцій
            Calculator calculator = new Calculator();
            calculator.AddBinaryOperator("%", (x, y) => x % y);
            var calc = new PolishCalculatorService("");
            do
            {
                Console.WriteLine("Enter example");
                x = Console.ReadLine();
                if (x != "exit" && x != "EXIT")
                {
                    calc.ChangeLine(x);
                    //compute це дженерік метод, щоб можливо було вибирати реалізації калькулятора, які реалізують
                    //інтерфейс icalculator. Є ще також перегрузка для Сompute, якій можна передавати
                    //екземпляри калькулятора, які містять наприклад нові операції
                    Console.WriteLine("Result: " + calc.Compute(calculator));
                }
            }
            while (x != "exit" && x != "EXIT");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}