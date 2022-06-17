using System;
using System.IO;

namespace Task8Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\allprjcts\MyProjects\Task8\Task8Part2\Task8Part2\datatxt.txt";
            var attendaceStatistic = new AttendanceStatistics(path);
            using(var sw = new StreamWriter(path, true))
            {
                sw.WriteLine();
                foreach (var item in attendaceStatistic)
                {
                    sw.WriteLine(item);
                }
                sw.WriteLine();
                sw.WriteLine("Most active ip: " + attendaceStatistic.FindMostVisitedIp());
                sw.WriteLine("Most visited day:  " + attendaceStatistic.FindMostVisitedDay());
                sw.WriteLine("Most visited time interval:  " + attendaceStatistic.FindMostVisitedHourInterval());
                sw.WriteLine("Most visited time interval in defined day(sunday): "
                    + attendaceStatistic.FindMostVisitedHourInDay(DayOfWeek.Sunday));
            }
        }
    }
}
