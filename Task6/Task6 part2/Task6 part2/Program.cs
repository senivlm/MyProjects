using System;
using System.IO;

namespace Task6_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fwm = new FileWriteReadManager();
                fwm.DefinePath(@"D:\allprjcts\MyProjects\Task6\Task6 part2\Task6 part2\Result.txt");
                fwm.DivideTextIntoSentences();
                fwm.WriteSentencesIntoFile();
                fwm.PrintLongestShortestWordsInEachSentences();
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
