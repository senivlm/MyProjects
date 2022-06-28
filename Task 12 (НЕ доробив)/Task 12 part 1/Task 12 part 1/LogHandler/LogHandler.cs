using System;
using System.Collections.Generic;
using System.IO;

namespace Task_11.LogHandler
{
    public class LogHandler<T>
    {
        private List<string> errors = new List<string>();
        private Dictionary<int, T> objectsInLogs = new Dictionary<int, T>();

        private string path;
        private int indexObject = 0;

        public LogHandler(string path)
        {
            this.path = path;
        }

        public T GetLogObject(int index)
        {
            if (index >= 0 && index < objectsInLogs.Count)
            {
                return objectsInLogs[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddErorrLog(string log)
        {
            errors.Add(log);
            try
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(log + " - " + DateTime.UtcNow);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AddCreatedObjectLog(T obj)
        {
            try
            {
                using (var sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"Created succesfuly {obj}, index: {indexObject}" + " - " + DateTime.UtcNow);
                    objectsInLogs[indexObject] = obj;
                    indexObject++;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
