using System;
using System.Collections.Generic;
using System.IO;

namespace Task6_part_1
{
    public static class CommunalPrintHandler
    {
        private static int flatAmount;
        private static int quarter;
        private static Dictionary<int, FlatInfoMonth[]> flatsInfo;
        public static readonly float PriceForElectricity = 1.68f;
        private static int tabulation = 3;
        public static string currentPath { get; private set; }

        public static void ReadAccountingElectricty(string path)
        {
            flatsInfo = new Dictionary<int, FlatInfoMonth[]>();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    currentPath = path;
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
                        flatsInfo[number] = new FlatInfoMonth[3];
                        if(flatData[1].Length > tabulation)
                        {
                            tabulation = flatData[1].Length + 2;
                        }
                        for (int j = 1; j <= 3; j++)
                        {
                            flatsInfo[number][j - 1] = new FlatInfoMonth(flatData[1], int.Parse(flatData[j+1]), DateTime.Parse(flatData[j+4]));
                        }
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
            using (var sw = new StreamWriter(currentPath, true))
            {
                string[] months = convertQuarterToMonth(quarter);
                sw.WriteLine();
                sw.WriteLine("Amount of apartments: {0}, quarter: {1}", flatAmount, quarter);
                sw.WriteLine($"Owner{computeTabulation("Owner")}{months[0]}{computeTabulation(months[0])}" +
                    $"{months[1]}{new string(' ', tabulation - months[1].Length)}{months[2]}{computeTabulation(months[2])}Cost (UAH)");
                foreach (var item in flatsInfo)
                {
                    sw.Write($"{item.Value[0].PayerName}{computeTabulation(item.Value[0].PayerName)}");
                    sw.Write($"{item.Value[0].IncomingCounter}" +
                        $"{computeTabulation(item.Value[0].IncomingCounter)}{item.Value[1].IncomingCounter}" +
                        $"{computeTabulation(item.Value[1].IncomingCounter)}{item.Value[2].IncomingCounter}" +
                        $"{computeTabulation(item.Value[2].IncomingCounter)}{findPrice(item.Value)}");
                    sw.WriteLine();
                }
            }
        }

        private static int findPrice(FlatInfoMonth[] flat)
        {
            if(flat == null)
            {
                return -1;
            }
            int price = 0;
            for (int i = 0; i < flat.Length; i++)
            {
                price += flat[i].IncomingCounter;
            }
            return price * (int)PriceForElectricity;
        }

        public static void WriteOneFlatInfoInFile(int appartmentNumber)
        {
            using (var sw = new StreamWriter(currentPath, true))
            {
                sw.WriteLine();
                string[] months = convertQuarterToMonth(quarter);
                sw.WriteLine($"Owner{computeTabulation("owner")}{months[0]}{computeTabulation(months[0])}" +
                   $"{months[1]}{computeTabulation(months[1])}{months[2]}{computeTabulation(months[2])}Cost (UAH)");
                sw.Write($"{flatsInfo[appartmentNumber][0].PayerName}{computeTabulation(flatsInfo[appartmentNumber][0].PayerName)}");
                sw.Write($"{flatsInfo[appartmentNumber][0].IncomingCounter}" +
                    $"{computeTabulation(flatsInfo[appartmentNumber][0].IncomingCounter)}{flatsInfo[appartmentNumber][1].IncomingCounter}" +
                    $"{computeTabulation(flatsInfo[appartmentNumber][1].IncomingCounter)}{flatsInfo[appartmentNumber][2].IncomingCounter}" +
                    $"{computeTabulation(flatsInfo[appartmentNumber][2].IncomingCounter)}{findPrice(flatsInfo[appartmentNumber])}");
                sw.WriteLine();
                sw.WriteLine();
            }
        }

        private static string computeTabulation(object obj)
        {
            return new string(' ', tabulation - Convert.ToString(obj).Length);
        }

        public static string FindNameWithLargestDebt()
        {
            FlatInfoMonth flat = null;
            using (var sw = new StreamWriter(currentPath, true))
            {
                int maxConsumed = int.MinValue;
                foreach (var item in flatsInfo)
                {
                    int price = findPrice(item.Value);
                    if (price > maxConsumed)
                    {
                        flat = item.Value[0];
                        maxConsumed = price;
                    }
                }
            }
            return flat == null ? "no data" : flat.PayerName;
        }

        public static int FindNumberFlatWithNoConsuming()
        {
            int number = -1;
            using (var sw = new StreamWriter(currentPath, true))
            {
                foreach (var item in flatsInfo)
                {
                    if (findPrice(item.Value) == 0)
                    {
                        number = item.Key;
                    }
                }
            }
            return number;
        }

        public static string[] DefinePricesForIncomingCounters()
        {
            string[] allPricesForFlats = new string[flatAmount];
            int i = 0;
            foreach (var item in flatsInfo)
            {
                allPricesForFlats[i] = string.Format("Price for flat n{0}: {1} UAH", item.Key, findPrice(item.Value));
                i++;
            }
            return allPricesForFlats;
        }

        public static int FindLastDaysFromLastTakenInfo(int numberAppart, int monthsNumber)
        {
            if (DateTime.Now.DayOfYear > flatsInfo[numberAppart][monthsNumber - 1].Date.DayOfYear)
            {
                return DateTime.Now.DayOfYear - flatsInfo[numberAppart][monthsNumber - 1].Date.DayOfYear;
            }
            else
            {
                return flatsInfo[numberAppart][monthsNumber - 1].Date.DayOfYear - DateTime.Now.DayOfYear;
            }
        }

        public static void PrintSomethingInFile(string someText)
        {
            using (var sw = new StreamWriter(currentPath, true))
            {
                sw.WriteLine(someText);
            }
        }
        public static void PrintSomethingInFile(string[] someText)
        {
            using (var sw = new StreamWriter(currentPath, true))
            {
                sw.WriteLine();
                foreach (var txt in someText)
                {
                    sw.WriteLine(txt);
                }
            }
        }

        private static string[] convertQuarterToMonth(int quarter)
        {
            string[] months = null;
            switch (quarter)
            {
                case 1:
                    months = new string[3] { "January", "February", "March" };
                    break;
                case 2:
                    months = new string[3] { "April", "May", "June"};
                    break;
                case 3:
                    months = new string[3] { "July", "August", "September" };
                    break;
                case 4:
                    months = new string[3] { "October", "November", "December" };
                    break;
                default:
                    throw new ArgumentException();
            }
            return months;
        }

        public static string ConvertToFullData(DateTime date)
        {
            string fullData = date.Day + " ";
            switch (date.Month)
            {
                case 1:
                    fullData += "January ";
                    break;
                case 2:
                    fullData += "February ";
                    break;
                case 3:
                    fullData += "March ";
                    break;
                case 4:
                    fullData += "April ";
                    break;
                case 5:
                    fullData += "May ";
                    break;
                case 6:
                    fullData += "June ";
                    break;
                case 7:
                    fullData += "July ";
                    break;
                case 8:
                    fullData += "August ";
                    break;
                case 9:
                    fullData += "September ";
                    break;
                case 10:
                    fullData += "October ";
                    break;
                case 11:
                    fullData += "November ";
                    break;
                case 12:
                    fullData += "December ";
                    break;
            }
            fullData += date.Year;
            return fullData;
        }
    }
}
