using System;
using System.Collections.Generic;
using System.IO;

namespace Task6_part_1
{
    public static class CommunalPrintHandler
    {
        private static int flatAmount;
        private static int quarter;
        private static Dictionary<int, FlatInfo> flatsInfo;
        public static readonly float PriceForElectricity = 1.68f;
        public static string currnetPath { get; private set; }

        public static void ReadAccountingElectricty(string path)
        {
            flatsInfo = new Dictionary<int, FlatInfo>();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    currnetPath = path;
                    string[] firstLineData = sr.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (!int.TryParse(firstLineData[0], out flatAmount))
                    {
                        throw new FormatException("Invalid number of flats");
                    }
                    if (!int.TryParse(firstLineData[1], out quarter))
                    {
                        throw new FormatException("Invalid number of square");
                    }
                    if(quarter < 1 || quarter > 4)
                    {
                        throw new Exception("Invalid entered quarter");
                    }

                    for (int i = 0; i < flatAmount; i++)
                    {
                        string[] flatData = sr.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        int number = 0;
                        if (!int.TryParse(flatData[0], out number))
                        {
                            throw new FormatException("Invalid number of flat");
                        }
                        flatsInfo[number] = new FlatInfo(flatData[1], int.Parse(flatData[2]), int.Parse(flatData[3]), DateTime.Parse(flatData[4]), number);
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void WriteInfoFlatsInFile()
        {
            using (var sw = new StreamWriter(currnetPath, true))
            {
                sw.WriteLine();
                sw.WriteLine();
                sw.WriteLine("Amount of apartments: {0}, quarter: {1}", flatAmount, quarter);
                foreach (var item in flatsInfo)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public static void WriteOneFlatInfoInFile(int appartmentNumber)
        {
            using (var sw = new StreamWriter(currnetPath, true))
            {
                sw.WriteLine();
                sw.WriteLine(flatsInfo[appartmentNumber]);
            }
        }

        public static string FindNameWithLargestDebt()
        {
            FlatInfo flat = null;
            using (var sw = new StreamWriter(currnetPath, true))
            {
                int maxConsumed = int.MinValue;
                foreach (var item in flatsInfo)
                {
                    if (item.Value.IncomingCounter > maxConsumed)
                    {
                        flat = item.Value;
                        maxConsumed = item.Value.IncomingCounter;
                    }
                }
            }
            return flat == null ? "no data" : flat.OwnerName;
        }

        public static int FindNumberFlatWithNoConsuming()
        {
            FlatInfo flat = null;
            using (var sw = new StreamWriter(currnetPath, true))
            {
                foreach (var item in flatsInfo)
                {
                    if (item.Value.IncomingCounter == 0)
                    {
                        flat = item.Value;
                    }
                }
            }
            return flat == null ? -1 : flat.Number;
        }

        public static string[] DefinePricesForIncomingCounters()
        {
            string[] allPricesForFlats = new string[flatAmount];
            int i = 0;
            foreach (var item in flatsInfo)
            {
                allPricesForFlats[i] += string.Format("Price for flat n{0}: {1} grn", item.Key, item.Value.IncomingCounter * PriceForElectricity);
                i++;
            }
            return allPricesForFlats;
        }

        public static int FindLastDaysFromLastTakenInfo(int numberAppart)
        {
            if (DateTime.Now.DayOfYear > flatsInfo[numberAppart].Date.DayOfYear)
            {
                return DateTime.Now.DayOfYear - flatsInfo[numberAppart].Date.DayOfYear;
            }
            else
            {
                return flatsInfo[numberAppart].Date.DayOfYear - DateTime.Now.DayOfYear;
            }
        }

        public static void PrintSomethingInFile(string someText)
        {
            using (var sw = new StreamWriter(currnetPath, true))
            {
                sw.WriteLine(someText);
            }
        }
        public static void PrintSomethingInFile(string[] someText)
        {
            using (var sw = new StreamWriter(currnetPath, true))
            {
                sw.WriteLine();
                foreach (var txt in someText)
                {
                    sw.WriteLine(txt);
                }
            }
        }
    }
}
