using System;
using System.IO;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var communal1 = new CommunalPrintHandler(@"D:\allprjcts\MyProjects\Task8\Task8\communalList1.txt");
                var communal2 = new CommunalPrintHandler(@"D:\allprjcts\MyProjects\Task8\Task8\communalList2.txt");
                communal1.ReadAccountingElectricty();
                communal2.ReadAccountingElectricty();
                var communal3 = communal1 + communal2;
                communal3.ChangePath(@"D:\allprjcts\MyProjects\Task8\Task8\PlusMinusDemonstration.txt");
                communal3.WriteInfoFlatsInFile();
                communal3 = communal1 - communal2;
                communal3.ChangePath(@"D:\allprjcts\MyProjects\Task8\Task8\PlusMinusDemonstration.txt");
                communal3.WriteInfoFlatsInFile();
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
