using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace Task8Part2
{
    public class AttendanceStatistics : IEnumerable<string>
    {
        private string currentPath;

        private Dictionary<string, int> ipCollection;
        private Dictionary<DayOfWeek, int> daysOfAttend;
        private Dictionary<DayOfWeek, List<int>> dayIntervals;
        private Dictionary<int, int> allIntervals;

        public AttendanceStatistics(string path)
        {
            currentPath = path;
            ipCollection = new Dictionary<string, int>();
            daysOfAttend = new Dictionary<DayOfWeek, int>();
            dayIntervals = new Dictionary<DayOfWeek, List<int>>();
            allIntervals = new Dictionary<int, int>();
            initializateDataFromFile();
        }

        private void initializateDataFromFile()
        {
            try
            {
                using (var sr = new StreamReader(currentPath))
                {
                    int i = 0;
                    while (!sr.EndOfStream)
                    {
                        string[] text = sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var user = new UserSiteInfo(text);
                        ipCollection[user.Ip] = ipCollection.ContainsKey(user.Ip) ? ipCollection[user.Ip] + 1 : 1;
                        daysOfAttend[user.Day] = daysOfAttend.ContainsKey(user.Day) ? daysOfAttend[user.Day] + 1 : 1;
                        allIntervals[user.Time.Hours] = allIntervals.ContainsKey(user.Time.Hours) ? allIntervals[user.Time.Hours] + 1 : 1;
                        if (dayIntervals.ContainsKey(user.Day))
                        {
                            dayIntervals[user.Day].Add(user.Time.Hours);
                        }
                        else
                        {
                            dayIntervals[user.Day] = new List<int>();
                            dayIntervals[user.Day].Add(user.Time.Hours);
                        }
                        i++;
                    }
                }
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string FindMostVisitedIp()
        {
            return getMostAttribute(ipCollection);
        }

        public DayOfWeek FindMostVisitedDay()
        {
            return getMostAttribute(daysOfAttend);
        }

        public int FindMostVisitedHourInterval()
        {
            return getMostAttribute(allIntervals);
        }

        public int FindMostVisitedHourInDay(DayOfWeek day)
        {
            var dict = new Dictionary<int, int>();
            int max = -1;
            for (int i = 0; i < dayIntervals[day].Count; i++)
            {
                dict[dayIntervals[day][i]] = dict.ContainsKey(dayIntervals[day][i]) ? dict[dayIntervals[day][i]] + 1 : 1;
                if (!dict.ContainsKey(max) || dict[max] < dict[dayIntervals[day][i]])
                {
                    max = dayIntervals[day][i];
                }
            }
            return max;
        }

        private T getMostAttribute<T>(Dictionary<T, int> objs)
        {
            int max = -1;
            foreach(var item in objs)
            {
                if(item.Value > max)
                {
                    max = item.Value;
                }
            }
            foreach (var item in objs)
            {
                if(EqualityComparer<int>.Default.Equals(item.Value, max))
                {
                    return item.Key;
                }
            }
            return default;
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach(var item in ipCollection)
            {
                yield return string.Format("{0} visited {1} times", item.Key, item.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
