using System;
using System.IO;

namespace Task6_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CommunalPrintHandler.ReadAccountingElectricty(@"D:\allprjcts\MyProjects\Task6\Task6 part 1\Task6 part 1\Result.txt");
                CommunalPrintHandler.WriteInfoFlatsInFile();
                CommunalPrintHandler.PrintSomethingInFile(CommunalPrintHandler.DefinePricesForIncomingCounters());
                CommunalPrintHandler.WriteOneFlatInfoInFile(41);
                CommunalPrintHandler.PrintSomethingInFile("Name with largest debt:" + CommunalPrintHandler.FindNameWithLargestDebt());
                CommunalPrintHandler.PrintSomethingInFile("Number flat with no consuming: " + CommunalPrintHandler.FindNumberFlatWithNoConsuming());
                CommunalPrintHandler.PrintSomethingInFile("Last days from last taken info of 41 appartment (march): " + CommunalPrintHandler.FindLastDaysFromLastTakenInfo(41, 3));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
