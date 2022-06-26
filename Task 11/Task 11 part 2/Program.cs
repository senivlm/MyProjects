namespace ASDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList<int>(2, 3, 6, 1, 4, 5);
            Console.WriteLine(myList);
            myList.Sort();
            Console.WriteLine(myList);
            Console.WriteLine(myList.FindIndex(1));
        }
    }
}