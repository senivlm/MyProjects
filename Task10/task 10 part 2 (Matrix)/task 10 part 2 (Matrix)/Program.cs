namespace _2Dmatrix
{
    class Program {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("direction: ");
            object dir;
            if(!Enum.TryParse(typeof(Directions), Console.ReadLine(), out dir))
            {
                Console.WriteLine("That direction does not exist");
                return;
            }
            foreach (var item in matrix.GetEnumeratorDiagonalSnake(n, (Directions)dir))
            {
                Console.WriteLine(item);
            }
        }
    }
}