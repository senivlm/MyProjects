using System;

namespace ConsoleApp1
{
    class Program
    {
        static void DrawLine(Func<float, float> func)
        {
            for (float i = 0; i < 200; i += 0.1f)
            {
                float voids = MathF.Round(func(i));
                Console.Write(new string(' ', (int)voids + 200));
                
                Console.Write("#");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            DrawLine(x => MathF.Cos(x) + MathF.Cos(x));
        }
    }
}
