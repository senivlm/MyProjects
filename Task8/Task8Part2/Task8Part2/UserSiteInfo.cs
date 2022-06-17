using System;

namespace Task8Part2
{
    public class UserSiteInfo
    {
        public string Ip { get; }
        private TimeSpan time;
        public TimeSpan Time { get => time; }
        private DayOfWeek day;
        public DayOfWeek Day { get => day; }

        public UserSiteInfo(string[] data)
        {
            try
            {
                Ip = data[0];
                string[] time = data[1].Split(':', StringSplitOptions.RemoveEmptyEntries);
                this.time = new TimeSpan(Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), Convert.ToInt32(time[2]));
                if (!Enum.IsDefined(typeof(DayOfWeek), data[2]))
                {
                    day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), data[2], true);
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public UserSiteInfo(string ip, TimeSpan time, DayOfWeek day)
        {
            Ip = ip;
            this.time = time;
            this.day = day;
        }
    }
}
