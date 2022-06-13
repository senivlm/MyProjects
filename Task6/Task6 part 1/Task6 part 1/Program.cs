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
                var communal = new CommunalPrintHandler(@"D:\allprjcts\MyProjects\Task6\Task6 part 1\Task6 part 1\Result.txt");
                communal.ReadAccountingElectricty();
                communal.WriteInfoFlatsInFile();
                communal.PrintSomethingInFile(communal.DefinePricesForIncomingCounters());
                communal.WriteOneFlatInfoInFile(41);
                communal.PrintSomethingInFile("Name with largest debt: " + communal.FindNameWithLargestDebt());
                communal.PrintSomethingInFile("Number flat with no consuming: " + communal.FindNumberFlatWithNoConsuming());
                communal.PrintSomethingInFile("Last days from last taken info of 41 appartment (march): " + communal.FindLastDaysFromLastTakenInfo(41, 3));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
